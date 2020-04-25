using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dados_con_apuestas
{
    class Jugador
    {
        private string nombre;
        private float saldo;
        private Apuesta apuesta;

        public Jugador(string nombre, float saldo)
        {
            this.nombre = nombre;
            this.saldo = saldo;
        }

        public string GetNombre()
        {
            return this.nombre;
        }

        public void SetSaldo(float saldo)
        {
            this.saldo = saldo;
        }

        public float GetSaldo() => this.saldo;

        // Evalua si el jugador puede pagar la apuesta en caso de perder
        public bool puedePagar(Apuesta a)
        {
            return a.Cobrar() <= saldo;
        }

        public void RealizarApuesta(int numero, ModoApuesta modoApuesta, float monto)
        {
            Apuesta a = new Apuesta(numero, modoApuesta, monto);

            if (puedePagar(a))
                this.apuesta = a;
            else
            {
                Console.WriteLine("La apuesta supera el saldo disponible");
                apuesta = new Apuesta(0, ModoApuesta.CONSERVADOR, 0);
            }
        }

        public Apuesta GetApuesta() => this.apuesta;
    }
}
