using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPortal : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;

    void Update()
    {
        if (patrolDestination == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, patrolPoints[0].position) < .2f)
            {
                
                patrolDestination = 1;

            }
        }

        if (patrolDestination == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, patrolPoints[1].position) < .2f)
            {
                
                patrolDestination = 0;

            }
        }
    }
}
