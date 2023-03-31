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
        dialogueLines.Add("I close my eyes and take a deep breath. The air is so crisp and fresh up here in the mountains... When I re-open my eyes, I can�t help but stand still in awe. I�ve never seen so many flowers in one place before... ");
        dialogueLines.Add("At this point, I hardly mind waiting for her to come back. I know I just met her today, but she seems pretty cool. I wonder if she would want to be my friend�");
        dialogueLines.Add("�Sooo,� she calls out in a sing-song voice, snapping me back into this reality. �I didn�t find any water buuut I did find this!� Bemused, I watch as she reaches up to place a perfectly woven flower crown onto my head.");
        dialogueLines.Add("�Where did you-� �Hey, stranger!� she interrupts. Her face twists up into an all-knowing smile and her eyes glitter with intent. �You look pretty cute with that on. Keep it!�");
        dialogueLines.Add("A blush creeps up onto my face, and I furiously look away. �Y-you know, I�d rather not die of thirst right now so, ummm� let�s keep moving�!�");
        

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