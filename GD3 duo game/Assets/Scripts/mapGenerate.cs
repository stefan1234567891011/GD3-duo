using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mapGenerate : MonoBehaviour
{
    public GameObject tilePrefab;
    public GameObject wallPrefab;
    public SpawnEnemy spawn;

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
                
                if(x==0)
                {
                    GameObject  tempWallObj = Instantiate(wallPrefab);
                    tempWallObj.transform.position = new Vector3(transform.position.x + -2, transform.position.y  + (y * offset), 10);
                    tempWallObj.transform.parent = transform;
                    tempWallObj.name = x.ToString() + "left";
                    GameObject  tempWallObj2 = Instantiate(wallPrefab);
                    tempWallObj2.transform.position = new Vector3(transform.position.x + mapWith+2, transform.position.y  + (y * offset), 10);
                    tempWallObj2.transform.parent = transform;
                    tempWallObj2.name = x.ToString() + "right";
                }
                GameObject  temptileObj = Instantiate(tilePrefab);
                temptileObj.transform.position = new Vector3(transform.position.x + (x * offset), transform.position.y + (y * offset), 10);
                temptileObj.transform.parent = transform;
                temptileObj.name = x.ToString() + ", " + y.ToString();
                if(x == mapWith-1){
                    spawn.spawnpoints.Add(temptileObj);
                }
            }
        }
    }

}
