using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(TeamRecordListBasicVar), menuName = nameof(ScriptableVar) + "/"
    + "Complex" + "/"
    + nameof(TeamRecordListBasicVar)
    )]

public class TeamRecordListBasicVar : ScriptableVar
{
    [SerializeField] protected List<TeamRecord> _value;

    public virtual List<TeamRecord> Value
    {
        get
        {
            return _value;
        }
        set
        {
            _value = value;
        }
    }
}
