using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ArvPokemon;

namespace ArvPokemon
{
    abstract class Pokemon
    {
        public string Name { get; set; }
        protected string Type1 { get; set; }
        protected string Type2 { get; set; }
        public double Health { get; set; }
        public int Speed { get; set; }
        protected Attack[] Attacks { get; set; }
        protected string[] WeakToo { get; set; }
        protected int Defence { get; set; }
        public bool HasFainted;
        protected Attack CurrentAttack;

        protected Pokemon(string name, string type1, string type2, double health, int speed, int defence)
        {
            Name = name;
            Type1 = type1;
            Type2 = type2;
            Health = health;
            Speed = speed;
            Attacks = new Attack[]{};
            string[] WeakToo = new string[]{};
            Defence = defence;
            HasFainted = true;
        }

        public void showHitInfo(double multiplyer, Pokemon opponent)
        {
            Console.WriteLine($"{Name} used {CurrentAttack.Name} and hit for {CurrentAttack.Dmg * multiplyer}");
            opponent.LoosHealth(CurrentAttack.Dmg * multiplyer);
            if (CurrentAttack.LifeSteal >= 1)
            {
                Health += CurrentAttack.LifeSteal * multiplyer;
                Console.WriteLine($"{Name} was healed for {CurrentAttack.LifeSteal * multiplyer}");
            }
        }

        public void Attack(Pokemon opponent) // random attack
        {
            Random random = new Random();
            var randomIndex = random.Next(Attacks.Length);
            CurrentAttack = Attacks[randomIndex];

            if (opponent.WeakToo.Contains(CurrentAttack.Type))
            {
                showHitInfo(2, opponent);
                CheckPokemonStatus(opponent);
            }
            else if (opponent.Type1.Contains(CurrentAttack.Type) || opponent.Type2.Contains(CurrentAttack.Type))
            {
                showHitInfo(0.5, opponent);
                CheckPokemonStatus(opponent);
            }
            else
            {
                showHitInfo(1, opponent);
                CheckPokemonStatus(opponent);
            }
        }

        public void CheckPokemonStatus(Pokemon opponent)
        {
            if (opponent.Health <= 0)
            {
                opponent.HasFainted = false;
            }
        }

        public void Info()
        {
            Console.WriteLine($"{Name} {Health}");
        }

        public void LoosHealth(double Dmg)
        {
            Health -= Dmg;
        }
    }
}