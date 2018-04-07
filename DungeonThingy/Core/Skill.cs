using System;
using System.Collections.Generic;
using DungeonThingy.Actors;

namespace DungeonThingy.Core
{
    public class Skill
    {
        public Skill(Func<List<Actor>, int> func)
        {
            _skillFunction = func;
        }

        private readonly Func<List<Actor>, int> _skillFunction;
        public TargetingType TargetingType { get; set; }
        public string DisplayMessage { get; set; }
        public int ManaCost { get; set; }

        public string FormatDisplayMessage(Actor self, Actor target, int amount)
        {
            return DisplayMessage.Replace("{SELF}", self.Name)
                                 .Replace("{TARGET}", target?.Name ?? string.Empty)
                                 .Replace("{AMOUNT}", amount.ToString());
        }

        public int Invoke(List<Actor> actors)
        {
            return _skillFunction.Invoke(actors);
        }
    }
}