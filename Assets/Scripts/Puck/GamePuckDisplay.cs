using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GamePuckDisplay : Singleton<GamePuckDisplay>
{

    [Header("Type Of Pucks")]
    [SerializeField] private GameObject normalPuckPrefab;
    [SerializeField] private GameObject weightPuckPrefab;
    [SerializeField] private GameObject bigPuckPrefab;
    [Space]
    public int maxPucks = 7;
    public Transform[] puckSpawnPoints;
    private List<GameObject> createdPucks = new List<GameObject>();
    public void DisplayPucks(Player player)
    {
        int puckSpawnIndex = 0;

        
        for(int i = 0; i<player.normalPucks; i++)
        {
            var puck = Instantiate(normalPuckPrefab, puckSpawnPoints[puckSpawnIndex].transform.position, Quaternion.identity);
            //Debug.Log("spawnati normal puck");
            puckSpawnIndex++;
            createdPucks.Add(puck);
        }
        for (int i = 0; i < player.weightPucks; i++)
        {
            Instantiate(weightPuckPrefab, puckSpawnPoints[puckSpawnIndex].transform.position, Quaternion.identity);
            //Debug.Log("spawnati normal weight");
            puckSpawnIndex++;
        }
        for (int i = 0; i < player.bigPucks; i++)
        {
            Instantiate(bigPuckPrefab, puckSpawnPoints[puckSpawnIndex].transform.position, Quaternion.identity);
            //Debug.Log("spawnati normal big");
            puckSpawnIndex++;
        }
        
    }

    public void ClearPucks(){
        while(createdPucks.Count > 0){
            var puck = createdPucks[0];
            createdPucks.Remove(puck);
            Destroy(puck);
        }
    }
}
