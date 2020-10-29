using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealthHandler : MonoBehaviour
{
    public float health;
    public UnityEvent OnCircleKilled = new UnityEvent();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 1;
            if (health <= 0)
            {
                OnCircleKilled.Invoke();
                Destroy(gameObject);
            }
        }
        else if(collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
