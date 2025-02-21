using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public record TurnRecord : SaveProfileData
{
    public int Number;
    // <team name, <player name, score>>
    public Dictionary<string, Dictionary<string, int>> TeamsScores;
    // <team name, TeamRecord>
    public Dictionary<string, TeamRecord> Teams;

    public TeamRecord[] WinningTeam
    {
        get
        {
            // Get the first value, so we can compare it to others
            List<TeamRecord> winningTeams = new()
            {
                Teams.First().Value
            };

            // Get the first team's score
            int teamHighestScore = 0;
            foreach (var scores in TeamsScores[winningTeams[0].Name])
            {
                teamHighestScore += scores.Value;
            }

            // Compare every team's score with each other
            foreach (var team in TeamsScores)
            {
                // Get a team's score
                int teamScore = 0;
                foreach (var scores in team.Value)
                {
                    teamScore += scores.Value;
                }

                if (teamScore < teamHighestScore)
                    continue;

                // Check if it is greater or equals to highestScore
                if (teamScore > teamHighestScore)
                {
                    // if greater, clear the list, as it is the only team to have this score
                    teamHighestScore = teamScore;
                    winningTeams.Clear();
                }

                // Add to the list
                winningTeams.Add(Teams[team.Key]);
            }

            return winningTeams.ToArray();
        }
        set { }
    }
}
