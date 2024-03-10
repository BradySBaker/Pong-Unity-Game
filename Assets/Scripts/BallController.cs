using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public GameManager gameManager;

    public int speed = 15;
    public Rigidbody2D rb;
    void Start()
    {
        int randomInt = UnityEngine.Random.Range(0, 2);
        int direction = 1;
        if (randomInt == 0) {
            direction = -1;
        }
        rb.velocity = new Vector2(speed * direction, 0);
        if (gameManager == null) {
            Debug.Log("GameManager instance not found in the scene ball will bounce freely.");
            rb.velocity = new Vector2(rb.velocity.x, 5f);
            return;
        }
    }

    public void BounceFromRacket(Collision2D c) {

        Vector2 ballPosition = this.transform.position;
        Vector2 racketPosition = c.gameObject.transform.position;

        float racketHeight = c.collider.bounds.size.y;

        float y = (ballPosition.y - racketPosition.y) / racketHeight;

        Debug.Log(y);

        rb.velocity = new Vector2(rb.velocity.x, y * speed);
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.name == "Player1" || collision.gameObject.name == "Player2") {
            BounceFromRacket(collision);
        } else if (collision.gameObject.name == "Left" || collision.gameObject.name == "Right") {
            gameManager.ScorePoint(collision.gameObject.name);
        }
    }

}
