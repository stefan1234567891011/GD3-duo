using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject Object;
    public void OnClick()
    {
        //Debug.Log("test");
         GameObject temp = Instantiate(Object);
    }
}
