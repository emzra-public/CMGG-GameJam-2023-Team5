using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CutsceneText3 : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.04f;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private List<string> dialogueLines = new List<string>();
    private int currentLine = 0;
    private bool isTyping = false;
    SavePlayerPos playerPosData;


    private void Start()
    {
        dialogueLines.Add("I always knew I wanted to marry her. I think she knew, too.");
/*        dialogueLines.Add("I’m not usually the best at reading faces, but after taking her hand into mine, and mustering the words out of my mouth... even I could tell her surprise was feigned.");
        dialogueLines.Add("But that hardly mattered at the time. We began planning immediately, and ultimately, our hard work paid off. The wedding was a success.");
        dialogueLines.Add("Tonight, I hold my eternal bride close, in the living room we’ve always wanted, and recall the night I got down on one knee and professed my love. Not even halfway through my recollection, she erupts into a fit of giggles.");
        dialogueLines.Add("“What’s so funny?” I cry out, incredulous.");
        dialogueLines.Add("“I still can’t believe you left the ring out on the dining table the day before.” Her tone is genuine, but all I can do is stare in absolute disbelief. “That’s why I wasn’t shocked when you proposed, silly!”");
        dialogueLines.Add("She laughs as if she didn’t just turn my own world upside down before shifting her attention back to the TV and returning into my arms. ");
        dialogueLines.Add("The worst part is that I literally have no recollection of that. Was I really that absentminded?");
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
                SceneManager.LoadScene("Dark Scene");

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