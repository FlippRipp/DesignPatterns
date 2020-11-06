using UnityEngine;

namespace FutureGames.TurnBasedRPG
{
    /// <summary>
    /// Command to move an actor in a direction
    /// </summary>
    public class MoveCommand : Command
    {
        private Vector3 direction;
        private Actor actorToMove;

        public MoveCommand(Vector3 dir, Actor actor)
        {
            direction = dir;
            actorToMove = actor;
        }

        public override void Execute(Actor actor)
        {
            actor.MoveActor(direction);
        }
    }
}
