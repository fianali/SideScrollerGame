using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public Transform firepoint;
    public GameObject arrow;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        GetInput();
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
