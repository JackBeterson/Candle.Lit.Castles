using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    [SerializeField] private ParticleSystem playerDeath;
    [SerializeField] private GameObject player;
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject wick;

    private float health = 3;

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
        health = health - 1;
        slider.value = health;

        if (health == 2)
        {
            wick.SetActive(true);
        }

        if (health <= 0)
        {
            Invoke("Death", 0f);
        }
    }

    private void Death()
    {
        GetComponent<playerMovement>().enabled = false;
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
}
