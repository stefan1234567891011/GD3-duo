using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mapGenerate : MonoBehaviour
{
    public GameObject tilePrefab;
    public GameObject wallPrefab;
    public GameObject LanePrefab;
    public BackgrounSoundManager soundcounter;
    public SpawnEnemy spawn;

    public int mapLength = 5;
    public int mapLanes = 3;

    private List<GameObject> Lanes = new List<GameObject>();

    public float offset = 1.05f;
    // Start is called before the first frame update
    void Start()
    {
        CreateMap();
    }

    private void CreateMap()
    {
        for (int y = 0; y < mapLanes; y++)
            {
                
                
                GameObject  tempWallObj = Instantiate(wallPrefab);
                tempWallObj.transform.position = new Vector3(transform.position.x + (-1* offset), transform.position.y  + (y * offset), 10);
                tempWallObj.transform.parent = transform;
                tempWallObj.name = y.ToString() + "left";

                GameObject  tempWallObj2 = Instantiate(wallPrefab);
                tempWallObj2.transform.position = new Vector3(transform.position.x + ((mapLength+1 )* offset), transform.position.y  + (y * offset), 10);
                tempWallObj2.transform.parent = transform;
                tempWallObj2.name = y.ToString() + "right";

                GameObject tempLane = Instantiate(LanePrefab);
                tempLane.transform.parent = transform;
                tempLane.name = "Lane"+y.ToString() ;
                Lanes.Add(tempLane);
                
                for (int x = 0; x < mapLength; x++)
                {
                    
                    
                        GameObject  temptileObj = Instantiate(tilePrefab);
                        temptileObj.transform.position = new Vector3(transform.position.x + (x * offset), transform.position.y + (y * offset), 10);
                        temptileObj.transform.parent = transform;
                        temptileObj.name = x.ToString() + ", " + y.ToString();

                        LaneRefrens laneref = temptileObj.GetComponent<LaneRefrens>();
                        laneref.Lane = Lanes[y];
                        if(x == mapLength-1){
                            spawn.spawnpoints.Add(temptileObj);
                            soundcounter.list.Add(temptileObj);
                        }
                    }
                }
    }

}
