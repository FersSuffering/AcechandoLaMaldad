using System.Collections;
using UnityEngine;

public class HordeSpawnerCoroutine : MonoBehaviour
{
    public GameObject enemyToSpawn;

    public int enemiesPerHorde = 5;
    public float timeBetweenSpawns = 1f;
    public float timeBetweenHordes = 20f;

    void Start()
    {
        StartCoroutine(SpawnHordesRoutine());
    }

    IEnumerator SpawnHordesRoutine()
    {
        while (true)
        {
            for (int i = 0; i < enemiesPerHorde; i++)
            {
                Instantiate(enemyToSpawn, transform.position, transform.rotation);
                yield return new WaitForSeconds(timeBetweenSpawns);
            }

            yield return new WaitForSeconds(timeBetweenHordes);
        }
    }
}