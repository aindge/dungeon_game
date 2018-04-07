using System;
using DungeonThingy.Core;

namespace DungeonThingy.Actors
{
    public abstract class Player : Actor
    {
        protected Player(IGameContext context) : base(context)
        {

        }

        //public sealed override void Act()
        //{
        //    throw new InvalidOperationException("Players cannot act as computers.");
        //}
    }
}