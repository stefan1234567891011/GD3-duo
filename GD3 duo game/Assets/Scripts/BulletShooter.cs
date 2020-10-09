using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    public float attackCooldown;
    public GameObject bullet;

    private float time;

    void Update()
    {
        time += Time.deltaTime;
        if (time >= attackCooldown)
        {
            GameObject temp = Instantiate(bullet);
            temp.transform.position = transform.position;
            temp.transform.parent = transform;
            time = 0;
        }
    }
}
