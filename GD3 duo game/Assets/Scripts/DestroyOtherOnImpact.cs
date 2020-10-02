using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOtherOnImpact : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("1");
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("2");
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("7");
    }
}
