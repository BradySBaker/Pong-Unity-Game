using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject ball;
    public float speed = 1;
    void Start()
    {
        if (ball == null || rb == null) {
            Debug.LogError("Please add ball game object and rigid body");
        }
        speed = PlayerPrefs.GetFloat("enemySpeed"); 
        Debug.Log(speed);
    }

    void Update()
    {
        float yDistance = rb.position.y - ball.transform.position.y;
        if (Mathf.Abs(yDistance) < .3f) {
            return;
        }
        if (ball.transform.position.x > rb.transform.position.x) {
            rb.velocity = -rb.velocity;
            return;
        }
        float verticalInput = yDistance / System.Math.Abs(yDistance);
        Vector2 movement = new Vector2(0f, verticalInput * -1);


        if (rb.velocity.y < 10) {
            rb.velocity += movement * speed;
        }

    }
}
