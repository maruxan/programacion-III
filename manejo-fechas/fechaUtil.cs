using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace manejo_fechas
{
    class fechaUtil
    {
        private static int[,] feriados =
        {
            { 1, 1 },       // Año Nuevo
            { 2, 24 },      // Carnaval
            { 2, 25 },
            { 3, 24 },      // Día de la Memoria
            { 3, 31 },      // Veteranos de Malvinas
            { 5, 1 },       // Día del Trabajador
            { 5, 25 },      // Revolución de Mayo
            { 6, 20 },      // Día de la Bandera
            { 7, 9 },       // Día de la Independencia
            { 12, 8 },      // Inmaculada Concepción
            { 12, 25 },     // Navidad
        };

        public static int[,] Feriados { get => feriados; set => feriados = value; }

        public static bool EsFeriado(DateTime fecha)
        {
            for (int i = 0; i < Feriados.GetLength(0); i++)
            {
                if (Feriados[i, 0] == fecha.Month && Feriados[i, 1] == fecha.Day) return true;
            }

            return false;
        }

        public static bool EsFinDeSemana(DateTime fecha)
        {
            return (fecha.DayOfWeek == DayOfWeek.Saturday || fecha.DayOfWeek == DayOfWeek.Sunday);
        }

        public static int ObtenerDiasCalendario(DateTime fecha1, DateTime fecha2)
        {
            TimeSpan diasCalendario = fecha1 - fecha2;
            return Math.Abs(diasCalendario.Days);
        }

        public static int ObtenerDiasLaborales(DateTime fecha1, DateTime fechaFin)
        {
            DateTime fechaAux;

            if (fecha1 > fechaFin) fechaAux = fechaFin;
            else fechaAux = fecha1;

            int diasTranscurridos = ObtenerDiasCalendario(fecha1, fechaFin);
            int diasLaborales = diasTranscurridos;

            for (int i = 0; i < diasTranscurridos; i++)
            {
                if (EsFeriado(fechaAux) || EsFinDeSemana(fechaAux)) diasLaborales--;
                fechaAux = fechaAux.AddDays(1);
            }

            return diasLaborales;
        }

        public static int SumarDiasLaborables(DateTime fecha, int dias)
        {
            DateTime fechaAux = fecha.AddDays(dias);
            return ObtenerDiasLaborales(fecha, fechaAux);
        }

    }
}
