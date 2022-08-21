using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1ED2
{
    internal class Persona
    {
        public string Name { get; set; }
        public string dpi { get; set; }
        public string date { get; set; }
        public string direccion { get; set; }

        public void captura(string name, string dpi, string date, string direccion)
        { 
        name=Name; 
        dpi=dpi;
        date=date;
        direccion=direccion;

       
        }

      

    }
}
