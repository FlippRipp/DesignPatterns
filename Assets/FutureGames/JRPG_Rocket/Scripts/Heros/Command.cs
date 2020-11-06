using System;

namespace FutureGames.JRPG_Rocket
{
    /// <summary>
    /// Abstract base class that all commands inherit from.
    /// </summary>
    public abstract class Command
    {
        public abstract void Execute(Hero hero);
    }
}