using UnityEngine;

public class PlayersManager : MonoBehaviour
{
    [SerializeField] private TeamRecordListBasicVar _teams;

    [SerializeField] private Transform _parent;
    [SerializeField] private GameObject _playerPrefab;

    private void Awake()
    {
        FillPlayers();
    }

    // Instantiates prefabs of Player and also gives them the corresponding 
    // Team and Player's info
    private void FillPlayers() {
        for (int i = 0; i < _teams.Value.Count; i++)
        {
            if (_teams.Value[i].PlayerRecords.Count > 1)
            {
                for (int k = 0; k < _teams.Value[i].PlayerRecords.Count; k++)
                {
                    GameObject playerPrefab = Instantiate(_playerPrefab, _parent);

                    if (playerPrefab.TryGetComponent(out Team teamRecord))
                    {
                        teamRecord.TeamRecord = _teams.Value[i];
                    }

                    if (playerPrefab.TryGetComponent(out Player playerRecord))
                        playerRecord.PlayerRecord = _teams.Value[i].PlayerRecords[k];
                }
            }
            else
            {
                GameObject playerPrefab = Instantiate(_playerPrefab, _parent);

                if (playerPrefab.TryGetComponent(out Team teamRecord))
                {
                    teamRecord.TeamRecord = _teams.Value[i];
                }

                if (playerPrefab.TryGetComponent(out Player playerRecord))

                    playerRecord.PlayerRecord = _teams.Value[i].PlayerRecords[0];
            }

        }
    }

    public TeamRecord GetTeam(PlayerRecord playerRecord)
    {
        TeamRecord belongingTeam = null;

        bool teamFound = false;

        // Search the team to which the player belongs to
        foreach (var team in _teams.Value)
        {
            foreach (var player in team.PlayerRecords)
            {
                if (player == playerRecord)
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
}

