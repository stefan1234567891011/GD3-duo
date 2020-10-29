using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject Object;

    private bool onClickEnabled;
    public void OnClick()
    {
        if (onClickEnabled)
        {
            Instantiate(Object);
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
