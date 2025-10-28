
using UnityEngine;

public class DialogueTrigger : MonoBehaviour, E_IInteractable
{

    [SerializeField] E_DialogueManager dialogueManager;
    [SerializeField] E_DialogueSO dialogue;

    public string GetDescription()
    {
        return "Talk to Bob";
    }

    public void Interact()
    {
        dialogueManager.BeginDialogue(dialogue);
    }
}
