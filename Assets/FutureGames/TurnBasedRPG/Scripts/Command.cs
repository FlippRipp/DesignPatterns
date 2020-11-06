using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FutureGames.TurnBasedRPG
{
    /// <summary>
    /// Base Command Class for all other commands to inherit from.
    /// </summary>
    public abstract class Command
    {
        public abstract void Execute(Actor actor);
    }
}
