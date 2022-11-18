using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeDex
{
    internal class PokeDex
    {
        public int Generation { get;  set; }
        public string DexNum { get;  set; }
        public string Name { get;  set; }
        public string Type { get;  set; }
        public string Weakness { get; set; }
        public string Form { get;  set; }

        public PokeDex(int generation, string dexNum, string name, string type, string weakness, string form)
        {
            Generation = generation;
            DexNum = dexNum;
            Name = name;
            Type = type;
            Weakness = weakness;
            Form = form;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Generation: {Generation}\nDex Number: {DexNum}\nName: {Name}\nType: {Type}\nWeakness: {Weakness}\nForm: {Form}\n");
        }
    }
}
