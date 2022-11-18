using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeDex
{
    internal class Form
    {
        public int Id { get; set; }
        public string FormName { get; set; }
        public Form(int id, string formName)
        {
            Id = id;
            FormName = formName;
        }
    }
}
