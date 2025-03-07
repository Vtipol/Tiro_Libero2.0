using System;
using UnityEngine;
public static class TurnManager
{
    public enum Turn { Player1, Player2, Player3, Player4 }
    public static Turn CurrentTurn { get; private set; } = Turn.Player1;

    public static void SwitchTurn()
    {
        CurrentTurn = (Turn)(((int)CurrentTurn + 1) % Enum.GetValues(typeof(Turn)).Length);
    }
}
