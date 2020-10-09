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
            if(spawnpoints.Count <1)return;
            int rnd = Random.Range(0, spawnpoints.Count);
            GameObject spawnpoint = spawnpoints[rnd];

            GameObject temp = Instantiate(Enemy);
            temp.transform.position = new Vector3(spawnpoint.transform.position.x,spawnpoint.transform.position.y,spawnpoint.transform.position.z-1);
           
            temp.transform.parent = transform;
            time = 0;
        }
    }
}
