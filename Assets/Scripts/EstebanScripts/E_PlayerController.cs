using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.InputSystem;

public class E_PlayerController : MonoBehaviour
{
    [Header("Movement Variables")]
    Rigidbody2D rb;
    [SerializeField] float moveSpeed = 5f;
    //
    float horizontalMovement;

/*
    [Header("Dialogue Variables")]
    // Reference to the E_DialogueUI script
    [SerializeField] E_DialogueUI dialogueUI;
    public E_DialogueUI DialogueUI => dialogueUI; 
    // get E_IInteractable
    public E_IInteractable Interactable {  get; set; }
    // 
    public bool isChatting;
    public bool isReadyToChat;
*/

    //
    public int positivePoint;
    public int negativePoint;

    public Animator animator;

    public SpriteRenderer spriteRenderer;


    #region START, UPDATE, ETC . . .
    void Start()
    {
        // Movement Rigidbody
        rb = GetComponent<Rigidbody2D>();
        // Animator
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Flip();
    }

    void FixedUpdate()
    {
        // Movement Maths
        rb.linearVelocity = new Vector2(horizontalMovement * moveSpeed, rb.linearVelocity.y);
    }
    #endregion

    #region MOVEMENT
    public void MoveInput(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            horizontalMovement = ctx.ReadValue<Vector2>().x ;
        if (ctx.canceled)
            horizontalMovement = 0;

        if (moveSpeed !=0)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
    }
    // Just in case we need to prevent player from moving
    public bool ToggleMovement(bool var)
    {
        if (var)
            moveSpeed = 0;
        return var;
        
    }
    #endregion

    private void Flip()
    {
        if (horizontalMovement < 0)
        {
            spriteRenderer.flipX = true;
        }


    }
    //#region DIALOGUE
    //// si la chatbox est ouverte, je demande � passer � la suite / SI on appuie sur a et que la chatbox est ouverte
    // public void InteractInput(InputAction.CallbackContext ctx)
    // {
    //    if (dialogueUI.isOpen) return;

    //    if (ctx.started)
    //    {
    //        /*
    //        if (isChatting && dialogueUI.dialogueBox.activeInHierarchy == true) // If the chatbox is open 
    //        {
    //            isReadyToChat = true; 
    //            dialogueUI.ShowDialogue(dialogueUI.testDialogue); // Begin the dialogue
    //        }
    //        else // If the chatbox is closed
    //        {
    //            dialogueUI.dialogueBox.SetActive(true); // Open ChatBox
    //        }
    //        */
    //        Interactable?.Interact(this);
    //    }
    // }
    //#endregion  
}
