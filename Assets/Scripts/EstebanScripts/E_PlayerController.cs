using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.InputSystem;

public class E_PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float moveSpeed = 5f;

    float horizontalMovement;

    //
    [SerializeField] E_DialogueUI dialogueUI;
    //
    public bool isChatting;
    public bool isReadyToChat;
    //

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalMovement * moveSpeed, rb.linearVelocity.y);
    }

    public void MoveInput(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            horizontalMovement = ctx.ReadValue<Vector2>().x ;
        if (ctx.canceled)
            horizontalMovement = 0;
    }
    // si la chatbox est ouverte, je demande à passer à la suite / SI on appuie sur a et que la chatbox est ouverte
    public void InteractInput(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if (isChatting)
            {
                isReadyToChat = true;
                dialogueUI.ShowDialogue(dialogueUI.testDialogue);
            }
            else
            {
                dialogueUI.dialogueBox.SetActive(true); // Open ChatBox
            }
        }
    }

    public bool ToggleMovement(bool var)
    {
        if (var)
            moveSpeed = 0;
        return var; 
    }
}
