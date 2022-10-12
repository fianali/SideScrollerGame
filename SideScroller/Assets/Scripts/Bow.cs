using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public Transform firepoint;
    public GameObject arrow;

    private Vector3 mousePos;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        mousePos = (Camera.main.ScreenToWorldPoint(Input.mousePosition));
        Debug.Log(mousePos);

    }
    void GetInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // FlipCharacterFromMouse();
        Instantiate(arrow, firepoint.position, firepoint.rotation);
    }

    void FlipCharacterFromMouse()
    {
        //mouse is to the right of player
        if (mousePos.x > PlayerMovement.Instance.transform.position.x)
        {
            
        }
    }
}
