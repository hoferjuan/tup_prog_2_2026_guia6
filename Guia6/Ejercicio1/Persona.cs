using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ejercicio1
{
    internal class Persona : IComparable
    {
        protected string nombre;
        public string Nombre
        {
            get { return nombre; }
            set
            {
                string patron = @"^\s*(?<apellido>[\p{L}\s]{2,}?),\s*(?<nombres>[\p{L}\s]{2,})\s*$";
                if (value == null || !Regex.IsMatch(value, patron))
                {
                    throw new FormatoNombreNoValidoException("El nombre debe tener el formato 'Apellidos, Nombres'.");
                }
                nombre = value;
            }
        }

        public Persona(string nombre)
        {
            this.Nombre = nombre;
        }
        public virtual string Describir()
        {
            return Nombre;
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            Persona otra = obj as Persona;

            if (otra == null)
            {
                throw new ArgumentException("El objeto no es una Persona.");
            }
            return string.Compare(this.nombre, otra.nombre);
        }
    }
}
