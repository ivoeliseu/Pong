using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddleController : MonoBehaviour
{
    public float speed = 10f;
    public Vector2 limits = new Vector2(-4.5f, 4.5f);
    public void Update()
    {
        CaptureMoviment();
    }

    public void CaptureMoviment()
    {
        // Captura da entrada vertical (seta para cima, seta para baixo que est�o configuradas no AXES do projeto Unity)
        float moveInput = Input.GetAxis("Vertical Player 1");

        // Caulcula a nova posi��o da raquete baseada na entrada e na velocidade
        Vector3 newPosition = transform.position + Vector3.up * moveInput * speed * Time.deltaTime;

        // Limita a posi��o vertical da raquete para que ela n�o saia da tela
        newPosition.y = Mathf.Clamp(newPosition.y, limits.x, limits.y);

        // Atualiza a posi��o da raquete
        transform.position = newPosition;
    }

}
