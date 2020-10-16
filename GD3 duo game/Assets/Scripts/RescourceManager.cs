using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RescourceManager : MonoBehaviour
{
    public int resources = 100;

    public void OnCircleKilled()
    {
        Debug.Log("OK");
        resources += 10;
    }
}
