using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    public List<GameObject> spawnpoints;

    public float time;
    public float spawnCooldown;

    public int wave = 1;
    public int amountOfCircles = 1;
    public int amountOfOvals = 0;
    public float waveTime = 10;
    public float breakTime = 5;
    public bool waveBusy = true;

    public int amountOfCirclesLeft;
    public int amountOfOvalsLeft;
    public float circleTime;
    public float ovalTime;
    public float circleTimer;
    public float ovalTimer;

    private void Start()
    {
        amountOfCirclesLeft = amountOfCircles;
        amountOfOvalsLeft = amountOfOvals;
        circleTime = (waveTime - 1) / amountOfCircles;
        ovalTime = (waveTime - 1) / amountOfOvals;
    }

    void Update()
    {
        if (spawnpoints.Count >= 1)
        {
            time += Time.deltaTime;
            circleTimer += Time.deltaTime;
            ovalTimer += Time.deltaTime;

            if (waveBusy)
            {
                if (circleTimer >= circleTime && amountOfCirclesLeft >= 0)
                {
                    SpawnUnit(enemy);
                    amountOfCirclesLeft--;
                    circleTimer = 0;
                }
                if (ovalTimer >= ovalTime && amountOfOvalsLeft >= 0)
                {
                    SpawnUnit(enemy);
                    amountOfOvalsLeft--;
                    ovalTimer = 0;
                }
                if (time >= waveTime)
                {
                    wave++;
                    amountOfCircles++;
                    if (wave % 3 == 0)
                    {
                        amountOfOvals++;
                    }
                    waveBusy = false;
                    time = 0;
                }
            }
            else
            {
                if (time >= breakTime)
                {
                    amountOfCirclesLeft = amountOfCircles;
                    amountOfOvalsLeft = amountOfOvals;
                    circleTime = (waveTime - 1) / amountOfCircles;
                    ovalTime = (waveTime - 1) / amountOfOvals;
                    waveBusy = true;
                    time = 0;
                    circleTimer = 0;
                    ovalTimer = 0;
                }
            }
        }
    }

    private void SpawnUnit(GameObject unit)
    {
        if (spawnpoints.Count >= 1)
        {
            int rnd = Random.Range(0, spawnpoints.Count);
            GameObject spawnpoint = spawnpoints[rnd];

            GameObject temp = Instantiate(unit);
            temp.transform.position = spawnpoint.transform.position + new Vector3(0, 0, -1);

            temp.transform.parent = transform;
            LaneRefrens lanerefspawnpoint = spawnpoint.GetComponent<LaneRefrens>();
            LaneRefrens lanerefunit = temp.GetComponent<LaneRefrens>();
            lanerefunit.Lane = lanerefspawnpoint.Lane;
        }
    }
}
