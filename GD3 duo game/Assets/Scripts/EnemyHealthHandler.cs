using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealthHandler : MonoBehaviour
{
    public float health;
    private LaneCounter laneCounter;
    public UnityEvent OnCircleKilled = new UnityEvent();

    void Start() 
    {
        LaneRefrens laneRefrens = gameObject.GetComponent<LaneRefrens>();

        GameObject lane = laneRefrens.Lane;
        laneCounter = lane.GetComponent<LaneCounter>();
        laneCounter.Counter ++;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 1;
            if (health <= 0)
            {
                laneCounter.Counter --;
                OnCircleKilled.Invoke();
                Destroy(gameObject);
            }
        }
        else if(collision.gameObject.tag == "Wall")
        {
            laneCounter.Counter --;
            Destroy(gameObject);
        }
    }
}
