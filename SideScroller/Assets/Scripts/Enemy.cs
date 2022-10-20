using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private string enemyName;
    [SerializeField] protected private float speed;

    private bool isAttacking;
    private float hp;
    [SerializeField] private float maxHp;
    [SerializeField] protected private float distance;
    [SerializeField] protected private float distanceToAttack;
    [SerializeField] protected private int damageToPlayer;
    
    [SerializeField] private Transform colliderCheck;
    [SerializeField] private LayerMask player;
    [SerializeField] private float radius;

    private Animator animator;
    private SpriteRenderer sp;

    void Start()
    {
        animator = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        hp = maxHp;
        Physics2D.IgnoreLayerCollision(8,8);
        animator.SetBool("isDead", false);
        
        Introduction();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Flip();
        Attack();
    }

    private void FixedUpdate()
    {
        isAttacking = Physics2D.OverlapCircle(colliderCheck.position, radius, player);
    }

    protected virtual void Introduction()
    {
        Debug.Log("My name is " + enemyName + " HP: " + hp + " Speed: " + speed);
    }

    protected virtual void Move()
    {
        //move towards player if attack range is small enough
        if (Vector2.Distance(transform.position, PlayerMovement.Instance.transform.position) < distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, PlayerMovement.Instance.transform.position,
                speed * Time.deltaTime);
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
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

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        //arrow hits enemy
        if (col.gameObject.tag == "Arrow")
        {
            hp -= 10;
            Debug.Log(gameObject + "hp: " + hp);
        }

        if (hp <= 0)
        {
            StartCoroutine(Death());
        }
    }

    protected virtual void Attack()
    {
        if (Vector2.Distance(transform.position, PlayerMovement.Instance.transform.position) < distanceToAttack)
        {
            Debug.Log("doing " + damageToPlayer + "damage to player");
            animator.SetBool("isAttacking",true);
        }
        else
        {
            animator.SetBool("isAttacking",false);
        }
    }
    

    protected virtual IEnumerator Death()
    {
        animator.SetBool("isDead", true);
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }
    
}

