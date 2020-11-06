using System.Collections;
using UnityEngine;

namespace FutureGames.TurnBasedRPG
{

    /// <summary>
    /// Class to keep track of current commands in a queue, add commands and invoke them in the right order.
    /// </summary>
    public class CommandInvoker : MonoBehaviour
    {
        private Queue commands = new Queue();
        private Actor actor;

        private void Awake()
        {
            actor = GetComponent<Actor>();
        }

        public void ExecuteCommands(WaitForSeconds waitTime)
        {
            Debug.Log("Executing Commands");
            StartCoroutine(DelayedExecuteCommands(waitTime));
        }

        public void AddCommand(Command command)
        {
            commands.Enqueue(command);
        }

        private IEnumerator DelayedExecuteCommands(WaitForSeconds waitTime)
        {
            foreach (Command t in commands)
            {
                Debug.Log("Executing Command" + t);
                t.Execute(actor);
                yield return waitTime;
            }
            commands.Clear();
        }
    }
}
