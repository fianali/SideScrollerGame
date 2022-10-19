using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Vector3 spawnPoint1, spawnPoint2, spawnPoint3;
    public GameObject[] monsters;

    private void Start()
    {
        StartCoroutine(SpawnRandomly());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnRandomly()
    {
        while (true)
        {
            //spawn a random monster at spawn points every 20 seconds
            yield return new WaitForSeconds(20f);
            int randomIndex1 = Random.Range(0, monsters.Length); 
            Instantiate(monsters[randomIndex1], spawnPoint1, Quaternion.identity);
            int randomIndex2 = Random.Range(0, monsters.Length);
            Instantiate(monsters[randomIndex2], spawnPoint2, Quaternion.identity);
            int randomIndex3 = Random.Range(0, monsters.Length); 
            Instantiate(monsters[randomIndex3], spawnPoint3, Quaternion.identity);

        }
    }
}
