using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueQnA : MonoBehaviour
{
    public DialogueSO dialogueSo;

    TextMeshProUGUI textMeshProUGUI;

    public int currentSequence;
    public int dialogueIndex;

    public List<GameObject> buttons = new();

    public E_PlayerController playerController;

    public void MoveToNextDialogue()
    {
        ReadDialogue(dialogueSo.dialogueContainer[currentSequence]);
    }


    public void ReadDialogue(Dialogue dialogue) 
    {
        textMeshProUGUI.text = dialogue.dialogueContent[dialogueIndex];
        if (dialogueIndex < dialogue.dialogueContent.Count - 1)
        {
            dialogueIndex++;
        }
        else 
        {
            LaunchAnswer( dialogue);
            StartCoroutine(TimerAnswer(dialogue));
        }
    }

    public void LaunchAnswer(Dialogue dialogue) 
    {
        for (int i = 0; i < dialogue.answer.Count-1; i++) 
        {
            buttons[i].SetActive(true);
        }
    }

    public IEnumerator TimerAnswer(Dialogue dialogue) 
    {
        yield return new WaitForSecondsRealtime(dialogue.answerTimer);
        playerController.negativePoint += dialogue.noAnswerPoints;
    }
}


