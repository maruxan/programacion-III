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
            Console.WriteLine($"Carga de datos: {cronometro.Elapsed.TotalSeconds} segundos\n");

            // Ordenamiento de Generics
            Console.WriteLine("Ordenando Generics...");
            cronometro.Reset();
            cronometro.Start();
            bibliotecaGenerics.Sort();
            cronometro.Stop();
            Console.WriteLine($"Ordenamiento de Biblioteca Generics: {cronometro.Elapsed.TotalSeconds} segundos\n");

            // Ordenamiento de Collections
            Console.WriteLine("Ordenando Collections...");
            cronometro.Reset();
            cronometro.Start();
            bibliotecaCollections.Ordenar();
            cronometro.Stop();
            Console.WriteLine($"Ordenamiento de Biblioteca Collections: {cronometro.Elapsed.TotalSeconds} segundos\n");

            // Ordenamiento de Array
            Console.WriteLine("Ordenando Array...");
            cronometro.Reset();
            cronometro.Start();
            QuickSort(bibliotecaArray, 0, bibliotecaArray.Length - 1);
            cronometro.Stop();
            Console.WriteLine($"Ordenamiento de Biblioteca Array: {cronometro.Elapsed.TotalSeconds} segundos\n");

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

        // Ordena un Array de objetos
        public static void QuickSort<T>(T[] arr, int izq, int der) where T : IComparable
        {
            int i, j;
            i = izq; j = der;
            IComparable pivot = arr[izq];

            while (i <= j)
            {
                for (; (arr[i].CompareTo(pivot) < 0) && (i.CompareTo(der) < 0); i++) ;
                for (; (pivot.CompareTo(arr[j]) < 0) && (j.CompareTo(izq) > 0); j--) ;

                if (i <= j)
                    Swap(ref arr[i++], ref arr[j--]);

            }
            if (izq < j) QuickSort<T>(arr, izq, j);
            if (i < der) QuickSort<T>(arr, i, der);
        }
        public static void Swap<T>(ref T x, ref T y)
        {
            T temp = x;
            x = y;
            y = temp;
        }

    }
}
