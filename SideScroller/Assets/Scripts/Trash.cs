using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Trash : Enemy
{
    protected override void Introduction()
    {
        Debug.Log("I'm gonna trash you up!");
    }

    protected override void Death()
    {
        Destroy(gameObject);
    }
}
