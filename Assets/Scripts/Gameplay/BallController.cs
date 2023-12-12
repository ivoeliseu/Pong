using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 startingVelocity = new Vector2(5f, 5f);

    public GameManager gameManager;

    public float speedUp = 1.5f;

    public void ResetBall()
    {
        if (gameManager.endGame == true) 
        {
            DisableBall();
        }

        else 
        {
            // Adicionado a ativação da bola
            gameObject.SetActive(true);
            transform.position = Vector3.zero;

            if (rb == null) rb = GetComponent<Rigidbody2D>();
            rb.velocity = startingVelocity;
        }
    }

    // Chamado pelo Game Manager quando o jogo acaba
    public void DisableBall()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Colisão com as paredes de cima e de baixo
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector2 newVelocity = rb.velocity;

            newVelocity.y = -newVelocity.y;
            rb.velocity = newVelocity;
        }

        // Colisão com a raquete
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
            rb.velocity *= speedUp;    
        }

        if (collision.gameObject.CompareTag("PointPlayer"))
        {
            gameManager.ScorePlayer();
            startingVelocity = new Vector2(Mathf.Abs(startingVelocity.x), Mathf.Abs(startingVelocity.y));
            ResetBall();
        }

        else if (collision.gameObject.CompareTag("PointEnemy"))
        {
            gameManager.ScoreEnemy();
            startingVelocity = -startingVelocity;
            ResetBall();
            
        }

    }
}
