using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour
{
    [ReadOnly][SerializeField] private TeamRecord _teamRecord;
    public virtual TeamRecord TeamRecord
    {
        get
        {
            return _teamRecord;
        }
        set
        {
            _teamRecord = value;
        }
    }
}
