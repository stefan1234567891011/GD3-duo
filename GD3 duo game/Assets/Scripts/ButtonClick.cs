using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    // Update is called once per frame
    private Touch touch;
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
            Destroy(gameObject);
        }

            
    }

}
