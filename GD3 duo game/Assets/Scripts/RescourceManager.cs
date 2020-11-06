using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RescourceManager : MonoBehaviour
{
    public static int resources = 100;

    public int startingResources = 100;
    public int Tower1Cost = 100;
    public int resourcePerEnemyKilled = 100;

    public string resourceName = "resource";
    public Text resourceText;
    public Button Tower1Button;

    private void Start()
    {
        resources = startingResources;
        UpdateUI();
    }

    private void Update()
    {
        UpdateUI();
    }

    public void OnCircleKilled()
    {
        resources += resourcePerEnemyKilled;
    }

    public void TurretBought(int cost)
    {
        resources -= cost;
    }

    private void UpdateUI()
    {
        resourceText.text = resourceName + ": " + resources.ToString();
        if (Tower1Button.GetComponent<SpawnObject>() != null)
        {
            if (resources >= Tower1Cost)
            {
                Tower1Button.enabled = true;
                Tower1Button.GetComponent<SpawnObject>().EnableOnClick();
            }
            else
            {
                Tower1Button.enabled = false;
                Tower1Button.GetComponent<SpawnObject>().DisableOnClick();
            }
        }
    }
}
