using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(FloatVar), menuName = nameof(ScriptableVar) + "/"
    + "Primitive" + "/"
    + nameof(FloatVar)
    )]

public class FloatVar : ScriptableVar
{
    [SerializeField] protected float _value;

    public virtual float Value
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
