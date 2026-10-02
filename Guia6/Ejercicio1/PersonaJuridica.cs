using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ejercicio1
{
    internal class PersonaJuridica : Persona
    {
        private string cuit;
        private string Cuit
        {
            get { return cuit; }
            set
            {
                if (value == null || !Regex.IsMatch(value, @"^\d{11}$"))
                {
                    throw new FormatoCUITNoValidoException("El CUIT debe tener exactamente 11 dígitos numéricos.");
                }

                int[] multiplicadores = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
                int suma = 0;

                for (int i = 0; i < 10; i++)
                {
                    suma += (value[i] - '0') * multiplicadores[i];
                }

                int resto = suma % 11;
                int digitoEsperado;

                if (resto == 0)
                {
                    digitoEsperado = 0;
                }
                else if (resto == 1)
                {
                    digitoEsperado = 9;
                }
                else
                {
                    digitoEsperado = 11 - resto;
                }

                int digitoIngresado = value[10] - '0';

                if (digitoEsperado != digitoIngresado)
                {
                    throw new FormatoCUITNoValidoException("El dígito verificador del CUIT no es válido.");
                }

                cuit = value;
            }
        }
        public PersonaJuridica(string nombre, string cuit) : base(nombre)
        {
            this.cuit = cuit;
        }
        public override string Describir()
        {
            return base.Describir() + $" - CUIT: {cuit}";
        }
    }
}
