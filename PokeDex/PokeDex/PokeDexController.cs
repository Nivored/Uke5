using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;

namespace PokeDex
{
    internal class PokeDexController
    {
        private List<PokeDex> pokeDexList = new List<PokeDex>();

        private List<Type> typeList = new List<Type>()
        {
            new Type(1, "Fire"),
            new Type(2, "Water"),
            new Type(3, "Grass"),
            new Type(4, "Dark"),
            new Type(5, "Poison"),
            new Type(6, "Fairy"),
            new Type(7, "Steel"),
            new Type(8, "Dragon"),
            new Type(9, "Ground"),
            new Type(10, "Rock"),
            new Type(11, "Flying"),
            new Type(12, "Normal"),
            new Type(13, "Bug"),
            new Type(14, "Psychic"),
            new Type(15, "Ghost"),
            new Type(16, "Electric"),
            new Type(17, "Ice"),
            new Type(18, "Fighting"),
        };

        private List<Form> formList = new List<Form>()
        {
            new Form(1, "Normal"),
            new Form(2, "Alolan"),
            new Form(3, "Galarian"),
            new Form(4, "Hisuian"),
            new Form(5, "Paldean"),
        };

        public PokeDexController()
        {
            var fileName = "Pokemon.json";
            var jsonString = File.ReadAllText(fileName);
            pokeDexList = JsonSerializer.Deserialize<List<PokeDex>>(jsonString)!;
        }

        public void ShowTypes()
        {
            foreach (var type in typeList)
            {
                Console.WriteLine($"{type.Id}: {type.TypeName}");
            }
        }

        public void ShowList()
        {
            Console.Clear();
            foreach (var pokemon in pokeDexList.ToList())
            {
                pokemon.PrintInfo();
            }
            Console.ReadLine();
            Console.Clear();
            MenuInfo();
        }

        public void AddToPokeDex()
        {
            Console.WriteLine("Add Generation");
            var genInput = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Add Dex Number");
            var dexinput = Console.ReadLine();
            Console.WriteLine("Add Name");
            var nameInput = Console.ReadLine();
            Console.WriteLine("Add Type");
            var typeInput = Console.ReadLine();
            Console.WriteLine("Add Weakness");
            var weaknessInput = Console.ReadLine();
            Console.WriteLine("Add Form");
            var formInput = Console.ReadLine();
            pokeDexList.Add(new PokeDex(genInput, dexinput, nameInput, typeInput, weaknessInput, formInput));

            var options = new JsonSerializerOptions();
            options.WriteIndented = true;
            string output = JsonSerializer.Serialize<List<PokeDex>>(pokeDexList, options);
            var fileName = "Pokemon.json";
            File.WriteAllText(fileName, output);
        }

        public void MenuInfo()
        {
            while (true)
            {
                Console.WriteLine($"1: Look at Pokedex");
                Console.WriteLine($"2: Add to Pokedex");
                Console.WriteLine($"3: Search Pokedex");
                Console.WriteLine($"4: Exit Pokedex");
                MenuInputs();
            }
        }

        public void MenuInputs()
        {
            var input = Convert.ToInt32(Console.ReadLine());
            if(input == 1){ ShowList(); }
            else if(input == 2) { AddToPokeDex(); }
            else if (input == 3) { SearchPokeDexMenu(); }
            else if (input == 4) {  }
        }

        public void SearchPokeDexMenu()
        {
            Console.Clear();
            Console.WriteLine($"1: Search Generation");
            Console.WriteLine($"2: Search Dex Number");
            Console.WriteLine($"3: Search Name");
            Console.WriteLine($"4: Search Type");
            Console.WriteLine($"5: Search Form");
            Console.WriteLine($"6: Search Weakness");
            SearchMenuInputs();
        }

        public void SearchMenuInputs()
        {
            var input = Convert.ToInt32(Console.ReadLine());
            if (input == 1) {  }
            else if (input == 2) {  }
            else if (input == 3) {  }
            else if (input == 4) { TypeSelection(); }
            else if (input == 5) {  }
            else if (input == 6) { WeaknessSelection(); }
        }

        public void TypeSelection()
        {
            Console.Clear();
            ShowTypes();
            Console.WriteLine("Enter The Id of the type you want to search for");
            var input = Convert.ToInt32(Console.ReadLine());

            var selectedType = typeList.FindAll(types => types.Id == input);

            foreach (var type in selectedType)
            {
                foreach (var pokemon in pokeDexList)
                {
                    if (pokemon.Type.ToLower().Contains(type.TypeName.ToLower()))
                    {
                        pokemon.PrintInfo();
                    }
                }
            }
        }

        public void WeaknessSelection()
        {
            Console.Clear();
            ShowTypes();
            Console.WriteLine("Enter The Id of the Weakness you want to search for");
            var input = Convert.ToInt32(Console.ReadLine());

            var selectedType = typeList.FindAll(types => types.Id == input);

            foreach (var type in selectedType)
            {
                foreach (var pokemon in pokeDexList)
                {
                    if (pokemon.Weakness.ToLower().Contains(type.TypeName.ToLower()))
                    {
                        pokemon.PrintInfo();
                    }
                }
            }
        }
    }
}
