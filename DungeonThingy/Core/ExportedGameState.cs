using System.Collections.Generic;
using System.Diagnostics;

namespace DungeonThingy.Core
{
    public class ExportedGameState
    {
        public string Enemy1Name { get; set; }
        public int Enemy1CurrentHealth { get; set; }
        public string Ally1Name { get; set; }
        public int Ally1CurrentHealth { get; set; }
        public List<string> DisplayMessages { get; set; }
    }
}