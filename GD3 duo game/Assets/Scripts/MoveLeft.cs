using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed;
    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime * -1, 0);
    }
}
