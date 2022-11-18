using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArvPokemon
{
    internal class Attack
    {
        public string Name { get; set; }
        public double Dmg { get; set; }
        public double LifeSteal { get; set; }
        public string Type { get; set; }

        public Attack(string name, double dmg, double lifeSteal, string type)
        {
            Name = name;
            Dmg = dmg;
            LifeSteal = lifeSteal;
            Type = type;
        }

    }
}
