using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private bool isFacingRight = true;

    private float speed = 3.5f;
    private float jumpingPower = 7f;
    private float horizontal;

    void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        animator.SetFloat("HorizontalV", Mathf.Abs(horizontal));
        animator.SetFloat("VerticalV", rb.velocity.y);

        if (IsGrounded())
        {
            GameObject.Find("Player").GetComponent<playerDash>().hasTouchedGround = true;
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
        GameObject.Find("Player").GetComponent<playerDash>().dashPower = horizontal;
        GameObject.Find("Player").GetComponent<playerHealth>().knockbackPower = horizontal;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;

        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }
    }
}
