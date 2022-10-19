using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint1, spawnPoint2, spawnPoint3;
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
            int randomIndex1 = Random.Range(0, monsters.Length); 
            var copy = Instantiate(monsters[randomIndex1], spawnPoint1.position, Quaternion.identity);
            int randomIndex2 = Random.Range(0, monsters.Length);
            var copy2 = Instantiate(monsters[randomIndex2], spawnPoint2.position, Quaternion.identity);
            int randomIndex3 = Random.Range(0, monsters.Length);
            var copy3 =Instantiate(monsters[randomIndex3], spawnPoint3.position, Quaternion.identity);
            yield return new WaitForSeconds(20f);
    
        }
    }
}
