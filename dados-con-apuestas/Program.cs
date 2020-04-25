using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dados_con_apuestas
{
    class Program
    {
        static void Main(string[] args)
        {
            Juego juego = new Juego();

            Console.WriteLine("> Bienvenido al juego <");
            Console.WriteLine("Cada ronda los jugadores realizan sus apuestas y se lanzan 2 dados.");
            Console.WriteLine("El juego se acaba cuando uno de los jugadores se queda sin dinero o el pozo llega a 0.");
            Console.WriteLine("\nBuena suerte.\n");
            int ronda = 1;

            while (!juego.GameOver())
            {
                Console.WriteLine($"Ronda {ronda++}\n");
                juego.SiguienteTurno();
            }

            Console.WriteLine("Fin del juego.");
            Console.ReadKey();
        }
    }
}
