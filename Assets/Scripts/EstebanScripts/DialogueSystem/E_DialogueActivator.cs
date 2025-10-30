using Unity.Cinemachine;
using UnityEngine;

public class E_DialogueActivator : MonoBehaviour, E_IInteractable
{
    [SerializeField] E_DialogueObject dialogueObject;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out E_PlayerController player))
        {
            player.Interactable = this;
        }  
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out E_PlayerController player))
        {
            if (player.Interactable is E_DialogueActivator dialogueActivator && dialogueActivator == this)
            {
                player.Interactable = null;
            }
        }
    }
        
    public void Interact(E_PlayerController player)
    {
        player.DialogueUI.ShowDialogue(dialogueObject);
    }
}
