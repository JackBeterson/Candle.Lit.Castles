using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashOrb : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerDMG")
        {
            GameObject.Find("Player").GetComponent<playerDash>().enabled = true;
            Destroy(GameObject.Find("Dash Orb"));
        }
    }
}
