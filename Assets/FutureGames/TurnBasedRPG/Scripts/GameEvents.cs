using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FutureGames.TurnBasedRPG
{
    
    /// <summary>
    /// System using the observer pattern
    /// </summary>
    public class GameEvents : MonoBehaviour
    {
        public event Action<float> OnPlayerHealthChanged;
        public event Action<Actor> OnControlledActorChanged;
        public event Action OnEndTurn;

        public static GameEvents instance;

        private void Awake()
        {
            if (instance)
            {
                Destroy(this);
            }
            else
            {
                instance = this;
            }
        }

        public void EndTurn()
        {
            OnEndTurn?.Invoke();
        }

        private void PlayerHealthChanged(float currentHealth)
        {
            OnPlayerHealthChanged?.Invoke(currentHealth);
        }

        public void ControlledActorChanged(Actor controlledActor)
        {
            OnControlledActorChanged?.Invoke(controlledActor);
        }
    }
}