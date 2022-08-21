using System.IO;
using System.Collections.Generic;
using System;
using Lab1ED2;
using System.Linq;

string ubicacionArchivo =  @"C:\Users\luis1\OneDrive\Desktop\input.csv";
System.IO.StreamReader archivo = new System.IO.StreamReader(ubicacionArchivo);
string separador = ",";
Persona persona;
persona= new Persona();

string linea;
string linea2;
char[] charsToTrim1 = {'"','{','}',':'};
Dictionary<string, object> names2 = new Dictionary<string, object>();

int conta1=0;
int conta2=0;
int conta3=0;




    while ((linea = archivo.ReadLine()) != null)
    {

        string[] fila = linea.Split(separador);
        string accion = fila[0];
        string nombre = fila[1];
        string dpi = fila[2];
        string fecha = fila[3];
        string direccion = fila[4];
        accion = accion.Trim(charsToTrim1);
        nombre = nombre.Trim(charsToTrim1);
        dpi = dpi.Trim(charsToTrim1);
        fecha = fecha.Trim(charsToTrim1);
        direccion = direccion.Trim(charsToTrim1);

        if (accion == "INSERT")
        {

            names2.Add(dpi, persona);
            persona.Name = nombre;
            persona.dpi = dpi;
            persona.date = fecha;
            persona.direccion = direccion;
            nombre = nombre.Trim(charsToTrim1);
            dpi = dpi.Trim(charsToTrim1);
            fecha = fecha.Trim(charsToTrim1);
            direccion = direccion.Trim(charsToTrim1);
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
            nombre = nombre.Trim(charsToTrim1);
            dpi = dpi.Trim(charsToTrim1);
            fecha = fecha.Trim(charsToTrim1);
            direccion = direccion.Trim(charsToTrim1);
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

            persona.Name = "";
            persona.dpi = "";
            persona.date = "";
            persona.direccion = "";
            nombre = nombre.Trim(charsToTrim1);
            dpi = dpi.Trim(charsToTrim1);
            fecha = fecha.Trim(charsToTrim1);
            direccion = direccion.Trim(charsToTrim1);
            Console.WriteLine(persona.Name);
            Console.WriteLine(persona.dpi);
            Console.WriteLine(persona.date);
            Console.WriteLine(persona.direccion);
        conta3++;




    }

}
Console.WriteLine("ingresados= "+conta1);
Console.WriteLine("actualizados= " + conta2);
Console.WriteLine("eliminados=" + conta3);
Console.WriteLine("ingrese dpi a buscar");
    string dpi1=Console.ReadLine();

   

    Console.ReadKey();




  
    











 



        
    

