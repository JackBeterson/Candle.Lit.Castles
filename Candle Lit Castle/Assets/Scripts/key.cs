using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerDMG")
        {
            Collected();
        }
    }

    private void Collected()
    {
        GameObject.Find("LockedDoor").GetComponent<lockedDoor>().opened = true;
        GameObject.Find("Door").SetActive(false);
        Destroy(GameObject.Find("Key"));
    }
}
