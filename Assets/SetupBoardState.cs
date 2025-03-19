using System;
using UnityEngine;
using UnityEngine.SceneManagement;
// fa il setup del gioco prima che inizia
public class SetupBoardState : StateMachineState
{
    private GameManager gameManager;

    public SetupBoardState(GameManager manager)
    {
        gameManager = manager;
    }

    public override void Enter()
    {
        Debug.Log("Successfully entered SetupBoardState");
        Debug.Log(" Setting up the board...");
        SceneManager.LoadScene("GamePuckBuildScene");
      
    }

    public override void Update()
    {
        if (Input.GetKey("Enter"))
        {
            SceneManager.LoadScene("GamePuckBuildScene");
            gameManager.SetState(new PlayerTurnState(gameManager));
        }
    }
}

