using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField] private Team[] _teams;
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject _teamPrefab;
    public Action playerTurnEndSignal;
    public EPlayerState firstState;
    public PuckBase puckSelected;
    public PuckBase puckToThrow;
    public PuckBase SelectablePuckTT;

    public StationaryCamera StationaryCamera;
    public FallingCamera FallingCamera;
    public FollowPuck FollowPuck;
    public DisableColliders DisableColliders;

    public PuckController puckController;
    public LayerMask puckLayerMask;

    [Header("Aim Var")]
    public LineRenderer lineRenderer;
    public float redLineThreshold;
    public bool invertedAim;
    public bool invertedThrow;
    public float throwForce = 2f;

    public float sensibilityAim = 1f;
    //public float trembling;

    //public float minDistanceToThrow;
    //public float MaxDistanceToThrow;
    //public float tremblingThreshold = 2.5f;
    //public float tremblingAmplitude = 0.5f;
    //public float tremblingSpeed = 5f;

    [Header("Player Var")]
    public int maxPucks = 7;
    public int myPlacedPucks = 0;
    public bool place1AtTime;

    //lista dei pucks sopravvissuti nella board avversaria
    public List<GameObject> survivedPucks = new List<GameObject>();

    private void Awake()
    {
        lineRenderer.enabled = false;
        lineRenderer.positionCount = 2;

        //Temporary
        _teams = new Team[2];
        for (int i = 0; i < _teams.Length; i++)
        {
            _teams[i] = Instantiate(_teamPrefab).GetComponent<Team>();
            _teams[i].playerCount = 2;
        }

        FillPlayers();
    }

    // Instantiates prefabs of Player and also gives them the corresponding 
    // Team and Player's info
    private void FillPlayers() {
        for (int i = 0; i < _teams.Length; i++)
        {
            if (_teams[i].playerCount > 0)
            {
                for (int k = 0; k < _teams[i].playerCount; k++)
                {
                    Player playerPrefab = Instantiate(_playerPrefab).GetComponent<Player>();
                    _teams[i].players.Add(playerPrefab);
                }
            }
            else
            {
                Player playerPrefab = Instantiate(_playerPrefab).GetComponent<Player>();
                _teams[i].players.Add(playerPrefab);
            }

        }
    }

    public Team GetTeam(Player player)
    {
        Team belongingTeam = null;

        bool teamFound = false;

        // Search the team to which the player belongs to
        foreach (var team in _teams)
        {
            foreach (var teamPlayer in team.players)
            {
                if (player == teamPlayer)
                {
                    belongingTeam = team;
                    teamFound = true;
                    break;
                }
            }
            // Quit if team was found during this cycle
            if (teamFound)
            {
                break;
            }
        }

        return belongingTeam;
    }

    public Player[] GetPlayers(){
        var playerList = new List<Player>();

        foreach(var team in _teams){
            playerList.AddRange(team.players);
        }

        return playerList.ToArray();
    }
}

