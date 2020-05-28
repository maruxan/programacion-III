using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace parcial1_parte2
{
    class Program
    {

        static Random r = new Random();

        static void Main(string[] args)
        {

            DateTime desde = new DateTime();
            DateTime hasta = DateTime.Now;

            // Generamos 10 fechas
            DateTime[] fechas = GenerarFechas(desde, hasta, 10);

            // Dividimos el tiempo en 3 intervalos
            DateTime[] intervalos = GenerarIntervalos(desde, hasta, 3);

            // Calculamos distribucion
            DistribucionEnIntervalos(fechas, intervalos);

            Console.ReadKey();

        }

        static DateTime FechaEnRango(DateTime desde, DateTime hasta)
        {
            DateTime nuevaFecha = desde;
            TimeSpan intervalo = hasta - desde;
            var ticks = (long)(intervalo.Ticks * r.NextDouble());
            return nuevaFecha.AddTicks(ticks);
        }

        static DateTime[] GenerarFechas(DateTime desde, DateTime hasta, int cant)
        {
            DateTime[] fechas = new DateTime[cant];

            for (int i = 0; i < fechas.Length; i++)
            {
                fechas[i] = FechaEnRango(desde, hasta);
            }

            return fechas;
        }

        static DateTime[] GenerarIntervalos(DateTime desde, DateTime hasta, int cant)
        {
            DateTime[] intervalos = new DateTime[cant];

            TimeSpan intervaloTotal = hasta - desde;
            long subIntevalo = intervaloTotal.Ticks / cant; 

            for (int i = 0; i < intervalos.Length; i++)
            {
                if (i == 0) intervalos[i] = desde.AddTicks(subIntevalo);
                else
                {
                    intervalos[i] = intervalos[i - 1].AddTicks(subIntevalo);
                }
            }

            return intervalos;
        }

        static void DistribucionEnIntervalos(DateTime[] fechas, DateTime[] intervalos)
        {
            int[] contador = new int[intervalos.Length];

            for (int i = 0; i < intervalos.Length; i++)
            {
                contador[i] = 0;

                for (int j = 0; j < fechas.Length; j++)
                {
                    if (i == 0 && fechas[j] <= intervalos[i])
                        contador[i]++;
                    else if (fechas[j] <= intervalos[i] && fechas[j] > intervalos[i-1])
                    {
                        contador[i]++;
                    }
                }
            }

            for (int i = 0; i < intervalos.Length; i++)
            {
                Console.WriteLine($"Intervalo {i+1}: {contador[i]} fechas -- {(double)contador[i]/fechas.Length*100}%");
            }
        }
    }
}
