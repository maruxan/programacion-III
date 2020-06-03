using interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collections_vs_generics
{
    class Biblioteca
    {
        private ArrayList libros;

        public ArrayList Libros { get => libros; set => libros = value; }

        public Biblioteca()
        {
            Libros = new ArrayList();
        }

        public void Agregar(Libro l)
        {
            Libros.Add(l);
        }

        public void Remover(Libro l)
        {
            Libros.Remove(l);
        }

        public void Ordenar()
        {
            Libros.Sort();
        }
    }
}
