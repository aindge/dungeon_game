using System;
using System.Collections.Generic;
using System.Linq;
using DungeonThingy.Core;

namespace DungeonThingy.Actors
{
    public abstract class Actor
    {
        protected readonly IGameContext Context;

        protected Actor(IGameContext context)
        {
            Context = context;
            SkillSet = new Dictionary<string, Skill>();
            InitSkills();
        }

        protected Dictionary<string, Skill> SkillSet { get; set; }

        public string Name { get; protected set; }
        public int MaxHealth { get; protected set; }
        public int CurrentHealth { get; set; }
        public int Strength { get; protected set; }
        public int Intelligence { get; protected set; }
        public int Defense { get; protected set; }
        public int Resistance { get; protected set; }
        public int Speed { get; protected set; }
        public int Mana { get; protected set; }
        public int MaxMana { get; protected set; }

        public abstract void InitSkills();

        public int UseSkill(string command, List<Actor> target)
        {

            var skill = SkillSet[command];
            if (skill is null)
            {
                throw new InvalidOperationException("Ouch");
            }
            Mana -= skill.ManaCost;

            var amount = skill.Invoke(target);
            var displayMessage = skill.FormatDisplayMessage(this, target.FirstOrDefault(), amount);

            Context.DisplayMessages.Add(displayMessage);

            return amount;
        }

        protected void InitHealth(int amount)
        {
            MaxHealth = amount;
            CurrentHealth = amount;
        }

        protected void InitMana(int amount)
        {
            Mana = amount;
            MaxMana = amount;
        }

        public int AssignDamage(int baseAttack, DamageType damageType)
        {
            var damageDealt = 0;
            switch (damageType)
            {
                case DamageType.Physical:
                    damageDealt = baseAttack - Defense;
                    break;
                case DamageType.Magical:
                    damageDealt = baseAttack - Resistance;
                    break;
            }
            CurrentHealth -= damageDealt;
            return damageDealt;
        }
    }
}