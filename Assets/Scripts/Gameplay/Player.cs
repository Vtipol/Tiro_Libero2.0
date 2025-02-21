using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [ReadOnly][SerializeField] private PlayerRecord _playerRecord;

    public virtual PlayerRecord PlayerRecord
    {
        get
        {
            return _playerRecord;
        }
        set
        {
            _playerRecord = value;
        }
    }
}
