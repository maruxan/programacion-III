using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace manejo_fechas
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime fecha1 = new DateTime(2020, 12, 1);
            DateTime fecha2 = fecha1.AddDays(30);
            Console.WriteLine(fecha1);
            Console.WriteLine(fecha2);
            Console.WriteLine($"Dias transcurridos: {fechaUtil.ObtenerDiasCalendario(fecha1, fecha2)}");
            Console.WriteLine($"Dias laborales: {fechaUtil.ObtenerDiasLaborales(fecha1, fecha2)}");

            Console.ReadKey();
        }
    }
}
