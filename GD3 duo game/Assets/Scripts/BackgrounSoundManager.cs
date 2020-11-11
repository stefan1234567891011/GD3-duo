using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BackgrounSoundManager : MonoBehaviour
{
    [FMODUnity.EventRef]
    private FMOD.Studio.EventInstance Instance;
    public string fmodEvent;
    public float LOW_MedTrigger = 10;
    public float Med_HighTrigger = 20;
    public List<GameObject> list;
    private LaneCounter laneCounter;
    void Start() 
    {
        Instance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);

        Instance.start();
    }
    void Update()
    {
        int amount = 0;
        if(list.Count > 0)
        {
            for (int i = 0; i < list.Count; i++)
            {
                LaneRefrens laneRefrens = list[i].GetComponent<LaneRefrens>();

                GameObject lane = laneRefrens.Lane;
                laneCounter = lane.GetComponent<LaneCounter>();
                amount += laneCounter.Counter;
            }
        }
        
        if (amount<LOW_MedTrigger)
        {
            Instance.setParameterByName("Intensetie", 20f);
        }
        else if( amount<Med_HighTrigger)
        {
            Instance.setParameterByName("Intensetie", 50f);
        }
        else
        {
            Instance.setParameterByName("Intensetie", 80f);
        }
        
    }

}

