using UnityEngine;

public class slimeMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Rigidbody2D targetrb;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private float jumpCoolCounter;

    private void Start()
    {
        targetrb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        animator.SetFloat("VelocityY", rb.velocity.y);

        if (jumpCoolCounter <= 0f)
        {
            Jump();
        }
        
        if (jumpCoolCounter > 0f)
        {
            jumpCoolCounter -= Time.deltaTime;
        }

        if(IsGrounded() && Mathf.Sign(Horizonta()) > 0f)
        {
            Vector3 localScale = transform.localScale;
            localScale.x = 1f;
            transform.localScale = localScale;
        }

        if (IsGrounded() && Mathf.Sign(Horizonta()) < 0f)
        {
            Vector3 localScale = transform.localScale;
            localScale.x = -1f;
            transform.localScale = localScale;
        }
    }

    private void Jump()
    {
        if (Mathf.Abs(Horizonta()) < 10)
        {
            rb.AddForce(new Vector2(Mathf.Sign(Horizonta() * -8), 7f), ForceMode2D.Impulse);

            FindObjectOfType<audioManager>().Play("SlimeJump");
            jumpCoolCounter = 2f;
        }
    }

    private float Horizonta()
    {
        return (rb.position.x - targetrb.position.x);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
