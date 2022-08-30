using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab1ED2;

namespace Lab1ED2
{
    [TestClass]
    public class Pruebas
    {
        [TestMethod]
        public void TestMethod()
        {
            
            Diccionario diccionario = new Diccionario();
            string result = diccionario.dicc();
            Assert.AreEqual("{" + "\"" + "name" + "\"" + ":" + "\"" + "ali" + "\"" + ", " + "\"" + "dpi" + "\"" + ":" + "\"" + "9835194631290" + "\"" + ", " + "\"" + "dateBirth" + "\"" + ":" + "\"" + "1992-01-21T025554.542Z" + "\"" + ", " + "\"" + "address" + "\"" + ":" + "\"" + "redmond" + "\"" + "}" + "\n" + "{" + "\"" + "name" + "\"" + ":" + "\"" + "ali" + "\"" + ", " + "\"" + "dpi" + "\"" + ":" + "\"" + "5799860364367" + "\"" + ", " + "\"" + "dateBirth" + "\"" + ":" + "\"" + "1969-05-16T033003.092Z" + "\"" + ", " + "\"" + "address" + "\"" + ":" + "\"" + "wichita" + "\"" + "}" + "\n" + "{" + "\"" + "name" + "\"" + ":" + "\"" + "ali" + "\"" + ", " + "\"" + "dpi" + "\"" + ":" + "\"" + "5605960558536" + "\"" + ", " + "\"" + "dateBirth" + "\"" + ":" + "\"" + "1962-07-01T025720.783Z" + "\"" + ", " + "\"" + "address" + "\"" + ":" + "\"" + "bellingham" + "\"" + "}" + "\n", result);
          

        }

    }
}
