using System.Collections;
using UnityEngine;

namespace FutureGames.TurnBasedRPG
{
    
    /// <summary>
    /// This is the class that uses the command pattern
    /// </summary>
    [RequireComponent(typeof(CommandInvoker), typeof(Rigidbody))]
    public class Actor : MonoBehaviour
    {
        [SerializeField] private float moveTime = 1f;
        [SerializeField] private float moveSpeed = 1f;
        [SerializeField] private float rangedArcHeight = 4;
        
        public bool playerControlled = true;
        
        private WaitForSeconds moveWaitTime;
        private Rigidbody body;
        private CommandInvoker commandInvoker;
        
        private void Start()
        {
            moveWaitTime = new WaitForSeconds(moveTime);
            body = GetComponent<Rigidbody>();
            commandInvoker = GetComponent<CommandInvoker>();
            body.velocity = Vector3.forward * (moveSpeed * Time.deltaTime);
        }

        public void AddMoveAction(Vector3 direction)
        {
            Debug.Log("added movement against " + direction);
            commandInvoker.AddCommand(new MoveCommand(direction, this));
        }

        public void AddRangedAttack(Vector3 hitPoint)
        {
            commandInvoker.AddCommand(new RangedAttackCommand(hitPoint));
        }

        public void ExecuteActions()
        {
            commandInvoker.ExecuteCommands(moveWaitTime);
        }

        public void MoveActor(Vector3 direction)
        {
            StartCoroutine(Move(direction));
        }

        public void RangedAttack(Vector3 hitPoint)
        {
            //Using the factory pattern
             Projectile projectile = FactoryManager.instance.projectileFactory.GetProductInstance();
             projectile.Init(transform.position, hitPoint, moveTime, rangedArcHeight);
        }


        private IEnumerator Move(Vector3 direction)
        {
            float t = 0;

            while (t < moveTime)
            {
                Debug.Log("doingStuff " + direction);
                body.velocity = direction.normalized * (moveSpeed);
                t += Time.deltaTime;
                yield return null;
            }
            body.velocity = Vector3.zero;
        }
    }
}