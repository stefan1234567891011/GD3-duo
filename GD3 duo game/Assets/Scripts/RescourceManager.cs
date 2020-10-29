using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RescourceManager : MonoBehaviour
{
    public static int resources = 100;

    public string resourceName = "resource";
    public Text resourceText;

    private void Update()
    {
        UpdateUI();
    }

    public void OnCircleKilled()
    {
        resources += 10;
    }

    private void UpdateUI()
    {
        resourceText.text = resourceName + ": " + resources.ToString();
    }
}
