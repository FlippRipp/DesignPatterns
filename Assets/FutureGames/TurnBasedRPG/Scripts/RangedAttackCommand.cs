using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FutureGames.TurnBasedRPG
{

    /// <summary>
    /// Command to do a ranged attack on a position
    /// </summary>
    public class RangedAttackCommand : Command
    {

        private Vector3 hitPoint;

        public RangedAttackCommand(Vector3 hitP)
        {
            hitPoint = hitP;
        }
        
        public override void Execute(Actor actor)
        {
            actor.RangedAttack(hitPoint);
        }
    }
}