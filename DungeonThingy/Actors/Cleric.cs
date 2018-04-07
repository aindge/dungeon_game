using System;
using System.Collections.Generic;
using System.Linq;
using DungeonThingy.Core;

namespace DungeonThingy.Actors
{
    public class Cleric : Player
    {
        public Cleric(IGameContext context) : base(context)
        {
            Strength = 3;
            Intelligence = 8;
            Defense = 5;
            Resistance = 6;
            Speed = 6;
            InitMana(50);
            InitHealth(50);
        }

        public override void InitSkills()
        {
            SkillSet.Add("Attack", BaseSkills.AttackSkill(DamageType.Physical, () => Strength));

            SkillSet.Add("Heal", new Skill(targets =>
            {
                targets.ForEach(target => target.CurrentHealth += Intelligence);
                return Intelligence;
            })
            {
                TargetingType = TargetingType.OneAlly,
                DisplayMessage = "{SELF} heals {TARGET} for {AMOUNT} health!",
                ManaCost = 10,
            });


        }
    }
}