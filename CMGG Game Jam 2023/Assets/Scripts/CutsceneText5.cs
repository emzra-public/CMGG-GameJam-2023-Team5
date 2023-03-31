using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CutsceneText5 : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.03f;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private List<string> dialogueLines = new List<string>();
    private int currentLine = 0;
    private bool isTyping = false;
    SavePlayerPos playerPosData;


    private void Start()
    {
        dialogueLines.Add("A woman kneels in front of marble headstone and places a medium-sized bouquet on its grave. Wilted forget-me-nots, wrapped tightly in twine and bundled in an assortment of parchment paper.");
        dialogueLines.Add("I move closer to the headstone, not taking notice of my newfound ability to manuever freely within this liminal space. I read the name engraved at the top out loud. Here lies…");
        dialogueLines.Add("Me?");
        dialogueLines.Add("All of a sudden, the woman besides me bursts into tears. When she pulls her face out of her hands, I let out an inaudible gasp.");
        dialogueLines.Add("Her. I rack my brain for a name but she walks right through me as if I wasn’t even there. As if… I didn’t exist. I understand everything now.");
        dialogueLines.Add("I don’t let this revelation stop me. With as much courage as I can muster, I call out my lover by her name.");
        
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
            // added to skip cutscenes during testing, remove for prod
            SceneManager.LoadScene("Dark Scene");
            NextLine();
        }
    }
}