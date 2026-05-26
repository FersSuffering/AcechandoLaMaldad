using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private EnemyMove enemy;
    public int currentHealth;

    public bool IsGunDisabled { get; private set; } = false;
    private float gunDisableDuration = 0.6f;

    private void Start()
    {
        enemy = GetComponent<EnemyMove>();
    }

    public void DamageEnemy(int damage, bool isHead)
    {
        enemy.agent.destination = transform.position;

        if (currentHealth <= 0) return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            StartCoroutine(Die());
        }
        else
        {
            StartCoroutine(TemporaryDisableGun(isHead));
        }
    }

    IEnumerator TemporaryDisableGun(bool isHead)
    {
        IsGunDisabled = true;

        Transform gun = transform.Find("USP");
        if (gun != null) gun.gameObject.SetActive(false);

        if (isHead)
        {
            enemy.animator.SetTrigger("hitHead");
        }
        else
        {
            enemy.animator.SetTrigger("hit");
        }

        yield return new WaitForSeconds(gunDisableDuration);

        if (currentHealth > 0)
        {
            IsGunDisabled = false;
        }
    }

    IEnumerator Die()
    {
        IsGunDisabled = true;
        Transform gun = transform.Find("USP");
        if (gun != null) gun.gameObject.SetActive(false);

        if (enemy != null)
        {
            enemy.enabled = false;
            enemy.animator.SetBool("isDead", true);
        }

        if (GetComponent<Collider>() != null) GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(3.4f);

        Destroy(gameObject);
    }
}