using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public enum GameState
    {
        PLAYING,
        PAUSED,
        GAME_OVER,
        GAME_WIN
    }

    public static GameManager Instance;

    public Player player;


    public GameState currentState;

    void Awake()
    {

        Instance = this;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }

    void Start()
    {

        PauseGame();

    }

    public void PauseGame()
    {
        currentState = GameState.PAUSED;
        player.playerMovement.enabled = false;
    }

    public void ResumeGame()
    {
        currentState = GameState.PLAYING;
        player.playerMovement.enabled = true;
    }

    public void GameWin()
    {
        currentState = GameState.GAME_WIN;
        player.playerMovement.enabled = false;
        print("Game Win!");
    }

    public void GameOver()
    {
        currentState = GameState.GAME_OVER;
        player.playerMovement.enabled = false;
        print("Game Over!");
    }

}
