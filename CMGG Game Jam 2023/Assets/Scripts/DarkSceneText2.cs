using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DarkSceneText2 : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.03f;
    [SerializeField] private TextMeshProUGUI dialogueText;
    public GameObject dialoguePanel;

    private List<string> dialogueLines = new List<string>();
    private int currentLine = 0;
    private bool isTyping = false;
    SavePlayerPos playerPosData;


    private void Start()
    {
        /*        dialogueLines.Add("So… do you recognize her now?");
                dialogueLines.Add("…");
                StartCoroutine(TypeText(dialogueLines[currentLine]));
                Debug.Log("type text work");
        */
        dialoguePanel.SetActive(false);
    }


    public void Update()
    {
        if (Inventory.memories == 5)
        {
            dialoguePanel.SetActive(true);
            StartDialogue();
        }
    }

    void StartDialogue()
    {
        dialogueLines.Add("Hi baby… I’m so glad… I get to be with you in your… final moments… Now I can finally let you go with a peace of mind…");
        dialogueLines.Add("Haha… I guess I could sit here and go on about how I wish I had done things differently, but neither of us would benefit from that, would we? *hic*");
        dialogueLines.Add("I won’t take up any more of your time. I know your body can only handle so much and it’s time for you to go but… but I truly hope we get to grow old together… in another life… my… beloved…………");
        Debug.Log("type text work");
    }

    public void EndDialogue()
    {
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
                gameObject.SetActive(false);
                GameObject.Find("Unknown Dialogue Box").SetActive(false);
                Debug.Log("Unknown dialogue box disappears");
            }
        }
    }

    /*    private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                // added to skip cutscenes during testing, remove for prod
                SceneManager.LoadScene("Dark Scene");
                NextLine();
            }
        }*/
}