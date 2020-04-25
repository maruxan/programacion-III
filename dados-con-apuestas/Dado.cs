using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dados_con_apuestas
{
    class Dado
    {
        private int caras;

        public Dado()
        {
            this.caras = 6;
        }

        public Dado(int caras)
        {
            this.caras = caras;
        }

        public int lanzar()
        {
            Random r = new Random();

            return r.Next(1, this.caras);
        }
    }
}
