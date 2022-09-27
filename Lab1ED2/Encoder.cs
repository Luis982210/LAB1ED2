using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1ED2
{
    class Encoder
    {
        public string valor = "";
        public string s = "";
        string Cadenafinal = "";
        string[] stringArray = new string[40];
        public String message { get; set; }
        public List<Code> codes { get; set; }
        int con = 0;
        public Encoder(String toencode,string compania)
        {
            
            string companiacomprimir=compania;
            
            Dictionary<char, int> values = new Dictionary<char, int>();
            foreach (char ch in toencode)
            {
                if (!values.ContainsKey(ch))
                {
                    values.Add(ch, 0);
                }
                values[ch]++;
            }
            
            List<Node> nodes = new List<Node>();
            
            foreach (KeyValuePair<char, int> symbol in values)
            {
                nodes.Add(new Node() { Symbol = symbol.Key, Frequency = symbol.Value });
            }
           
            while (nodes.Count > 1)
            {
                
                List<Node> orderedNodes = nodes.OrderBy(node => node.Frequency).ToList<Node>();
                if (orderedNodes.Count >= 2)
                {
                    
                    List<Node> taken = orderedNodes.Take(2).ToList<Node>();
                    Node parent = new Node()
                    {
                        Symbol = '*',
                        Frequency = taken[0].Frequency + taken[1].Frequency,
                        Bottom = taken[0],
                        Top = taken[1]
                    };
                    
                    nodes.Remove(taken[0]);
                    nodes.Remove(taken[1]);
                    nodes.Add(parent);
                }

            }
            Node Root = nodes.FirstOrDefault();
            Console.WriteLine("codificacion:");
            
            codes = new List<Code>();
            foreach (KeyValuePair<char, int> symbol in values)
            {
                Console.WriteLine();
                Console.Write(symbol.Key + " -> ");
                List<Char> encoded = Root.FindPath(symbol.Key, new List<Char>());
                String cod = "";
                foreach (Char enc in encoded)
                {
                    Console.Write(enc);
                    cod = cod + enc;
                }
                Code code = new Code() { Symbol = symbol.Key, code = cod };
                codes.Add(code);
            }
            Console.WriteLine();


            Console.WriteLine();
            Console.WriteLine("Mensaje:");
           
            

           message = "";
            foreach (char ch in toencode)
            {
                List<Char> encoded = Root.FindPath(ch, new List<Char>());
                foreach (Char enc in encoded)
                {
                    Console.Write(enc);
                    valor=valor + enc;
                    message = message + enc;

                    
                    
                }
                
            }

            byte[] bufferBytesCompresion;
            String[] bufferBytesescritura;
            BinaryWriter bw = new BinaryWriter(new FileStream(@"C:\Salidas\Temporal\"+compania+"salidas.txt", FileMode.OpenOrCreate));
            int numbytes = valor.Length / 8;
           int  residuoCadena = valor.Length % 8;
            bufferBytesCompresion = new byte[numbytes];
            bufferBytesescritura=new String[numbytes];
            


            for (int j = 0; j < numbytes; j++)
            {
                bufferBytesCompresion[j] = Convert.ToByte(valor.ToString().Substring(8 * j, 8), 2);
            }
            string cadenacaracter = "";



            bw.Write(bufferBytesCompresion);

            cadenacaracter = "";
            if (residuoCadena != 0)
            {

                string temp = valor.ToString().Substring(numbytes * 8, residuoCadena);
                int cantidadCeros = 8 - residuoCadena;
                for (int i = 0; i < cantidadCeros; i++)
                {
                    temp = temp + "0";
                }


                bw.Write(Convert.ToByte(temp, 2));
            }
            else
            {
                
            }
            bw.Close();
            
            
           
            

        }

       
        
       
       

    }
}
