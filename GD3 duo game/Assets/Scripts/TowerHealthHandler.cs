using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealthHandler : MonoBehaviour
{
    public float health;

    public AudioClip towerHit;
    public AudioClip towerDeath;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health += -1;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            if (health <= 0)
            {
                AudioSource.PlayClipAtPoint(towerDeath, gameObject.transform.position);
                Destroy(gameObject);
            }
            else
            {
                audioSource.PlayOneShot(towerHit);
            }
        }
    }
}
