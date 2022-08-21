using System.IO;
using System.Collections.Generic;
using System;
using Lab1ED2;
using System.Linq;
using System.Text.Json;

string ubicacionArchivo =  @"C:\Users\luis1\OneDrive\Desktop\input.csv";
System.IO.StreamReader archivo = new System.IO.StreamReader(ubicacionArchivo);
string separador = ",";
Persona persona;
persona= new Persona();


string linea;
string linea2;
char[] charsToTrim1 = {'"','{','}',':'};
string[] charsToRemove = new string[] { ";", "name", "\"\"", "\"" ,"dpi",":","datebirth","address","{","}"};
Dictionary<string, Persona> names2 = new Dictionary<string, Persona>();

int cont = 0;

int conta1 =0;
int conta2=0;
int conta3=0;




while ((linea = archivo.ReadLine()) != null)
{
    foreach (var c in charsToRemove)
    {
        linea = linea.Replace(c, string.Empty);
    }

 
        string[] fila = linea.Split(separador);
        string accion = fila[0];
        string nombre = fila[1];
        string dpi = fila[2];
        string fecha = fila[3];
        string direccion = fila[4];


        if (accion == "INSERT")
        {

        names2.Add(dpi, new Persona {Name=nombre,dpi=dpi,date=fecha,direccion=direccion});
            persona.Name = nombre;
            persona.dpi = dpi;
            persona.date = fecha;
            persona.direccion = direccion;
        
        Console.WriteLine(persona.Name);
            Console.WriteLine(persona.dpi);
            Console.WriteLine(persona.date);
            Console.WriteLine(persona.direccion);
            conta1++;
       
           
            


        }
        else if (accion == "PATCH")
        {

            persona.Name = nombre;
            persona.dpi = dpi;
            persona.date = fecha;
            persona.direccion = direccion;

            Console.WriteLine("Actualizado");
            Console.WriteLine(persona.Name);
            Console.WriteLine(persona.dpi);
            Console.WriteLine(persona.date);
            Console.WriteLine(persona.direccion);
            conta2++;

   



    }


    else if (accion == "DELETE")
        {
            Console.WriteLine(nombre + "  eliminado");

        names2.Remove(dpi);
            conta3++;
        persona.captura(nombre, dpi, fecha, direccion);



    }

}
    Console.WriteLine("ingresados= " + conta1);
    Console.WriteLine("actualizados= " + conta2);
    Console.WriteLine("eliminados=" + conta3);
string dpi1 = "";
Console.WriteLine("dpi");
dpi1 =Console.ReadLine();

foreach (var x in names2.Values)
{

    if (x.Name == dpi1)
    {
        Console.WriteLine(x.Name + " " + x.dpi + " " + x.date + " " + x.direccion);
    }


}




Console.ReadKey();




  
    











 



        
    

