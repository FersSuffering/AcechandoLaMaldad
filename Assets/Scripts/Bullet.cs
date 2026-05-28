using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed, lifeTime;
    public int damage;

    public bool damageEnemy, damagePlayer;

    public Rigidbody theRigidBody;

    void Start()
    {
        
    }

    void Update()
    {
        theRigidBody.velocity = transform.forward * bulletSpeed;

        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            DestroyBullet();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && damageEnemy)
        {
            other.gameObject.GetComponent<EnemyHealth>().DamageEnemy(damage, false);
        }

        if (other.gameObject.tag == "Head" && damageEnemy)
        {
            other.transform.parent.gameObject.GetComponent<EnemyHealth>().DamageEnemy(damage * 2, true);
        }

        if (other.gameObject.tag == "Player" && damagePlayer)
        {
            PlayerHealth.instance.DamagePlayer(damage);
        }

        DestroyBullet();  
    }

    private void DestroyBullet()
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
