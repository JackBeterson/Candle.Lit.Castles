using UnityEngine;

public class slimeHealth : MonoBehaviour
{
    [SerializeField] private ParticleSystem slimeDeath;
    [SerializeField] private GameObject slime;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "PlayerDMG")
        {
            Death();
        }

        if (col.gameObject.tag == "InstaDMG")
        {
            Death();
        }
    }

    private void Death()
    {
        FindObjectOfType<audioManager>().Play("Death");
        slimeDeath.Play();
        GetComponent<slimeMovement>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        Invoke("Delete", 1f);
    }

    private void Delete()
    {
        Destroy(slime);
    }
}
