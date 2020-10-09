using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealthHandler : MonoBehaviour
{
    public float health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health += -1;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
