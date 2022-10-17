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


    private void Start()
    {
        StartCoroutine(Shoot());
    }

    void Update()
    {
        mousePos = (Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    //rotate firepoint based on mouse position
    private void FixedUpdate()
    {
        Vector3 fireDirection = (mousePos - firepoint.position).normalized;
        float angle = Mathf.Atan2(fireDirection.y, fireDirection.x) * Mathf.Rad2Deg;
        firepoint.eulerAngles = new Vector3(0, 0, angle);
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                animator.SetTrigger("Shoot");
                Instantiate(arrow, firepoint.position, firepoint.rotation);
                
                yield return new WaitForSeconds(1f);
            }

            yield return null;
        }
    }

}
