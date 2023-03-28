using UnityEngine;
using UnityEngine.UI; // Add this line if you're using UI.Text
using TMPro; // Add this line if you're using TextMeshPro

public class DialogueBox : MonoBehaviour
{
    public GameObject panel; // Assign your Panel object here
    public TextMeshProUGUI dialogueText; // Assign your Text object here, or use TextMeshProUGUI if you're using TextMeshPro

    private void Start()
    {
        panel.SetActive(false); // Hide the dialogue box at the beginning
    }

    public void UpdateDialogue(string text)
    {
        dialogueText.text = text; // Set the dialogue text
    }

    public void ShowDialogue()
    {
        panel.SetActive(true); // Show the dialogue box
    }

    public void HideDialogue()
    {
        panel.SetActive(false); // Hide the dialogue box
    }
}