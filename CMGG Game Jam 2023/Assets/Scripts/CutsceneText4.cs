using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CutsceneText4 : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.04f;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private List<string> dialogueLines = new List<string>();
    private int currentLine = 0;
    private bool isTyping = false;
    SavePlayerPos playerPosData;


    private void Start()
    {
        dialogueLines.Add("I don’t understand what’s going on. I don’t know what's happening. I don’t know I don’t know I don’t know I don’t know I don’t know I don’t know");
        dialogueLines.Add("Why is she always so upset? She says she still loves me afterwards but I’m just so tired of the fighting… I have no idea what we’re even fighting about!");
        dialogueLines.Add("Something about an important date... anniversary... something like that. I could have sworn that I had written down whatever she’s mad about this time in my… my…");
        dialogueLines.Add("...");
        dialogueLines.Add("What was I talking about again?");

        StartCoroutine(TypeText(dialogueLines[currentLine]));
        Debug.Log("type text work");

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


    public void NextLine()
    {
        Debug.Log("Test next line running");
        if (!isTyping)
        {
            currentLine++;
            if (currentLine < dialogueLines.Count)
            {
                StartCoroutine(TypeText(dialogueLines[currentLine]));
            }
            else
            {
                Debug.Log("Check else is running");

                gameObject.SetActive(false);
                SceneManager.LoadScene("Dark Scene");
            }
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            NextLine();
        }
    }
}