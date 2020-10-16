using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    public float attackCooldown;
    public GameObject bullet;
    private LaneCounter laneCounter;

    private float time;

    void Start()
    {
        LaneRefrens laneRefrens = gameObject.GetComponent<LaneRefrens>();

        GameObject lane = laneRefrens.Lane;
        laneCounter = lane.GetComponent<LaneCounter>();
    }
    void Update()
    {
        time += Time.deltaTime;
        if (time >= attackCooldown && laneCounter.Counter > 0)
        {
            GameObject temp = Instantiate(bullet);
            temp.transform.position = transform.position;
            temp.transform.parent = transform;
            time = 0;
        }
    }
}
