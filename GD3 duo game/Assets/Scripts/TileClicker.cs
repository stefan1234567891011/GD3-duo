using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileClicker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //Touch touch;
    // Update is called once per frame

    private Vector3 mOffset;
    private float mzCoord;
    private GameObject hitObj;
    private bool dragging = false;
    /*
    void OnMouseDown() 
    {
        mzCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }
    void OnMouseDrag() 
    {
        transform.position = GetMouseWorldPos() + mOffset;
    }*/

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousPoint = Input.mousePosition;
        mousPoint.z = mzCoord;
        return Camera.main.ScreenToWorldPoint(mousPoint);
    }
    void Update()
    {
        /*
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Debug.Log("TouchPhase.Began");
                    break;
                default:
                    break;
            }
        }*/
        
        if(Input.GetMouseButtonDown(0) && !dragging)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit,100.0f))
            {
                if(hit.transform && hit.transform.tag == "Tower")
                {
                    PrintName(hit.transform.gameObject);
                    hitObj = Instantiate(hit.collider.gameObject);
                    
                    //hitObj.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y+-5, 0);
                    mzCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

                    mOffset = gameObject.transform.position - GetMouseWorldPos();
                    dragging = true;
                }
            }
        }
        if (Input.mousePresent && dragging)
        {
            hitObj.transform.position = GetMouseWorldPos() + mOffset;
            //hitObj.transform.position.z = 0;
        }
        if(Input.GetMouseButtonUp(0))
        {
             dragging = false;
        }

    }
    private void PrintName (GameObject obj)
    {
        Debug.Log(obj.name);
    }
}
