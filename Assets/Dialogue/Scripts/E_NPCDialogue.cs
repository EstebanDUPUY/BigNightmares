using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Rendering;

public class E_NPCDialogue : MonoBehaviour
{
    public E_AdvancedDialogueSO[] conversation; 

    Transform player;
    SpriteRenderer speechBubbleRenderer;
    E_AdvancedDialogueManager advancedDialogueManager;

    bool dialogueInitiated;

    void Start()
    {
        advancedDialogueManager = GameObject.Find("DialogueManager").GetComponent<E_AdvancedDialogueManager>(); 
        speechBubbleRenderer = GetComponent<SpriteRenderer>();
        speechBubbleRenderer.enabled = false;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !dialogueInitiated)
        {
            // Speech Bubble On
            speechBubbleRenderer.enabled = true;
            // Find the player's transform
            player = collision.gameObject.GetComponent<Transform>();
            // Check to see where player is, and then turn towards them
            if (player.position.x > transform.position.x && transform.parent.localScale.x < 0)
            {
                Flip();
            }
            else if (player.position.x < transform.position.x && transform.localScale.x > 0)
            {
                Flip();
            }

            advancedDialogueManager.InitiateDialogue(this);
            dialogueInitiated = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Speech Bubble Off
            speechBubbleRenderer.enabled = false;
            advancedDialogueManager.TurnOffDialogue();
            dialogueInitiated = false;
        }
    }

    void Flip()
    {
        Vector3 currentScale = transform.parent.localScale;
        currentScale.x *= -1; 
        transform.localScale = currentScale;
    }
}
