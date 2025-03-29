using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "NewPuckData", menuName = "Puck System/Puck Data")]
public class PuckData : ScriptableObject
{
    public float weight;
    public float scoreMultiplier;
}
