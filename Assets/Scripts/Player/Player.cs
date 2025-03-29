using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static int number;
    public int normalPucks;
    public int weightPucks;
    public int bigPucks;
    public Action startPlayerTurnSignal;
    PlayerStateMachine playerStateMachine;
    void Awake()
    {
        playerStateMachine = new PlayerStateMachine(this);

        number++;
        name = "Player "+number;
    }
    public void StartTurn(){
        startPlayerTurnSignal?.Invoke();
    }
    void Update()
    {
        playerStateMachine.OnUpdate();
    }
}
