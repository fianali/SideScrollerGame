using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int hp;
    public int maxHp;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Die();
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == 8)
        {
            animator.SetTrigger("Hurt");
            if (col.gameObject.tag == "Trash")
            {
                hp -= 30;
            }
            else
            {
                hp -= 10;
            }
        }
    }

    void Die()
    {
        if (hp <= 0)
        {
            animator.SetBool("isDead",true);
        }
    }
}
