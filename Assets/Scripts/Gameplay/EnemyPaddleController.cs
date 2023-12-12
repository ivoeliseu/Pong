using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPaddleController : MonoBehaviour
{
    public GameManager gameManager;
    public float speed = 10f;
    public Vector2 limits = new Vector2(-4.5f, 4.5f);

    public bool isPlayer = false;
    public SpriteRenderer spriteRenderer;
    public string movementeAxisName = "Vertical Player 2";

    private Rigidbody2D rb;
    private GameObject ball;


    private void Start()
    {
        if (isPlayer)
            spriteRenderer.color = SaveController.Instance.colorPlayer;
        else
            spriteRenderer.color = SaveController.Instance.colorEnemy;

        rb = GetComponent<Rigidbody2D>();
        ball = GameObject.Find("Ball"); //Encontra o objeto da bola na cena
    }
    
    private void Update()
    {
        if (gameManager.gameMode == "Single Player")
        {
            CaptureMovimentIA();
        }
        else
        {
            CaptureMovimentPlayer2();
        }
      
    }

    public void CaptureMovimentIA()
    {
        if (ball != null)
        {
            // Limita a posi��o em Y
            float targetY = Mathf.Clamp(ball.transform.position.y, limits.x, limits.y);
            Vector2 targetPosition = new Vector2(transform.position.x, targetY);
            // Move gradualmente para a posi��o Y da bola
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
        }
    }

    public void CaptureMovimentPlayer2()
    {
        // Captura da entrada vertical (seta para cima, seta para baixo que est�o configuradas no AXES do projeto Unity)
        float moveInput = Input.GetAxis(movementeAxisName);

        // Caulcula a nova posi��o da raquete baseada na entrada e na velocidade
        Vector3 newPosition = transform.position + Vector3.up * moveInput * speed * Time.deltaTime;

        // Limita a posi��o vertical da raquete para que ela n�o saia da tela
        newPosition.y = Mathf.Clamp(newPosition.y, limits.x, limits.y);

        // Atualiza a posi��o da raquete

        transform.position = newPosition;
    }
}
