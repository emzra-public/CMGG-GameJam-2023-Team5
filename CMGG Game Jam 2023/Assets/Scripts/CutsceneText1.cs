using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CutsceneText1 : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.03f;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private List<string> dialogueLines = new List<string>();
    private int currentLine = 0;
    private bool isTyping = false;
    SavePlayerPos playerPosData;


    private void Start()
    {
        dialogueLines.Add("First line of text.");
        dialogueLines.Add("Second line of text.");
        dialogueLines.Add("Third line of text.");
        // Add more lines as needed.
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
                // Optional: Hide or disable the dialogue box when all lines have been shown.
                // gameObject.SetActive(false);
                //GameManager.Instance.EndCutscene1();

                Debug.Log("Check else is running");

                SceneManager.LoadScene("Dark Scene");

            }
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detects left mouse button clicks
        {
            NextLine();
        }
    }
}