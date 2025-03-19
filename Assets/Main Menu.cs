using System;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class MainMenu : MonoBehaviour
{
    public GameManager gameManager; 
    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>();
        }
    }
   public void QuitGame()
   {
#if UNITY_EDITOR
      EditorApplication.ExitPlaymode();
#else
    Application.Quit();
#endif
   }
   public void StartGameFFF()
   {
       TurnManager.SetGameMode(TurnManager.GameMode.FourPlayer);
       gameManager.OnGameStart();
   }

   public void StartGame1V1()
   {
       TurnManager.SetGameMode(TurnManager.GameMode.TwoPlayer);
       gameManager.OnGameStart();
   }
   public void StartGame2V2()
   {
       TurnManager.SetGameMode(TurnManager.GameMode.FourPlayer);
       gameManager.OnGameStart();
   } 
   
   
}
