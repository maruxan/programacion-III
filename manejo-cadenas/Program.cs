using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace manejo_cadenas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese texto cifrado:");
            string textoCifrado = Console.ReadLine();
            Console.WriteLine("Ingrese clave:");
            int.TryParse(Console.ReadLine(), out int clave);

            DescifradoCesar(textoCifrado, clave);
            Console.ReadKey();
        }

        public static void DescifradoCesar(string texto, int clave)
        {
            string caracteresDescifrables = "aábcdeéfghiíjklmnñoópqrstuúüvwxyz";
            char[] caracteres = new char[texto.Length];

            for (int i = 0; i < texto.Length; i++)
            {
                // Posición dentro de los caracteres descifrables
                int pos = caracteresDescifrables.IndexOf(texto[i]);

                if (pos == -1) // Si no es un caracter descifrable
                {
                    caracteres[i] = texto[i];
                }
                else
                {
                    // Posición corrida
                    int indice = (pos - clave) % caracteresDescifrables.Length;

                    // Nos mantenemos dentro de los caracteres descifrables
                    if (indice < 0) indice += caracteresDescifrables.Length;

                    // Reconstruimos el texto caracter por caracter
                    caracteres[i] = caracteresDescifrables[indice];
                }
                
            }

            string textoDescifrado = new string(caracteres);
            Console.WriteLine(textoDescifrado);
        }
    }
}
