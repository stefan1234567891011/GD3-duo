using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealthHandler : MonoBehaviour
{
    public float health;
    private LaneCounter laneCounter;
    public UnityEvent OnCircleKilled = new UnityEvent();

    public AudioClip enemyHit;
    public AudioClip enemyDeath;
    private AudioSource audioSource;
    public float enemyHitVolume;
    public float enemyDeathVolume;

    void Start() 
    {
        LaneRefrens laneRefrens = gameObject.GetComponent<LaneRefrens>();

        GameObject lane = laneRefrens.Lane;
        laneCounter = lane.GetComponent<LaneCounter>();
        laneCounter.Counter ++;

        audioSource = GetComponent<AudioSource>();
        
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
                AudioSource.PlayClipAtPoint(enemyDeath, gameObject.transform.position, enemyDeathVolume);
                Destroy(gameObject);
            }
            else
            {
                audioSource.PlayOneShot(enemyHit, enemyHitVolume);
            }
        }
        else if(collision.gameObject.tag == "Wall")
        {
            laneCounter.Counter --;
            Destroy(gameObject);
            FindObjectOfType<GameManagers>().EndGame();
        }
    }
}
