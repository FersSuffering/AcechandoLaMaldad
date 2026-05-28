using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public int heal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
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
