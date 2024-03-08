using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public GameManager gameManager;

    public int speed = 10;
    public Rigidbody2D rb;
    void Start()
    {
        if (gameManager == null) {
            Debug.LogError("GameManager instance not found in the scene.");
            return;
        }

        rb.velocity = new Vector2(speed, 0);
    }

    public void BounceFromRacket(Collision2D c) {

        Vector2 ballPosition = this.transform.position;
        Vector2 racketPosition = c.gameObject.transform.position;

        float racketHeight = c.collider.bounds.size.y;

        float y = (ballPosition.y - racketPosition.y) / racketHeight;

        Debug.Log(y);

        rb.velocity = new Vector2(speed, y * speed);
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.name == "Player1" || collision.gameObject.name == "Player2") {
            BounceFromRacket(collision);
        } else if (collision.gameObject.name == "Left" || collision.gameObject.name == "Right") {
            gameManager.ScorePoint(collision.gameObject.name);
        }
    }

}
