using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 15f;

    private Rigidbody2D rb;
    private Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = transform.right * speed;
        StartCoroutine(DestroyAfterSeconds());
    }

    private void Update()
    {
        mousePos = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.name);
        Destroy(gameObject);
    }

    IEnumerator DestroyAfterSeconds()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
    
}
