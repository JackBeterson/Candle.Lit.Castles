using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private bool dashing = false;
    private bool isFacingRight = true;


    private float speed = 3.5f;
    private float jumpingPower = 7f;
    private float dashCoolCounnter;
    private float dashPower = 2.8f;
    private float horizontal;
    private float fixedH;

    void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        animator.SetFloat("HorizontalV", Mathf.Abs(horizontal));
        animator.SetFloat("VerticalV", rb.velocity.y);
        animator.SetBool("Dash", dashing);

        /*if (dashCoolCounnter < 0f && hasTouchedGround)
        {
            dashReady = true;
        }

        if (dashCoolCounnter > 0f)
        {
            dashCoolCounnter -= Time.deltaTime;
        }
        */
        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }
        /*
        if (dashReady == true)
        {
            candle.color = red;
            render.material.SetColor("_Color", red);
        }

        if (IsGrounded())
        {
            hasTouchedGround = true;
        }*/
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        fixedH = context.ReadValue<Vector2>().x;

        if (!dashing)
        {
            horizontal = context.ReadValue<Vector2>().x;
        }
    }
}
