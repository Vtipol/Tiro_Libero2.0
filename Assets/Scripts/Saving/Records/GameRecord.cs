using System;

[Serializable]
public record GameRecord : SaveProfileData
{
    public TurnRecord[] TurnRecords;
    public TeamRecord[] WinningTeams;
}
