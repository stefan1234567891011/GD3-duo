using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BackgrounSoundManager : MonoBehaviour
{
    [FMODUnity.EventRef]
    private FMOD.Studio.EventInstance Instance;
    public string fmodEvent;
    void Start() 
    {
        Instance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
        Instance.start();
    }
    void Update()
    {
        Instance.setParameterByName("Intensetie", 100f);
    }

}

