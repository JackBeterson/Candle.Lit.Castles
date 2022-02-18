using UnityEngine;
using UnityEngine.InputSystem;

public class playerDash : MonoBehaviour
{
    [SerializeField] private UnityEngine.Experimental.Rendering.Universal.Light2D candle;
    [SerializeField] private GameObject dashHitbox;
    [SerializeField] private GameObject playerHurtbox;
    [SerializeField] private ParticleSystem dashTrail;
    [SerializeField] private Renderer render;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Color red;
    [SerializeField] private Color blue;

    private bool dashReady = true;
    public bool hasTouchedGround = true;
    public float dashPower = 1f;
    private float dashCoolCounnter;

    void Update()
    {
        if (dashCoolCounnter < 0f && hasTouchedGround)
        {
            dashReady = true;
            candle.color = red;
            render.material.SetColor("_Color", red);
        }

        if (dashCoolCounnter > 0f)
        {
            dashCoolCounnter -= Time.deltaTime;
        }
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if (context.performed && dashReady)
        {
            rb.velocity = new Vector2(10f * dashPower, 0f);

            rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;

            GetComponent<playerMovement>().enabled = false;
            dashHitbox.SetActive(true);
            playerHurtbox.SetActive(false);

            animator.SetBool("Dash", true);
            hasTouchedGround = false;
            dashReady = false;

            dashTrail.Play();
            candle.color = blue;
            render.material.SetColor("_Color", blue);

            dashCoolCounnter = 1.25f;
            Invoke("DashReset", .25f);
        }
    }

    private void DashReset()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        GetComponent<playerMovement>().enabled = true;
        dashHitbox.SetActive(false);
        playerHurtbox.SetActive(true);

        animator.SetBool("Dash", false);
        
        dashTrail.Stop();
    }
}
