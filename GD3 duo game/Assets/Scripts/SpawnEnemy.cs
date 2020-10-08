using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject Enemy;
    public List<GameObject> spawnpoints;

    private float time;
    public float spawnCooldown;
    void Update()
    {
        time += Time.deltaTime;
        if (time >= spawnCooldown)
        {
            int rnd = Random.Range(0, spawnpoints.Count);
            GameObject spawnpoint = spawnpoints[rnd];

            GameObject temp = Instantiate(Enemy);
            temp.transform.position = spawnpoint.transform.position;
            temp.transform.parent = spawnpoint.transform;
            time = 0;
        }
    }
}
