using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject Object;
    public AudioClip notEnoughResources;
    public float notEnoughResourcesVolume;

    private bool onClickEnabled;
    public void OnClick()
    {
        if (onClickEnabled)
        {
            Instantiate(Object);
        }
        else
        {
            AudioSource.PlayClipAtPoint(notEnoughResources, gameObject.transform.position, notEnoughResourcesVolume);
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
