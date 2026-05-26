using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    private Vector3 target;
    public NavMeshAgent agent;
    private EnemyHealth enemyHealth;

    public GameObject bullet;
    public Transform firePoint;

    public Animator animator;

    public float distanceToStop;

    public float fireRate = 0.5f;
    private float fireCount;

    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
    }

    void Update()
    {
        if (Player.instance == null) return;

        target = Player.instance.transform.position;
        transform.LookAt(target);

        if (Vector3.Distance(transform.position, target) > distanceToStop)
        {
            // Chase
            agent.destination = target;

            if (!enemyHealth.IsGunDisabled) 
            { 
                transform.Find("USP").gameObject.SetActive(false);
            }

            animator.SetBool("isWalking", true);
            fireCount = 0f; 
        }
        else
        {
            // Stop and Shoot
            agent.destination = transform.position;
            animator.SetBool("isWalking", false);

            if (enemyHealth != null && !enemyHealth.IsGunDisabled)
            {
                transform.Find("USP").gameObject.SetActive(true);
                HandleShooting();
            }
            else
            {
                transform.Find("USP").gameObject.SetActive(false);
            }
        }
    }

    private void HandleShooting()
    {
        fireCount -= Time.deltaTime;

        if (fireCount <= 0)
        {
            fireCount = fireRate;
            firePoint.transform.LookAt(target);

            animator.SetTrigger("shoot");
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }
    }
}