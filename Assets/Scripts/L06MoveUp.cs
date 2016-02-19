using UnityEngine;
using System.Collections;

public class L06MoveUp : MonoBehaviour {
    
    Rigidbody2D myRigidBody2D;
    float hSpeed = 1.0f;

    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Move()
    {
        myRigidBody2D.velocity = new Vector2(0.0f,hSpeed);
    }

    void Update()
    {
        if (transform.position.y > 0.580f)
        {
            myRigidBody2D.velocity = new Vector2(0.0f, 0.0f);
        }
    }

}

