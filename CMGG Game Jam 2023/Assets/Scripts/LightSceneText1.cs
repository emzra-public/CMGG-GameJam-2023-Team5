using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LightSceneText1 : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.04f;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private List<string> dialogueLines = new List<string>();
    private int currentLine = 0;
    private bool isTyping = false;
    SavePlayerPos playerPosData;
    private IEnumerator nextLineCoroutine;

    private void Start()
    {

        dialogueLines.Add("Hello, wanderer.");
        dialogueLines.Add("You must be feeling quite lost.");
        dialogueLines.Add("Your memory has been deteriorating at an increasing speed...");
        dialogueLines.Add("I can't reassure you that you'll be able to return home...");
        dialogueLines.Add("Although, you still have a chance to relive the moments that mattered most.");
        dialogueLines.Add("Go on! Before it is too late even for that!");

        StartCoroutine(TypeText(dialogueLines[currentLine]));
    }

    private IEnumerator TypeText(string text)
    {
        isTyping = true;
        dialogueText.text = "";
        foreach (char letter in text.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }


    public IEnumerator NextLine()
    {
        if (!isTyping)
        {
            currentLine++;
            if (currentLine < dialogueLines.Count)
            {
                StartCoroutine(TypeText(dialogueLines[currentLine]));
                if (currentLine == 5)
                {
                    StartCoroutine(PanCamera());
                    yield return StartCoroutine(MovePlayer(new Vector3(15f, 0f, 0f), 1.0f));
                }
            }
            else
            {
                gameObject.SetActive(false);
                GameObject.Find("Unknown Dialogue Box").SetActive(false);
            }
        }
    }

    private IEnumerator PanCamera()
    {
        float t = 0;
        Vector3 startPos = Camera.main.transform.position;
        Vector3 endPos = new Vector3(startPos.x + 15, startPos.y, startPos.z);
        Transform dialogueBoxTransform = GameObject.Find("Unknown Dialogue Box").transform;
        Vector3 dialogueBoxStartPos = dialogueBoxTransform.position;
        Vector3 dialogueBoxEndPos = new Vector3(dialogueBoxStartPos.x + 15, dialogueBoxStartPos.y, dialogueBoxStartPos.z);

        while (t < 1)
        {
            t += Time.deltaTime;
            Camera.main.transform.position = Vector3.Lerp(startPos, endPos, t);
            dialogueBoxTransform.position = Vector3.Lerp(dialogueBoxStartPos, dialogueBoxEndPos, t);
            yield return null;
        }
    }

    public IEnumerator MovePlayer(Vector3 position, float duration)
    {

        Transform playerTransform = GameObject.Find("Player").transform;


        Vector3 startPos = playerTransform.position;
        Vector3 endPos = position;
        Vector3 moveDir = (endPos - startPos).normalized;
        float moveDistance = Vector3.Distance(startPos, endPos);


        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime / duration;
            playerTransform.position = startPos + moveDir * moveDistance * t;
            yield return null;
        }

        playerTransform.position = endPos;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (nextLineCoroutine == null || !nextLineCoroutine.MoveNext())
            {
                nextLineCoroutine = NextLine();
                StartCoroutine(nextLineCoroutine);
            }
        }
    }
}