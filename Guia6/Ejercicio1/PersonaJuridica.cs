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
                if (value == null || Regex.IsMatch(value, @"^\d{11}$") == false
               || DigitoVerificadorValido(value) == false)
                {
                    throw new FormatoCUITNoValidoException(
                        "El CUIT debe tener 11 dígitos numéricos y se debe verificar con el digito verificador.");
                }
                cuit = value;
            }
        }
        public PersonaJuridica(string nombre, string cuit) : base(nombre)
        {
            this.Cuit = cuit;
        }
        public override string Describir()
        {
            return base.Describir() + $" ( {cuit} )";
        }
        private bool DigitoVerificadorValido(string valor)
        {
            int[] pesos = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            int suma = 0;

            for (int i = 0; i < 10; i++)
            {
                suma += (valor[i] - '0') * pesos[i];
            }

            int resto = suma % 11;
            int dv;

            if (resto == 0)
            {
                dv = 0;
            }
            else if (resto == 1)
            {
                dv = 9;
            }
            else
            {
                dv = 11 - resto;
            }

            return dv == (valor[10] - '0');
        }
    }
}
