using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dados_con_apuestas
{
    class Apuesta
    {
        private int numero;
        private ModoApuesta modoApuesta;
        private float monto;

        public Apuesta(int numero, ModoApuesta modoApuesta, float monto)
        {
            this.numero = numero;
            this.modoApuesta = modoApuesta;
            this.monto = monto;
        }

        public int GetNumero() => numero;
        public float GetMonto() => monto;

        // En caso de ganar la apuesta
        public float Pagar()
        {
            float monto = 0;

            if (modoApuesta == ModoApuesta.CONSERVADOR)
            {
                monto = this.monto * 2;
            }
            else if (modoApuesta == ModoApuesta.ARRIESGADO)
            {
                monto = this.monto * 5;
            }
            else if (modoApuesta == ModoApuesta.DESESPERADO)
            {
                monto = this.monto * 15;
            }

            return monto;
        }
        
        // En caso de perder la apuesta
        public float Cobrar()
        {
            float monto = 0;

            if (modoApuesta == ModoApuesta.CONSERVADOR)
            {
                monto = this.monto;
            }
            else if (modoApuesta == ModoApuesta.ARRIESGADO)
            {
                monto = this.monto * 2;
            }
            else if (modoApuesta == ModoApuesta.DESESPERADO)
            {
                monto = this.monto * 4;
            }

            return monto;
        }
    }

    public enum ModoApuesta
    {
        CONSERVADOR, ARRIESGADO, DESESPERADO
    }
}
