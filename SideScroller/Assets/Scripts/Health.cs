using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int hp;
    public int maxHp;

    public Transform mushroomAttackRange;
    public Transform eyeAttackRange;
    public Transform trashAttackRange;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        //enemy's hit collider is near the player
       // if (Vector2.Distance(mushroomAttackRange.position,transform.position) < .00001f || Vector2.Distance(eyeAttackRange.position,transform.position) < .001f || Vector2.Distance(trashAttackRange.position,transform.position) < .0001f)
        if(col.gameObject.layer == 8)
        {
            hp--;
        }
    }
}
