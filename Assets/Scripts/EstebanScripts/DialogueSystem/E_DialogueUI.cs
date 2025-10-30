using System.Collections;
using UnityEngine;
using TMPro;

public class E_DialogueUI : MonoBehaviour
{
    [SerializeField] TMP_Text textLabel;
    public GameObject dialogueBox;
    public E_DialogueObject testDialogue;

    public bool isOpen {  get; private set; }

    [Header("Scripts References")]
    [SerializeField] E_PlayerController playerController;
    E_ResponseHandler responseHandler;
    E_TypeWriterEffect typeWriterEffect;
    void Start()
    {
        typeWriterEffect = GetComponent<E_TypeWriterEffect>();
        responseHandler = GetComponent<E_ResponseHandler>();
        // ShowDialogue(testDialogue);
        CloseDialogueBox();
    }

    public void ShowDialogue(E_DialogueObject dialogueObject)
    {
       isOpen = true;
       dialogueBox.SetActive(true);
       playerController.isReadyToChat = false;
       StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    IEnumerator StepThroughDialogue(E_DialogueObject dialogueObject)
    {
        //foreach (string dialogue in dialogueObject.Dialogue)
        //{
        //    yield return typeWriterEffect.Run(dialogue, textLabel);
        //    yield return playerController.isReadyToChat;
        //}

        for (int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];
            yield return typeWriterEffect.Run(dialogue, textLabel);

            if (i == dialogueObject.Dialogue.Length - 1 && dialogueObject.HasResponses) break; 

            yield return playerController.isReadyToChat;
        }

        if (dialogueObject.HasResponses)
        {
            responseHandler.ShowResponses(dialogueObject.Responses);
        }
        else
            CloseDialogueBox();
    }

    void CloseDialogueBox()
    {
        isOpen = false;
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
