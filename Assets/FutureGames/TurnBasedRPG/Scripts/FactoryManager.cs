using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FutureGames.TurnBasedRPG
{

    
    /// <summary>
    /// Class that keeps refs to all the factories
    /// </summary>
    public class FactoryManager : MonoBehaviour
    {
        public static FactoryManager instance;
        public ProjectileFactory projectileFactory;

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
    }
}
