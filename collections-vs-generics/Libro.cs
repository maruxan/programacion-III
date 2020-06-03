using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfaces
{
    class Libro : IColeccionable, IComparable
    {
        private string titulo;
        private string autor;

        public string Titulo { get => titulo; set => titulo = value; }
        public string Autor { get => autor; set => autor = value; }

        public Libro(string titulo, string autor)
        {
            this.titulo = titulo;
            this.autor = autor;
        }

        public override string ToString()
        {
            return $"Titulo: {Titulo} - Autor: {Autor}";
        }

        public void Describir()
        {
            Console.WriteLine(this.ToString());
        }

        public int CompareTo(object obj)
        {

            if (obj == null) return 1;
            Libro l = (Libro)obj;
            return Titulo.CompareTo(l.Titulo);
        }
    }
}
