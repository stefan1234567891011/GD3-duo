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
            GameObject oject = Instantiate(bullet);
            oject.transform.position = transform.position;
            oject.transform.parent = transform;
            time = 0;
        }
    }
}
