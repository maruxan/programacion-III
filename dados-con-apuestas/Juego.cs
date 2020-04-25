using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dados_con_apuestas
{
    class Juego
    {
        private double pozo;
        private Jugador[] jugadores;
        private Dado[] dados;

        public Juego()
        {
            pozo = 10000;

            Jugador j1 = new Jugador("Jugador 1", 100);
            Jugador j2 = new Jugador("Jugador 2", 100);
            jugadores = new Jugador[2] { j1, j2 };

            Dado d1 = new Dado();
            Dado d2 = new Dado();
            dados = new Dado[2] { d1, d2 };
        }

       
        // Turno
        public void SiguienteTurno()
        {
            // 1. Realizar apuestas
            PedirApuestas();

            // 2. Validar apuestas
            while (!puedePagar()) PedirApuestas();

            // 3. Lanzar dados
            int res = LanzarDados();

            // 4. Chequar resultados y actualizar saldos
            foreach (Jugador j in jugadores)
            {
                if (j.GetApuesta().GetMonto() <= 0)
                {
                    Console.WriteLine($"{j.GetNombre()} no apostó.");
                    continue;
                }

                float nuevoSaldo = j.GetSaldo();

                if (Acerto(j.GetApuesta(), res))
                {
                    Console.WriteLine($"{j.GetNombre()} acerto!");
                    nuevoSaldo += j.GetApuesta().Pagar();
                    pozo -= j.GetApuesta().Pagar();
                }
                else
                {
                    Console.WriteLine($"{j.GetNombre()} perdio.");
                    nuevoSaldo -= j.GetApuesta().Cobrar();
                    pozo += j.GetApuesta().Cobrar();
                }

                j.SetSaldo(nuevoSaldo);
            }

            // 5. Mostrar saldos actualizados
            Console.WriteLine($"\nPozo: {pozo}");
            foreach (Jugador j in jugadores)
            {
                Console.WriteLine($"Saldo {j.GetNombre()}: {j.GetSaldo()}");
            }

            Console.WriteLine();
        }

        // Condicion de fin de juego
        public bool GameOver()
        {
            // Verifica el saldo de los jugadors
            for (int i = 0; i < jugadores.Length; i++)
            {
                if (jugadores[i].GetSaldo() <= 0)
                {
                    Console.WriteLine($"{jugadores[i].GetNombre()} se quedó sin saldo.");
                    return true;
                }
                else continue;
            }

            // Verifica el pozo
            if (pozo <= 0)
            {
                Console.WriteLine("La casa se quedó sin dinero.");
                return true;
            }

            return false;
        }

        public void PedirApuestas()
        {
            foreach (Jugador j in jugadores)
            {
                Console.WriteLine($"{j.GetNombre()} apostando:");
                Console.WriteLine($"SALDO DISPONIBLE: {j.GetSaldo()}\n");

                Console.Write("> Numero: ");
                int.TryParse(Console.ReadLine(), out int numero);

                Console.Write("> Monto de apuesta: ");
                int.TryParse(Console.ReadLine(), out int monto);

                Console.WriteLine("Modo de Apuesta:");
                Console.WriteLine("1: CONSERVADOR [-1/2]");
                Console.WriteLine("2: ARRIESGADO [-2/5]");
                Console.WriteLine("3: DESESPERADO [-4/15]");
                Console.Write("> Opción: ");
                int.TryParse(Console.ReadLine(), out int m);

                ModoApuesta modoApuesta = ModoApuesta.CONSERVADOR; // Modo de apuesta por defecto
                if (m == 2) modoApuesta = ModoApuesta.ARRIESGADO;
                else if (m == 3) modoApuesta = ModoApuesta.DESESPERADO;

                j.RealizarApuesta(numero, modoApuesta, monto);

                Console.WriteLine();
            }
        }

        public int LanzarDados()
        {
            Console.WriteLine("Se lanzan los dados...");

            int res = 0;
            foreach (Dado d in dados)
            {
                res += d.lanzar();
            }

            Console.WriteLine($"Resultado: {res}");
            return res;
        }

        // Compara la apuesta con el resultado
        public bool Acerto(Apuesta apuesta, int resultado)
        {
            return apuesta.GetNumero() == resultado;
        }

        // Evalua si la casa puede pagar la apuesta en caso de perder
        public bool puedePagar()
        {
            int jugador = mayorApuesta();

            if (jugador != -1)
                return jugadores[jugador].GetApuesta().Pagar() <= pozo; // la puede pagar la mayor apuesta
            else
                return (jugadores[0].GetApuesta().Pagar() * 2) <= pozo; // la puede pagar las dos apuestas
        }

        // Determina que jugador hizo la mayor apuesta,
        // devuelve -1 si las apuestas son iguales
        public int mayorApuesta()
        {
            if (jugadores[0].GetApuesta().Pagar() > jugadores[1].GetApuesta().Pagar())
                return 0;
            else if (jugadores[0].GetApuesta().Pagar() < jugadores[1].GetApuesta().Pagar())
                return 1;
            else
                return -1;
        }
    }
}
