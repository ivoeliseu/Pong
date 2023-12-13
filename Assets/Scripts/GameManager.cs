using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // No script GameManager
    public Transform playerPaddle;
    public Transform enemyPaddle;
    public BallController ballController;
    public GameObject gameModeScreen;
    public GameObject endGameScreen;

    public int playerScore = 0;
    public int enemyScore = 0;
    public int winPoints = 2;
    public float timeToStartGame = 3f;
    public bool endGame = false;
    public string gameMode;

    public TextMeshProUGUI textPointsPlayer;
    public TextMeshProUGUI textPointsEnemy;
    public TextMeshProUGUI textWinner;

    void Start()
    {
        SelectGameMode();
    }

    public void SelectGameMode()
    {
        gameModeScreen.SetActive(true);
    }

    public void SinglePlayerMode()
    {
        gameMode = "Single Player";
        ResetGame();
    }
    public void MultiplayerMode()
    {
        gameMode = "Multiplayer";
        ResetGame();
    }

    public void ResetGame()
    {
        gameModeScreen.SetActive(false);
        endGameScreen.SetActive(false);
        endGame = false;
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
            EndGame();
        }              
    }
    public void EndGame()
    {
        endGame = true;
        string winner;
        if (gameMode == "Single Player")
        {
            
            if (playerScore > enemyScore)
            {
                winner = SaveController.Instance.namePlayer;                
            }
            else
            {
                winner = "CPU";
            }
        }
        else
        {
            winner = SaveController.Instance.GetName(playerScore > enemyScore);            
        }

        textWinner.text = winner + " Wins!";
        SaveController.Instance.SaveWinner(winner);
        endGameScreen.SetActive(true);
    }
    private void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
