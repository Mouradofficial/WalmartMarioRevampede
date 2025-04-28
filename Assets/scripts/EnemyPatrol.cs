using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform pointA, pointB; // Assign patrol points in Unity
    public float speed = 2f; // Adjust movement speed
    public bool movingToB = true; // Start moving towards point B

    private void Update()
    {
        if (movingToB)
        {
            transform.position = Vector2.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, pointB.position) < 0.1f)
            {
                movingToB = false; // Switch direction
                Flip();
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, pointA.position) < 0.1f)
            {
                movingToB = true; // Switch direction
                Flip();
            }
        }
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1; // Flip the enemy sprite
        transform.localScale = scale;
    }
}
