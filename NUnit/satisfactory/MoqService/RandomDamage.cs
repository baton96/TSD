using System;

namespace MoqService
{
    public class RandomDamage : IParameters 
    {
        public string name { get;set; }
        public int damage { get => damageRand(); }
        public int health { get;set; }

        virtual protected int damageRand() {
            return new Random().Next(10);
        }
    }
}

