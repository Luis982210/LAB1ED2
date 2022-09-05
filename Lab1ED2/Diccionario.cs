using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1ED2
{
    public class Diccionario
    {
        public  string dicc()
        {
            string ubicacionArchivo = @"";


            string separador = ",";
            Persona persona;
            persona = new Persona();

            string salida = "";
            string linea;
            string linea2;
            char[] charsToTrim1 = { '"', '{', '}', ':' };
            string[] charsToRemove = new string[] { ";", "name", "\"\"", "\"", "dpi", ":", "datebirth", "address", "{", "}" };
            string[] charsToRemove2 = new string[] { "\"\"", "\"" };

            Dictionary<string, Persona> names2 = new Dictionary<string, Persona>();

            int cont = 0;

            int conta1 = 0;
            int conta2 = 0;
            int conta3 = 0;



            Console.WriteLine("Estructura de datos para busqueda y de personal");
            Console.WriteLine("presione espacio para continuar");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine(ubicacionArchivo);
            Console.WriteLine("Ingrese el path del archivo CSV");
            ubicacionArchivo = Console.ReadLine();


            foreach (var c in charsToRemove2)
            {
                ubicacionArchivo = ubicacionArchivo.Replace(c, string.Empty);
            }

            System.IO.StreamReader archivo = new System.IO.StreamReader(@ubicacionArchivo);

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

                    names2.Add(dpi, new Persona { Name = nombre, dpi = dpi, date = fecha, direccion = direccion });
                    persona.Name = nombre;
                    persona.dpi = dpi;
                    persona.date = fecha;
                    persona.direccion = direccion;

                    Console.WriteLine(persona.Name);
                    Console.WriteLine(persona.dpi);
                  
                    conta1++;





                }
                else if (accion == "PATCH")
                {
                    names2.Remove(dpi);
                    names2.Add(dpi, new Persona { Name = nombre, dpi = dpi, date = fecha, direccion = direccion });
                    persona.Name = nombre;
                    persona.dpi = dpi;
                    persona.date = fecha;
                    persona.direccion = direccion;

                    Console.WriteLine("Actualizado");
                    Console.WriteLine(persona.Name);
                    Console.WriteLine(persona.dpi);
                  
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
            bool busqueda = false;
            while (busqueda != true)
            {
                Console.WriteLine("buscar persona por nombre o dpi");
                dpi1 = Console.ReadLine();
                
                int contador = 0;
                string nombres = "";

                foreach (var value in names2.Values)
                {

                    if (nombres.Contains(value.Name + "\n"))
                    {
                        contador--;
                    }
                    else
                        nombres += "\n" + value.Name;


                    contador++;

                }

                
                
                string carpeta = @"C:\Salidas";
                try
                {
                    if(Directory.Exists(carpeta))
                    {
                        
                    }
                    else
                    {
                        Directory.CreateDirectory(carpeta);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                string path2 = @"C:\Salidas\diccionario.txt";
                try
                {
                    // Create the file, or overwrite if the file exists.
                    using (FileStream fs = File.Create(path2))
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes(nombres);
                        // Add some information to the file.
                        fs.Write(info, 0, info.Length);
                    }

                    // Open the stream and read it back.
                    using (StreamReader sr = File.OpenText(path2))
                    {
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {

                        }
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Archivo no Creado");
                }

                Console.WriteLine(contador);

                foreach (var x in names2.Values)
                {

                    if (x.Name == dpi1 || x.dpi == dpi1)
                    {
                        Console.WriteLine("{" + "\"" + "name" + "\"" + ":" + "\"" + x.Name + "\"" + ", " + "\"" + "dpi" + "\"" + ":" + "\"" + x.dpi + "\"" + ", " + "\"" + "dateBirth" + "\"" + ":" + "\"" + x.date + "\"" + ", " + "\"" + "address" + "\"" + ":" + "\"" + x.direccion + "\"" + "}");
                        salida += ("{" + "\"" + "name" + "\"" + ":" + "\"" + x.Name + "\"" + ", " + "\"" + "dpi" + "\"" + ":" + "\"" + x.dpi + "\"" + ", " + "\"" + "dateBirth" + "\"" + ":" + "\"" + x.date + "\"" + ", " + "\"" + "address" + "\"" + ":" + "\"" + x.direccion + "\"" + "}" + "\n");

                    }

                }

                string path = @"C:\Salidas\" + dpi1 + "output.json";
                try
                {
                    // Create the file, or overwrite if the file exists.
                    using (FileStream fs = File.Create(path))
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes(salida);
                        // Add some information to the file.
                        fs.Write(info, 0, info.Length);
                    }

                    // Open the stream and read it back.
                    using (StreamReader sr = File.OpenText(path))
                    {
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            
                        }
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Archivo no Creado");
                }

                CompresorHuff tester = new CompresorHuff(1024);
                tester.Comprimir(path,"C:\\","DpiComprimido"+dpi1);
                tester.Descomprimir("C:\\DpiComprimido"+dpi1+".huff","C:\\DpiDescomprimido"+dpi1);
                
                Console.ReadKey();

                Console.WriteLine("desea realizar otra busqueda s/n");
                string seguir = Console.ReadLine();
                if (seguir == "s")
                {
                    busqueda = false;
                    salida = "";
                }
                else
                {
                    busqueda = true;
                }
                
            }
            return salida;
        }

            
        }
    }
