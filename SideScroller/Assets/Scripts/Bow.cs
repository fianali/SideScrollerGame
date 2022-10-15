using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public Transform firepoint;
    public GameObject arrow;
    public Animator animator;
    
    private Vector3 mousePos;
    

    // Update is called once per frame
    void Update()
    {
        mousePos = (Camera.main.ScreenToWorldPoint(Input.mousePosition));

        GetInput();
    }

    private void FixedUpdate()
    {
        Vector3 fireDirection = (mousePos - firepoint.position).normalized;
        float angle = Mathf.Atan2(fireDirection.y, fireDirection.x) * Mathf.Rad2Deg;
        // firepoint.rotation = new Quaternion(0, 0, angle,0);
        firepoint.eulerAngles = new Vector3(0, 0, angle);
    }

    void GetInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Shoot");
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(arrow, firepoint.position, firepoint.rotation);
    }
    
}
