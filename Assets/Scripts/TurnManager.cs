using System;
using UnityEngine;
public static class TurnManager
{
    
        public enum Turn { Player1, Player2, Player3, Player4 }
        public enum GameMode { TwoPlayer, FourPlayer }

        public static GameMode CurrentGameMode { get; private set; } = GameMode.FourPlayer;
        public static Turn CurrentTurn { get; private set; } = Turn.Player1;
        public static float NumberOfCycles = 0;
        public static bool DidACompleteCycle { get; private set; } = false;

        public static void SetGameMode(GameMode mode)
        {
            CurrentGameMode = mode;
            CurrentTurn = Turn.Player1;
            NumberOfCycles = 0;
            DidACompleteCycle = false;
        }

        public static void SwitchTurn()
        {
            if (CurrentGameMode == GameMode.TwoPlayer) // 2 giocatori
            {
                DidACompleteCycle = (CurrentTurn == Turn.Player2);
                if (DidACompleteCycle) NumberOfCycles++;
                CurrentTurn = (CurrentTurn == Turn.Player1) ? Turn.Player2 : Turn.Player1;
            }
            else // 4 giocatori
            {
                DidACompleteCycle = (CurrentTurn == Turn.Player4);
                if (DidACompleteCycle) NumberOfCycles++;
                CurrentTurn = (Turn)(((int)CurrentTurn + 1) % 4);
            }
        }
    }


