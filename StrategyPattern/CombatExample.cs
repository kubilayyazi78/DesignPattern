using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    internal class CombatExample
    {


        class Character
        {
            private ICombatStrategy strategy;
            public Character(ICombatStrategy combatStrategy)
            {
                strategy = combatStrategy;
            }
            public Character()
            {

            }
            public void SetCombatStrategy(ICombatStrategy combatStrategy)
            {
                strategy = combatStrategy;
            }
            public void ApplyAttackStrategy()
            {
                strategy.Attack();
            }
        }
        interface ICombatStrategy
        {
            void Attack();
        }
        class AggressiveCombatStrategy : ICombatStrategy
        {
            public void Attack()
            {
                Console.WriteLine("Agressive Attack");
            }
        }

        class DefensiveCombatStrategy : ICombatStrategy
        {
            public void Attack()
            {
                Console.WriteLine("Defensive Attack");
            }
        }
    }
}
//var ch = new Character(new AggressiveCombatStrategy());
//ch.ApplyAttackStrategy();

//ch.SetCombatStrategy(new DefensiveCombatStrategy());
//ch.ApplyAttackStrategy();

//Console.ReadLine();