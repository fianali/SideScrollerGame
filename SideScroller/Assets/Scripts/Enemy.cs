using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private string enemyName;
    [SerializeField] private float speed;

    private float hp;
    [SerializeField] private float maxHp;
    [SerializeField] private float distance;

    private Animator animator;
    private SpriteRenderer sp;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        hp = maxHp;
        Introduction();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Flip();
    }

    void Introduction()
    {
        Debug.Log("My name is " + enemyName + " HP: " + hp + " Speed: " + speed);
    }

    void Move()
    {
        //move towards player if attack range is small enough
        if (Vector2.Distance(transform.position, PlayerMovement.Instance.transform.position) < distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, PlayerMovement.Instance.transform.position,
                speed * Time.deltaTime);
            animator.SetBool("isMoving", true);
        }
    }

    void Flip()
    {
        if (transform.position.x > PlayerMovement.Instance.transform.position.x)
        {
            sp.flipX = true;
        }
        else
        {
            sp.flipX = false;
        }
    }
}
