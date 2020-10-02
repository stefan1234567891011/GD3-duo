using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mapGenerate : MonoBehaviour
{
    public Image tilePrefab;
    public int mapWith = 3;
    public int mapHeight = 5;

    public float offset = 1.05f;
    // Start is called before the first frame update
    void Start()
    {
        CreateMap();
    }

    private void CreateMap()
    {
        for (int x = 0; x < mapWith; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                Image  tempObj = Instantiate(tilePrefab);
                tempObj.transform.position = new Vector3(transform.position.x + (x * offset), transform.position.y + (y * offset), 0);
                tempObj.transform.parent = transform;
                tempObj.name = x.ToString() + ", " + y.ToString();
            }
        }
    }

}
