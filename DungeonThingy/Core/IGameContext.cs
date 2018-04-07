using System.Collections.Generic;
using DungeonThingy.Actors;

namespace DungeonThingy.Core
{
    public interface IGameContext
    {
        List<Actor> Allies { get; set; }
        List<Actor> Enemies { get; set; }
        List<Actor> AllActors { get; }
        List<string> DisplayMessages { get; }
        ExportedGameState ExportGameState();
    }
}