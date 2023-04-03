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


    private void Start()
    {
        dialogueLines.Add("Hello, wanderer. ");
/*        dialogueLines.Add("You appear to be a faraways from home.");
        dialogueLines.Add("Allow me to guide you on your journey. The path beyond has been cleared for your arrival. Go forth, towards the light.");
        dialogueLines.Add("Hurry! Before it’s too late…!");
*/
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
                //SceneManager.LoadScene("Dark Scene");

            }
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // added to skip cutscenes during testing, remove for prod
            //SceneManager.LoadScene("Dark Scene");
            NextLine();

        }
    }
}