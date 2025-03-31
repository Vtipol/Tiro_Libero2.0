using System.Collections;
using UnityEngine;

public class GameStartBootstrapper : MonoBehaviour
{
    bool started = false;
    void Awake()
    {
        
    } 
    void Update()
    {
        if(!started && GameManager.Instance.doneSetup){
            Publisher.Publish(new GameStartMessage());
            started = true;
        }
    }

}