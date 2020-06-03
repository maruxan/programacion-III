using interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collections_vs_generics
{
    class Program
    {
        static Random r = new Random();

        static void Main(string[] args)
        {
            Stopwatch cronometro = new Stopwatch();
            List<Libro> bibliotecaGenerics = new List<Libro>();
            Biblioteca bibliotecaCollections = new Biblioteca();
            Libro[] bibliotecaArray = new Libro[1000000];

            Console.WriteLine("Cargando datos...");
            cronometro.Start();
            // Agregamos un millon de instancias aleatorias
            for (int i = 0; i < 1000000; i++)
            {
                Libro l = RandomLibro();
                bibliotecaGenerics.Add(l);
                bibliotecaCollections.Agregar(l);
                bibliotecaArray[i] = l;
            }
            cronometro.Stop();
            Console.WriteLine($"Carga de datos: {cronometro.Elapsed.Ticks} ticks\n");

            // Ordenamiento de Generics
            Console.WriteLine("Ordenando Generics...");
            cronometro.Reset();
            cronometro.Start();
            bibliotecaGenerics.Sort();
            cronometro.Stop();
            Console.WriteLine($"Ordenamiento de Biblioteca Generics: {cronometro.Elapsed.Ticks} ticks\n");

            // Ordenamiento de Collections
            Console.WriteLine("Ordenando Collections...");
            cronometro.Reset();
            cronometro.Start();
            bibliotecaCollections.Ordenar();
            cronometro.Stop();
            Console.WriteLine($"Ordenamiento de Biblioteca Collections: {cronometro.Elapsed.Ticks} ticks\n");

            // Ordenamiento de Array
            Console.WriteLine("Ordenando Array...");
            cronometro.Reset();
            cronometro.Start();
            Array.Sort(bibliotecaArray);
            cronometro.Stop();
            Console.WriteLine($"Ordenamiento de Biblioteca Array: {cronometro.Elapsed.Ticks} ticks\n");

            Console.WriteLine("Fin del Programa");
            Console.ReadKey();
        }

        // Retorna un string aleatorio del largo especificado
        public static string RandomString(int largo)
        {
            string caracteres = "abcdefghijklmnñopqrstuvwxyz 1234567890";
            StringBuilder stringRandom = new StringBuilder(largo);

            for (int i = 0; i < largo; i++)
            {
                stringRandom.Append(caracteres[r.Next(caracteres.Length)]);
            }

            return stringRandom.ToString();
        }

        // Genera una instancia aleatoria de Libro
        public static Libro RandomLibro()
        {
            return new Libro(RandomString(r.Next(4, 20)), RandomString(r.Next(4, 20)));
        }
    }
}
