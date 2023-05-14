using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DarkSceneText1 : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.03f;
    [SerializeField] private TextMeshProUGUI dialogueText;
    public GameObject dialoguePanel;

    private List<string> dialogueLines = new List<string>();
    private int currentLine = 0;
    private bool isTyping = false;
    private bool dialogueStarted = false; // added boolean to check if dialogue has started or not
    SavePlayerPos playerPosData;

    private void Start()
    {
        dialoguePanel.SetActive(false);
    }

    private void Update()
    {
        if (Inventory.memories == 5 && !dialogueStarted) // Check if dialogue has already started or not
        {
            dialogueStarted = true;
            dialoguePanel.SetActive(true);
            StartDialogue();
        }
        if (Input.GetMouseButtonDown(0))
        {
            NextLine();
        }
    }

    void StartDialogue()
    {
        dialogueLines.Add("So… do you recognize her now?");
        dialogueLines.Add("…");
        StartCoroutine(TypeText(dialogueLines[currentLine]));
        Debug.Log("type text work");
    }

    public void EndDialogue()
    {
        dialogueStarted = false; // Set dialogueStarted back to false
        dialoguePanel.SetActive(false);
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
            if (currentLine < dialogueLines.Count - 1)
            {
                currentLine++;
                StartCoroutine(TypeText(dialogueLines[currentLine]));
            }
            else
            {
                Debug.Log("Check else is running");
                //EndDialogue(); // call EndDialogue method
                gameObject.SetActive(false);
                GameObject.Find("Unknown Dialogue Box").SetActive(false);
            }
        }
    }
}
