using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.InputSystem;

public class E_PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float moveSpeed = 5f;

    float horizontalMovement;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
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

    public bool ToggleMovement(bool var)
    {
        if (var)
            moveSpeed = 0;
        return var; 
    }
}
