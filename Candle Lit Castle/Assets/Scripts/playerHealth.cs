using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    [SerializeField] private ParticleSystem playerDeath;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playerHurtbox;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject wick;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer sprite;
    

    private float health = 3;
    public float knockbackPower = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Insta")
        {
            Death();
        }
        else if (other.tag == "OneDMG")
        {
            Damage();
        }
    }

    private void Damage()
    {
        GetComponent<playerMovement>().enabled = false;
        playerHurtbox.SetActive(false);

        StartCoroutine(DamageFlicker());

        rb.velocity = new Vector2(-2.5f * knockbackPower, 5f);

        animator.SetBool("Hurt", true);
        Invoke("DamageReset", .5f);
        Invoke("Hurtbox", 2.5f);

        health = health - 1;
        slider.value = health;

        if (health == 2)
        {
            wick.SetActive(true);
        }

        if (health == 0)
        {
            Invoke("Death", 0f);
        }
    }

    private void DamageReset()
    {
        GetComponent<playerMovement>().enabled = true;
        animator.SetBool("Hurt", false);
    }

    private void Hurtbox()
    {
        playerHurtbox.SetActive(true);
        StopCoroutine(DamageFlicker());
    }

    private void Death()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        GetComponent<SpriteRenderer>().enabled = false;
        wick.SetActive(false);
        slider.value = 0f;
        playerDeath.Play();
 
        Invoke("RestartLevel", 1f);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator DamageFlicker()
    {
        for(int i = 0; i < 3f; i++)
        {
            sprite.color = new Color(1f, 1f, 1f, .5f);
            yield return new WaitForSeconds(.1f);
            sprite.color = Color.white;
            yield return new WaitForSeconds(.1f);
        }
    }
    
}
