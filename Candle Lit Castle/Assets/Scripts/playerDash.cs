using UnityEngine;
using UnityEngine.InputSystem;

public class playerDash : MonoBehaviour
{
    [SerializeField] private UnityEngine.Experimental.Rendering.Universal.Light2D candle;
    [SerializeField] private GameObject dashHitbox;
    [SerializeField] private ParticleSystem dashTrail;
    [SerializeField] private Renderer render;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Color red;
    [SerializeField] private Color blue;
    private bool dashReady = true;
    private bool hasTouchedGround = true;
    private float dashpower = 5f;

    void Update()
    {
        
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if (context.performed && dashReady)
        {
            rb.AddForce(new Vector2(Mathf.Sign(dashpower), 0f), ForceMode2D.Impulse);

            rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;

            GetComponent<playerMovement>().enabled = false;

            /*dashHitbox.SetActive(true);
            hasTouchedGround = false;
            dashing = true;
            dashReady = false;
            dashCoolCounnter = 1.25f;

            candle.color = blue;
            dashTrail.Play();
            render.material.SetColor("_Color", blue);
            
            Invoke("DashReset", .25f);

            if (isFacingRight)
            {
                horizontal = dashPower;
            }
            else if (!isFacingRight)
            {
                horizontal = -dashPower;
            }*/
        }
    }

    private void DashReset()
    {
        /*dashing = false;
        horizontal = fixedH;
        dashTrail.Stop();
        dashHitbox.SetActive(false);
        */
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        GetComponent<playerMovement>().enabled = true;
    }
}
