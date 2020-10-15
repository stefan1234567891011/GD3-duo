using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthHandler : MonoBehaviour
{
    public float health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health += -1;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
        else if(collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
