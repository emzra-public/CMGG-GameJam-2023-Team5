using UnityEngine;
using TMPro;

public class Cutscene1Text : MonoBehaviour
{
    public DialogueBox dialogueBox;

    private void CutScene1ShowText()
    {
        dialogueBox.UpdateDialogue("This is your dynamic text!");
        dialogueBox.ShowDialogue();
    }

    private void CutScene1HideText()
    {
        dialogueBox.HideDialogue();
    }
}