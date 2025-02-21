using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(IntVar), menuName = nameof(ScriptableVar) + "/"
    + "Primitive" + "/"
    + nameof(IntVar)
    )]

public class IntVar : ScriptableVar
{
    [SerializeField] protected int _value;

    public virtual int Value
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
