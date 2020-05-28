using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Libro l1 = new Libro("La insoportable levedad del ser", "Kundera, Milan");
            Libro l2 = new Libro("Cien años de soledad", "Garcia Marquez, Gabriel");
            Libro l3 = new Libro("Rayuela", "Cortazar, Julio");
            Libro l4 = new Libro("ZZZ", "Aaaaaa");
            Libro l5 = new Libro("AAA", "Zzzzzzz");

            Libro[] biblioteca = { l1, l2, l3, l4, l5 };

            foreach (Libro l in biblioteca)
            {
                l.Describir();
            }

            Console.WriteLine("\n****************************\n");

            Array.Sort(biblioteca);

            Console.WriteLine("Ordenado por título:");
            foreach (Libro l in biblioteca)
            {
                l.Describir();
            }

            Console.ReadKey();
        }
    }
}
