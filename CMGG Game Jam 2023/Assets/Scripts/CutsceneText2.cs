using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CutsceneText2 : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.04f;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private List<string> dialogueLines = new List<string>();
    private int currentLine = 0;
    private bool isTyping = false;
    SavePlayerPos playerPosData;


    private void Start()
    {
        dialogueLines.Add("Her flower in my hair. Our fingers interlaced, as if we are one.");
        dialogueLines.Add("The bittersweet sound of children laughing fills the air as the spring’s bloom swirls around us. I pull out my phone to capture the moment, because I know I’ll want to remember this forever.");
        dialogueLines.Add("She gently grabs my arm to adjust the camera’s angle, and I watch with piqued curiosity as she positions her hand perfectly against mine. A heart. So cheesy.");
        dialogueLines.Add("We spend the rest of the day in our childlike wonder, getting drunk off of each other’s auras, forgetting what it’s like to be responsible adults with full-time jobs and lives.");
        dialogueLines.Add("But as the adults say, all good things must come to an end.");
        dialogueLines.Add("She envelopes my palms in her own before clasping my fingers over what appears to be a locket. “Now you can never forget me.” Blinding moonlight obscures her face, but I imagine her eyes crinkling as she smiles.");

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