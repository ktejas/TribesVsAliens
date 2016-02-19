using UnityEngine;
using System.Collections;

public class L06MoveRight : MonoBehaviour
{
    Rigidbody2D myRigidBody2D;
    float vSpeed = 1.0f;

    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Move()
    {
        myRigidBody2D.velocity = new Vector2(vSpeed, 0.0f);
    }

    void Update()
    {
        if (transform.position.x > 1.493f)
        {
            myRigidBody2D.velocity = new Vector2(0.0f, 0.0f);
        }
    }
}
