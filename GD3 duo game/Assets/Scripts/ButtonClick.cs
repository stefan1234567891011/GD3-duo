using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    // Update is called once per frame
    private Touch touch;
    public GameObject tower;

    public AudioClip placeTower;
    public float placeTowerVolume;
    void Start() 
    {
        if (Input.touchCount>0)
        {
            touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;
            transform.position = touchPosition;
        }
    }
    void Update()
    {
        touch = Input.GetTouch(0);
        if(touch.phase == TouchPhase.Moved){
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;
            transform.position = touchPosition;
        }
        if(touch.phase == TouchPhase.Canceled || touch.phase == TouchPhase.Ended){
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if(hit.transform.tag == "Floor")
                {
                    GameObject hitObj = hit.transform.gameObject;
                    GameObject temp = Instantiate(tower);
                    Vector3 pos = hitObj.transform.position;
                    pos.z -=1;
                    temp.transform.position = pos;
                    LaneRefrens lanerefspawnpoint = hitObj.GetComponent<LaneRefrens>();
                    LaneRefrens lanerefunit = temp.GetComponent<LaneRefrens>();
                    lanerefunit.Lane = lanerefspawnpoint.Lane;

                    FindObjectOfType<RescourceManager>().TurretBought(FindObjectOfType<RescourceManager>().Tower1Cost);

                    AudioSource.PlayClipAtPoint(placeTower, gameObject.transform.position, placeTowerVolume);

                    Destroy(gameObject);
                    return;
                }
            }
            Destroy(gameObject);
            
        }

            
    }

}
