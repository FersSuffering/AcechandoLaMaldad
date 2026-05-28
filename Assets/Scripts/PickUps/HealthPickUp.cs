using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public int heal;

    public AudioClip healClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioSource playerAudio = other.GetComponent<AudioSource>();
            playerAudio.PlayOneShot(healClip);

            PlayerHealth.instance.HealPlayer(heal);

            DestroyHealth();
        }
    }

    private void DestroyHealth()
    {
        if (transform.parent != null)
        {
            GameObject parentGO = transform.parent.gameObject;
            Destroy(parentGO);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
