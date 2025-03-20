using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// fa il setup del gioco prima che inizia
public class SetupBoardState : StateMachineState
{
    private GameManager gameManager;
    private bool BuildComplete = false;
    public SetupBoardState(GameManager manager)
    {
        gameManager = manager;
    }

    private Button confirmButton;

    public SetupBoardState(Button button)
    {
        confirmButton = button;
        confirmButton.onClick.AddListener(OnConfirmPressed);
    }
    private void OnConfirmPressed()
    {
      BuildComplete = true;
    }
    public override void Enter()
    {
        Debug.Log("Successfully entered SetupBoardState");
        Debug.Log(" Setting up the board...");
        SceneManager.LoadScene("GamePuckBuildScene");
      
    }
    public override  void Update()
    {
        if (BuildComplete)
        {
            gameManager.SetState(new PlayerTurnState(gameManager));
            SceneManager.LoadScene("BoardSceneNPlayerStateMachine");
        }
    }
}

