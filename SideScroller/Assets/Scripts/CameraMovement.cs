using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // public GameObject player;
    //boundaries
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    // Update is called once per frame
    void Update()
    {
        FindXandY();
    }

    void FindXandY()
    {
        float x = Math.Clamp(PlayerMovement.Instance.transform.position.x, xMin, xMax);
        float y = Math.Clamp(PlayerMovement.Instance.transform.position.y, yMin, yMax);
        transform.position = new Vector3(x, y, transform.position.z);

    }
}
