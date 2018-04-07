using System;
using System.Linq;

namespace DungeonThingy.Core
{
    public static class BaseSkills
    {
        public static Skill AttackSkill(DamageType damageType, Func<int> getAttackValue) => 
            new Skill(targets => targets.First().AssignDamage(getAttackValue.Invoke(), damageType))
            {
                DisplayMessage = "{SELF} attacls {TARGET} for {AMOUNT} damage!",
                TargetingType = TargetingType.OneEnemy,
            };
    }
}