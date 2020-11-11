using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnObject : MonoBehaviour
{
    public GameObject Object;
    public Text resourceText;

    public AudioClip notEnoughResources;
    private AudioSource audioSource;

    private bool onClickEnabled;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnClick()
    {
        if (onClickEnabled)
        {
            Instantiate(Object);
        }
        else
        {
            audioSource.PlayOneShot(notEnoughResources);
            resourceText.GetComponent<Animator>().Play("NotEnoughResourcesAnimation");
        }
    }

    public void EnableOnClick()
    {
        onClickEnabled = true;
    }
    public void DisableOnClick()
    {
        onClickEnabled = false;
    }
}
