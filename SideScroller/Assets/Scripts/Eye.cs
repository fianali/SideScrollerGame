using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : Enemy
{
    public Transform waypoint1, waypoint2;
    private Transform waypointDestination;

    private void Awake()
    {
        waypointDestination = waypoint1;
    }

    protected override void Introduction()
    {
        Debug.Log("This is Sir Eye!");
    }

    protected override void Move()
    {
        base.Move();
        //player is not in range of eye
        if (Vector2.Distance(transform.position, PlayerMovement.Instance.transform.position) > distance)
        {
            //eye is currently at waypoint1, move to waypoint 2
            if (Vector2.Distance(transform.position, waypoint1.position) < .01f)
            {
                waypointDestination = waypoint2;
            }

            if (Vector2.Distance(transform.position, waypoint2.position) < .01f)
            {
                waypointDestination = waypoint1;
            }

            transform.position = Vector2.MoveTowards(transform.position, waypointDestination.position, speed * Time.deltaTime);

        }
    }
}
