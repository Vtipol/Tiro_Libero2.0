using UnityEngine;

[CreateAssetMenu(fileName = "NewPuckData", menuName = "Puck System/Puck Data")]
public class PuckData : ScriptableObject
{
    public float weight;
    public int scoreMultiplier;
}
