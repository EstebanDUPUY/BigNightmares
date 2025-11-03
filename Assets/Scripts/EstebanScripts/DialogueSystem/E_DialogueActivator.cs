/*
using Unity.Cinemachine;
using UnityEditor.Tilemaps;
using UnityEngine;

public class E_DialogueActivator : MonoBehaviour, E_IInteractable
{
    [SerializeField] E_DialogueObject dialogueObject;
    Transform player;
    [SerializeField] SpriteRenderer speechBubbleRenderer;

    void Start()
    {
        // speechBubbleRenderer = GetComponentInChildren<SpriteRenderer>();
        speechBubbleRenderer.enabled = false;
    }

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

    #region SPEECH BUBBLE + FLIP TO FACE PLAYER
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            // Speech Bubble On

            speechBubbleRenderer.enabled = true;

            // Find Player's Transform
            player = collision.gameObject.GetComponentInChildren<Transform>();

            // Check to see where Player is, and then turn towards him
            if (player.position.x > transform.position.x && transform.localScale.x < 0)
            {
                Flip();
            }
            else if (player.position.x < transform.position.x && transform.localScale.x > 0)
            {
                Flip();
            }
        }
    }

    void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
    }
    #endregion
}
*
*/