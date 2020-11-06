using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FutureGames.TurnBasedRPG;
using UnityEngine;

public class ActorManager : MonoBehaviour
{

    public Actor[] ControllableCharacters;
    private int currentActor;
    
    private void Start()
    {
        ControllableCharacters = FindObjectsOfType<Actor>().Where(t => t.playerControlled).ToArray();
        currentActor = Random.Range(0, ControllableCharacters.Length);
        Debug.Log(currentActor + " : " + ControllableCharacters.Length);
        Debug.Log(ControllableCharacters[currentActor]);
        GameEvents.instance.ControlledActorChanged(ControllableCharacters[currentActor]);
        GameEvents.instance.OnEndTurn += GetNextActor;
    }

    private void GetNextActor()
    {
        Debug.Log("Hello");
        currentActor++;
        if (currentActor > ControllableCharacters.Length - 1)
        {
            currentActor = 0;
        }
        
        GameEvents.instance.ControlledActorChanged(ControllableCharacters[currentActor]);
    }
}
