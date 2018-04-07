using System;
using System.Collections.Generic;
using System.Linq;
using DungeonThingy.Core;

namespace DungeonThingy.Actors
{
    public abstract class Enemy : Actor
    {
        public virtual void Act()
        {
            var rand = new Random();
            var isValidCommand = false;
            KeyValuePair<string, Skill> skillChoice = new KeyValuePair<string, Skill>();
            var targets = new List<Actor>();
            while (!isValidCommand)
            {
                skillChoice = SkillSet.ToList()[rand.Next(SkillSet.Count)];

                switch (skillChoice.Value.TargetingType)
                {
                    case TargetingType.Self:
                        targets.Add(this);
                        break;
                    case TargetingType.OneAlly:
                        targets.Add(Context.Enemies[rand.Next(Context.Enemies.Count)]);
                        break;
                    case TargetingType.OneOtherAlly:
                        if (Context.Enemies.Count == 1)
                        {
                            continue;
                        }
                        Actor target = this;
                        while(target == this)
                            target = Context.Enemies[rand.Next(Context.Enemies.Count)];
                        targets.Add(target);
                        break;
                    case TargetingType.OneEnemy:
                        targets.Add(Context.Allies[rand.Next(Context.Allies.Count)]);
                        break;
                    case TargetingType.AllAllies:
                        targets.AddRange(Context.Enemies);
                        break;
                    case TargetingType.AllEnemies:
                        targets.AddRange(Context.Allies);
                        break;
                    case TargetingType.Everyone:
                        targets.AddRange(Context.AllActors);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                isValidCommand = true;
            }
            UseSkill(skillChoice.Key, targets);
        }

        public Enemy(IGameContext context) : base(context)
        {
        }

        public override void InitSkills()
        {
            throw new System.NotImplementedException();
        }
    }
}