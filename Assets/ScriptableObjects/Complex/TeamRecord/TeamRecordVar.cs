using UnityEngine;

[CreateAssetMenu(fileName = nameof(TeamRecordVar), menuName = nameof(ScriptableVar) + "/"
    + "Complex" + "/"
    + nameof(TeamRecordVar)
    )]

public class TeamRecordVar : ScriptableVar
{
    [SerializeField] protected TeamRecord _value;

    public virtual TeamRecord Value
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
