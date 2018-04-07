using System;
using System.Collections.Generic;
using System.Linq;
using DungeonThingy.Actors;

namespace DungeonThingy.Core
{
    public class GameContext : IGameContext
    {
        public GameContext()
        {
            _turnList = new InitiativeList();

            // Add stuff to turn list here
        }

        private readonly InitiativeList _turnList;
        public List<Actor> Allies { get; set; }
        public List<Actor> Enemies { get; set; }
        public List<Actor> AllActors => Allies.Union(Enemies).ToList();

        public List<string> DisplayMessages { get; } = new List<string>();

        public ExportedGameState ExportGameState()
        {
            return new ExportedGameState()
            {
                Enemy1Name = Enemies[0].Name,
                Enemy1CurrentHealth = Enemies[0].CurrentHealth,
                Ally1Name = Allies[0].Name,
                Ally1CurrentHealth = Allies[0].CurrentHealth,
                DisplayMessages = DisplayMessages.ToList(), // Clone list
            };
        }

        private void ApplyActions()
        {
            var currentActor = _turnList[_turnList.CurrentPosition];
            // Do stuff with current actor here...

            while (true)
            {
                currentActor = _turnList.Next();
                if (currentActor is Player)
                {
                    break;
                }
                var enemy = currentActor as Enemy;
                if (enemy is null)
                {
                    throw new InvalidOperationException("This should not happen!");
                }
                enemy.Act();
            }
        }
    }
}