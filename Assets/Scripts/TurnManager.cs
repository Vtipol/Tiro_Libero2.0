using System;
using UnityEngine;
public static class TurnManager
{
    public enum Turn { Player1, Player2, Player3, Player4 }
    public static Turn CurrentTurn { get; private set; } = Turn.Player1;
    public static float NumberOfCycles = 0;
    public static bool DidACompleteCycle {get; private set;} = false;
    public static void SwitchTurn()
    {
        DidACompleteCycle = (CurrentTurn == Turn.Player4);
        if (DidACompleteCycle) NumberOfCycles++;
        CurrentTurn = (Turn)(((int)CurrentTurn + 1) % Enum.GetValues(typeof(Turn)).Length);
    }
}
