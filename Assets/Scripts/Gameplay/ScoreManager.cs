using System;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private GameRecord _gameRecord;
    private TurnRecord[] _turnRecords;
    private Dictionary<string, TeamRecord> teams;

    [SerializeField] private TeamRecordListBasicVar _teams;

    [SerializeField] private IntVar _turnsNumber;

    [SerializeField] private IntVar _currentTurn;

    [SerializeField] private PlayersManager _playersManager;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        AddPoints
        (
            teamRecord: _teams.Value[0],
            playerRecord: _teams.Value[0].PlayerRecords[0],
            points: 10
        );
        AddPoints
        (
            teamRecord: _teams.Value[1],
            playerRecord: _teams.Value[1].PlayerRecords[0],
            points: 50
        );
        AddPoints
        (
            teamRecord: _teams.Value[1],
            playerRecord: _teams.Value[1].PlayerRecords[1],
            points: 5
        );

        _currentTurn.Value++;

        AddPoints
        (
            teamRecord: _teams.Value[0],
            playerRecord: _teams.Value[0].PlayerRecords[1],
            points: 5 + 44
        );
        _teams.Value.FindIndex(team => team == _teams.Value[0]);
        AddPoints
        (
            teamRecord: _teams.Value[1],
            playerRecord: _teams.Value[1].PlayerRecords[0],
            points: 3
        );

        PlayerRecord playerRecord = new()
        {
            Name = "Cotoletta"
        };
        PlayerRecord playerRecord1 = new()
        {
            Name = "Cotoletta"
        };

        Debug.Log(playerRecord == playerRecord1);

        Debug.Log(GetTeamTotalScore(_teams.Value[0]));
        Debug.Log(GetTeamTotalScore(_teams.Value[1]));

        TeamRecord[] winningTeams = GetWinningTeams();

        if (winningTeams.Length == 1)
        {
            Debug.Log($"{winningTeams[0].Name} Wins!");
        }
        else
        {
            string draw = "Draw! These teams have an equal score:\n";

            for (int i = 0; i < winningTeams.Length; i++)
            {
                draw += $"({i + 1}) {winningTeams[i].Name}";
                if (i < winningTeams.Length - 1) draw += "\n";
            }

            Debug.Log(draw);
        }

        _gameRecord.WinningTeams = winningTeams;
        bool saveState = StatsSaver.Save(_gameRecord);

        if (saveState)
        {
            _gameRecord = StatsSaver.Load("2024-12-20 10-41-45").SaveData;
            _turnRecords = _gameRecord.TurnRecords;

            Debug.Log(GetTeamTotalScore(_teams.Value[0]));
            Debug.Log(GetTeamTotalScore(_teams.Value[1]));
        }
        else
        {
            Debug.LogError("Save not successful");
        }
    }

    public void Initialize()
    {
        // NOT MINE TO HANDLE
        _currentTurn.Value = 0;
        // // // // // // //

        // Initialize roundRecords
        _turnRecords = new TurnRecord[_turnsNumber.Value];

        // Initialize gameRecord
        _gameRecord = new()
        {
            TurnRecords = _turnRecords,
        };

        // Initialize teams

        teams = new();

        for (int k = 0; k < _teams.Value.Count; k++)
        {
            TeamRecord team = _teams.Value[k];
            teams[team.Name] = team;
        }

        // Fill each roundRecord
        for (int i = 0; i < _turnRecords.Length; i++)
        {
            Dictionary<string, Dictionary<string, int>> teamScores = new();

            // Initialize the dictionary, so it's ready to be used
            for (int k = 0; k < _teams.Value.Count; k++)
            {
                TeamRecord team = _teams.Value[k];
                teamScores[team.Name] = new();
            }

            // Fill each roundRecord with the number of the round
            // and the newly created dictionary
            _turnRecords[i] = new TurnRecord()
            {
                Number = i,
                TeamsScores = teamScores,
                Teams = teams
            };
        }
    }

    public void AddPoints(TeamRecord teamRecord, PlayerRecord playerRecord, int points)
    {
        // Dictionary of all teams' scores
        Dictionary<string, Dictionary<string, int>> teamsScores = _turnRecords[_currentTurn.Value].TeamsScores;
        // Dictionary of a team's members scores
        Dictionary<string, int> selectedTeamScores = teamsScores[teamRecord.Name];

        // Check if the player has not scored in this round yet
        if (!selectedTeamScores.ContainsKey(playerRecord.Name))
        {
            // if not, just initialize the score to 0
            selectedTeamScores[playerRecord.Name] = 0;
        }

        // add the points to the current score of the player in this round
        selectedTeamScores[playerRecord.Name] += points;
    }

    public void RemovePoints(TeamRecord teamRecord, PlayerRecord playerRecord, int points)
    {
        // Dictionary of all teams' scores
        Dictionary<string, Dictionary<string, int>> teamsScores = _turnRecords[_currentTurn.Value].TeamsScores;
        // Dictionary of a team's members scores
        Dictionary<string, int> selectedTeamScores = teamsScores[teamRecord.Name];

        // Check if the player has not scored in this round yet
        if (!selectedTeamScores.ContainsKey(playerRecord.Name))
        {
            // if not, just quit, can't go negative
            return;
        }

        // subtracts the points to the current score of the player in this round, can't go below 0
        selectedTeamScores[playerRecord.Name] = Math.Max(selectedTeamScores[playerRecord.Name] - points, 0);
    }

    public int GetTeamScoreTurn(TeamRecord teamRecord, int turn)
    {
        // Dictionary of all teams' scores
        Dictionary<string, Dictionary<string, int>> teamsScores = _turnRecords[turn].TeamsScores;
        // Dictionary of a team's members scores
        Dictionary<string, int> selectedTeamScores = teamsScores[teamRecord.Name];

        int totalScore = 0;

        foreach (var playerScore in selectedTeamScores)
        {
            totalScore += playerScore.Value;
        }

        return totalScore;
    }

    public int GetPlayerScoreTurn(PlayerRecord playerRecord, int turn)
    {
        TeamRecord belongingTeam = _playersManager.GetTeam(playerRecord);

        // Dictionary of all teams' scores
        Dictionary<string, Dictionary<string, int>> teamsScores = _turnRecords[turn].TeamsScores;
        // Dictionary of a team's members scores
        Dictionary<string, int> selectedTeamScores = teamsScores[belongingTeam.Name];

        int score = 0;

        // Check if the player has scored this turn
        if (selectedTeamScores.ContainsKey(playerRecord.Name))
        {
            // if so, update the score
            score = selectedTeamScores[playerRecord.Name];
        }

        return score;
    }

    public int GetTeamTotalScore(TeamRecord teamRecord)
    {
        int totalScore = 0;

        for (int i = 0; i < _turnsNumber.Value; i++)
        {
            totalScore += GetTeamScoreTurn(teamRecord, turn: i);
        }

        return totalScore;
    }

    public TeamRecord[] GetWinningTeams()
    {
        List<TeamRecord> teams = new();

        // Get the first team's score
        int highestScore = GetTeamTotalScore(_teams.Value[0]);
        teams.Add(_teams.Value[0]);

        for (int i = 1; i < _teams.Value.Count; i++)
        {
            int teamTotalScore = GetTeamTotalScore(_teams.Value[i]);
            TeamRecord team = _teams.Value[i];

            // if score is less than highest one
            // just skip to the next team
            if (teamTotalScore < highestScore)
                continue;

            // if score greater, clear the list
            if (teamTotalScore > highestScore)
            {
                teams.Clear();
            }

            // finally, add the team to the winning teams
            teams.Add(team);
        }

        return teams.ToArray();
    }




}
