using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{

    [SerializeField]
    float speed = 0;

    [SerializeField]
    float TimeBetweenReverse = 0;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D obstacleRigidBody = GetComponent<Rigidbody2D>();
        obstacleRigidBody.velocity = Vector2.up * speed;

        InvokeRepeating("Reverse", 0, TimeBetweenReverse);
    }

    void Reverse ()
    {
        Rigidbody2D obstacleRigidBody = GetComponent<Rigidbody2D>();
        obstacleRigidBody.velocity *= 1;
    }
}
