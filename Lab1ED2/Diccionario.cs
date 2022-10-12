using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1ED2
{
    public class Diccionario
    {
        public string dicc()
        {
            string ubicacionArchivo = @"";

            String Descomprimir = "";

            string separador = ",";
            Persona persona;
            persona = new Persona();
            int tamanioFila2=0;
            string salida = "";
            string linea;
            string linea2;
            string linea3;
            char[] charsToTrim1 = { '"', '{', '}', ':' };
            string[] fila2;
            string[] charsToRemove = new string[] { "name", "\"\"", "\"", "dpi", ":", "datebirth", "address", "{", "}", "]", "companies",",," };
            string[] charsToRemove2 = new string[] { "\"\"", "\"" };

            string[] charsToRemove4 = new string[] { "C:","Users","luis1","Downloads","\\","inputs","REC -","crypted-","crypted"};


            string[] comprimir;
            string total = "";
            string total2 = "";

            Dictionary<string, Persona> names2 = new Dictionary<string, Persona>();

            int cont = 0;

            int conta1 = 0;
            int conta2 = 0;
            int conta3 = 0;
            string companiastring = "";


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
                    linea= linea.Replace("INSERT;","INSERT," );
                    linea = linea.Replace("DELETE;", "DELETE,");
                    linea = linea.Replace("PATCH;", "PATCH,");
                }

                
                string[] fila = linea.Split(separador);
                string accion = fila[0];
                string nombre = fila[1];
                string dpi = fila[2];
                string fecha = fila[3];
                string direccion = fila[4];
                string[] compania=linea.Split("[");
                

                string compania1=compania[1];
                compania1.ToString();
                companiastring = compania1;
               
                
                if (accion == "INSERT")
                {
                    names2.Add(dpi, new Persona { Name = nombre, dpi = dpi, date = fecha, direccion = direccion, compania1 = compania1 });
                    persona.Name = nombre;
                    persona.dpi = dpi;
                    persona.date = fecha;
                    persona.direccion = direccion;

                    Console.WriteLine(persona.Name);
                    Console.WriteLine(persona.dpi);
                    Console.WriteLine(persona.compania1);
                    Console.WriteLine(compania1);




                    conta1++;





                }
                else if (accion == "PATCH")
                {
                    names2.Remove(dpi);
                    names2.Add(dpi, new Persona { Name = nombre, dpi = dpi, date = fecha, direccion = direccion, compania1 = compania1 });
                    persona.Name = nombre;
                    persona.dpi = dpi;
                    persona.date = fecha;
                    persona.direccion = direccion;

                    Console.WriteLine("Actualizado");
                    Console.WriteLine(persona.Name);
                    Console.WriteLine(persona.dpi);
                    Console.WriteLine(persona.compania1);
                    Console.WriteLine(compania1);


                    conta2++;





                }


                else if (accion == "DELETE")
                {
                    Console.WriteLine(nombre + "  eliminado");

                    names2.Remove(dpi);
                    conta3++;



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
                    if (Directory.Exists(carpeta))
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

                string carpeta2 = @"C:\Salidas\Temp";
                try
                {
                    if (Directory.Exists(carpeta2))
                    {

                    }
                    else
                    {
                        Directory.CreateDirectory(carpeta2);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                string carpeta3 = @"C:\Cypher";
                try
                {
                    if (Directory.Exists(carpeta3))
                    {

                    }
                    else
                    {
                        Directory.CreateDirectory(carpeta3);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                string carpeta4 = @"C:\Descypher";
                try
                {
                    if (Directory.Exists(carpeta4))
                    {

                    }
                    else
                    {
                        Directory.CreateDirectory(carpeta4);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                string carpeta5 = @"C:\Compressed";
                try
                {
                    if (Directory.Exists(carpeta5))
                    {

                    }
                    else
                    {
                        Directory.CreateDirectory(carpeta5);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                string carpeta6 = @"C:\Decompressed";
                try
                {
                    if (Directory.Exists(carpeta6))
                    {

                    }
                    else
                    {
                        Directory.CreateDirectory(carpeta6);
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



                foreach (var x in names2.Values)
                {

                    if (x.Name == dpi1 || x.dpi == dpi1)
                    {
                        Console.WriteLine("{" + "\"" + "name" + "\"" + ":" + "\"" + x.Name + "\"" + ", " + "\"" + "dpi" + "\"" + ":" + "\"" + x.dpi + "\"" + ", " + "\"" + "dateBirth" + "\"" + ":" + "\"" + x.date + "\"" + ", " + "\"" + "address" + "\"" + ":" + "\"" + x.direccion + "\"" + ", " + "\"" + "companies" + "\"" + ":" + "[" + "\"" + x.compania1 + "\"" + "]" + "}");
                        salida += ("{" + "\"" + "name" + "\"" + ":" + "\"" + x.Name + "\"" + ", " + "\"" + "dpi" + "\"" + ":" + "\"" + x.dpi + "\"" + ", " + "\"" + "dateBirth" + "\"" + ":" + "\"" + x.date + "\"" + ", " + "\"" + "address" + "\"" + ":" + "\"" + x.direccion + "\"" + ", " + "\"" + "companies" + "\"" + ":" + "[" + "\"" + x.compania1 + "\"" + "]" + "}" + "\n");

                    }

                }

                string path = @"C:\Salidas\" + dpi1 + "output.json";
                try
                {
                    // Create the file, or overwrite if the file exis
                    using (FileStream fs = File.Create(path))
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes(salida);
                        // Add some information to the file.
                        fs.Write(info, 0, info.Length);
                    }

                    // Open the stream and read it back.

                }

                catch (Exception ex)
                {
                    Console.WriteLine("Archivo no Creado");
                }
;

                Console.ReadKey();

                try
                {
                    string temp = @"C:\Salidas\Temp\temp.txt";

                    foreach (var x in names2.Values)
                    {

                        if (dpi1 == x.dpi)
                        {
                            string salidatemp = x.compania1;
                            try
                            {
                                // Create the file, or overwrite if the file exis
                                using (FileStream fs = File.Create(temp))
                                {
                                    byte[] info = new UTF8Encoding(true).GetBytes(salidatemp);
                                    // Add some information to the file.
                                    fs.Write(info, 0, info.Length);
                                }

                                // Open the stream and read it back.
                                using (StreamReader sr = File.OpenText(temp))
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

                        }

                    }
                    System.IO.StreamReader archivo2 = new System.IO.StreamReader(@temp);

                    Console.WriteLine("Desea descomprimir S/N");
                    Descomprimir=Console.ReadLine();

                   
                        

                    try
                    {


                        while ((linea2 = archivo2.ReadLine()) != null)
                        {
                            fila2 = linea2.Split(separador);

                            for (int i = 0; i < fila2.Length; i++)
                            {
                                string compania = fila2[i];


                                string direccion = compania + dpi1;
                                Encoder encoder = new Encoder(direccion, compania);
                                if (Descomprimir == "S")
                                {
                                    Decoder decoder = new Decoder(encoder.codes, encoder.message);
                                }
                                
                                string hola = encoder.valor;
                                Console.WriteLine(hola);
                                
                                System.IO.StreamReader archivo3 = new System.IO.StreamReader(@"C:\Salidas\Temporal\" + fila2[i] + "salidas.txt");
                                while ((linea3 = archivo3.ReadLine()) != null)
                                {
                                    total += "\"" + fila2[i] + "\"" + " :" + "\"" + linea3 + "\"" + ",";

                                }
                                archivo3.Close();

                                string tempc = @"C:\Salidas\Temp\" + compania.TrimStart() + ".txt";



                                // Create the file, or overwrite if the file exis
                                using (FileStream fs = File.Create(tempc))
                                {
                                    byte[] info = new UTF8Encoding(true).GetBytes(direccion);
                                    // Add some information to the file.
                                    fs.Write(info, 0, info.Length);
                                }

                            }

                            tamanioFila2 = fila2.Length;


                        }


                    }

                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }

                }
                catch (Exception)
                {

                    throw;
                }

                Console.WriteLine("comprimiendo");


                foreach (var x in names2.Values)
                {

                    if (x.dpi == dpi1)
                    {
                        total2.Trim('\n');
                        total2 += ("{" + "\"" + "name" + "\"" + ":" + "\"" + x.Name + "\"" + ", " + "\"" + "dpi" + "\"" + ":" + "\"" + x.dpi + "\"" + ", " + "\"" + "dateBirth" + "\"" + ":" + "\"" + x.date + "\"" + ", " + "\"" + "address" + "\"" + ":" + "\"" + x.direccion + "\"" + ", " + "\"" + "companies" + "\"" + ":" + "[" + total + "\"" + "]" + "}" + "\n");


                    }

                }
               using (FileStream fs = File.Create(@"C:\Salidas\SalidaComprimida"+dpi1+".txt"))
               {
                    byte[] info = new UTF8Encoding(true).GetBytes(total2);
                   // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }


                
                string seguir = Console.ReadLine();
                if (seguir == "s")
                {
                    busqueda = false;
                    salida = "";
                    total2 = "";
                    total = "";
                }
               
                else
                {
                    busqueda = true;
                   
                }

            }


            if (busqueda == true)
            {
                Ordenar();
            }

           


            if (busqueda == true)
            {
                Ordenar();
            }

            void Ordenar()
            {
                string cartapath = "";

                Console.WriteLine(" desea realizar una compresion de cartas de recomendacion");

                Console.WriteLine("ingrese el path de la carta a leer");
                cartapath = Console.ReadLine();

                try
                {
                    foreach (var c in charsToRemove2)
                    {
                        cartapath = cartapath.Replace(c, string.Empty);
                    }
                    CompresorHuff compresor = new CompresorHuff(1024);

                    string dirr = cartapath;
                    foreach (var c in charsToRemove4)
                    {
                        dirr = dirr.Replace(c, string.Empty);
                    }
                    compresor.Comprimir(@cartapath, @"C:\Compressed\", "Compressed-"+dirr);
                    Console.WriteLine(dirr);
                    compresor.Descomprimir(@"C:\Compressed\Compressed-" + dirr + ".txt", @"C:\Decompressed\Decompressed-");
                    string seguircartas = "";
                    Console.WriteLine("Comprimir mas cartas?");
                    seguircartas = Console.ReadLine();
                    if(seguircartas=="S")
                    {
                        Ordenar();
                    }
                    else
                    {
                        Ordenar2();
                    }

                }
                catch (Exception)
                {

                    throw;
                }
            }

            void Ordenar2()
            {
                string cartapath = "";

                Console.WriteLine(" desea realizar un cifrado de chats");

                Console.WriteLine("ingrese el path de la carta a leer");
                cartapath = Console.ReadLine();

                try
                {
                    foreach (var c in charsToRemove2)
                    {
                        cartapath = cartapath.Replace(c, string.Empty);
                    }
                    CifradorCesar cifrado = new CifradorCesar(1024);
                    string clave = "Estructuras";
                    //Console.WriteLine("clave");
                    //clave = Console.ReadLine();

                    string dirr = cartapath;
                    foreach (var c in charsToRemove4)
                    {
                        dirr = dirr.Replace(c, string.Empty);
                    }
                    cifrado.Cifrar(@cartapath, @"C:\Cypher\",clave, "Cypher-" + dirr);
                    Console.WriteLine(dirr);
                    cifrado.Decifrar(@"C:\Cypher\Cypher-" + dirr + ".txt", @"C:\Descypher\",clave, "Descypher-"+dirr);
                    string seguircartas = "";
                    Console.WriteLine("Cifrar mas cartas?");
                    seguircartas = Console.ReadLine();
                    if (seguircartas == "S")
                    {
                        Ordenar2();
                    }
                    else
                    {

                    }

                }
                catch (Exception)
                {

                    throw;
                }
            }


            return salida;

        }




    }
}


    
