using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopBasics.Console
{
    public class Admin : Person
    {
        public String Password { get; set; }

        public Admin(string name, string surname, string password) :base(name, surname) 
        {
            Password = password;
        }

        //base ključne reči u C# omogućava pozivanje konstruktora roditeljske (baze) klase iz konstruktora izvedene (dijete) klase
    }
}
