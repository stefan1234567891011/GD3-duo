using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealthHandler : MonoBehaviour
{
    public float health;

    public AudioClip towerHit;
    public AudioClip towerDeath;
    private AudioSource audioSource;

    private Animator animator;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health += -1;
            if (health <= 0)
            {
                audioSource.PlayOneShot(towerDeath);

                animator.Play("TowerDeathAnimation");
                Destroy(gameObject, 1);
            }
            else
            {
                audioSource.PlayOneShot(towerHit);
                animator.Play("TowerHitAnimation");
            }
        }
    }
}
