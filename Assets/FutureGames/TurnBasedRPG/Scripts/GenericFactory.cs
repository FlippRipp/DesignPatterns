using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FutureGames.TurnBasedRPG
{

    /// <summary>
    /// Base Generic factory class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericFactory<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField]
        private T product;
        
        public T GetProductInstance()
        {
            return Instantiate(product);
        }
    }
}