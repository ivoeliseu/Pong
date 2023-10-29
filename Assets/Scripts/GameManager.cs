using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // No script GameManager
    public Transform playerPaddle;
    public Transform enemyPaddle;

    public BallController ballController;

    public int playerScore = 0;
    public int enemyScore = 0;
    public int winPoints = 2;
    public float resetTimer = 5f;
    public bool endGame = false;

    public TextMeshProUGUI textPointsPlayer;
    public TextMeshProUGUI textPointsEnemy;
    public TextMeshProUGUI textWinner;
    


    // ...
    void Start()
    {

        ResetGame();
    }
    
    public void ResetGame()
    {
        endGame = false;
        textWinner.gameObject.SetActive(false);
        // Define as posições iniciais das raquetes
        playerPaddle.position = new Vector3(7f, 0f, 0f);
        enemyPaddle.position = new Vector3(-7f, 0f, 0f);
        // ...

        //Insetir dentro do ResetGame
        ballController.ResetBall();

        playerScore = 0;
        enemyScore = 0;

        textPointsEnemy.text = enemyScore.ToString();
        textPointsPlayer.text = enemyScore.ToString();
    }

    public void ScoreEnemy()
    {
        enemyScore++;
        textPointsEnemy.text = enemyScore.ToString();
        CheckWin();
    }
    public void ScorePlayer()
    {
        playerScore++;
        textPointsPlayer.text = playerScore.ToString();
        CheckWin();
    }

    public void CheckWin()
    {
        // Adicionado uma verificação para comparar se é o player ou o enemy o vencedor para mostrar na tela o ganhador. Após resetTimer segundos, o jogo reinicia.
        if (enemyScore >= winPoints || playerScore >= winPoints)
        {
            endGame = true;
            if (playerScore > enemyScore)
            {
            textWinner.text = "Player Winner!";
            textWinner.gameObject.SetActive(true);
            }
            else
            {
            textWinner.text = "Enemy Winner!";
            textWinner.gameObject.SetActive(true);
            }

            Invoke("ResetGame", resetTimer);
        }              
    }
}
