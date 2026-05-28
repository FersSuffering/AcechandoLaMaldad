using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    private bool collected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !collected)
        {
            Player.instance.activeGun.GetAmmo();

            collected = true;

            DestroyAmmo();
        }
    }

    private void DestroyAmmo()
    {
        if (transform.parent.parent != null)
        {
            GameObject parentGO = transform.parent.parent.gameObject;
            Destroy(parentGO);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
