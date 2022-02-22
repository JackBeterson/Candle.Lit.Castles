using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lockedDoor : MonoBehaviour
{
    public bool opened = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerDMG" && opened)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
