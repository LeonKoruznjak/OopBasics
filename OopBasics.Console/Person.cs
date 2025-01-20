using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopBasics.Console
{
    public abstract class Person
    {
        public String Name {  get; set; }

        public String Surname { get; set; }

        // Konstruktor
        public Person(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }


    }
}
