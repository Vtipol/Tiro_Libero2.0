using UnityEngine;

public class TurnManager
{
    public enum Turn { Player1, Player2 } // deve essere espenso e modificato per due o quattro giocatori
    public Turn CurrentTurn { get; private set; } = Turn.Player; // ditto

    public void SwitchTurn()
    {
        CurrentTurn = (CurrentTurn == Turn.Player) ? Turn.Enemy : Turn.Player;
    }
}
