using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        public string Nombre
        {
            get { return tbNombre.Text; }
            set { tbNombre.Text = value; }
        }
        public string NombreError
        {
            set { lbPersonaError.Text = value; }
        }

        public string Cuit
        {
            get { return tbCUIT.Text; }
            set { tbCUIT.Text = value; }
        }
        public string CuitError
        {
            set { lbCUITError.Text = value; }
        }
        public bool EsJuridica
        {
            get { return rbJuridica.Checked; }
            set
            {
                rbJuridica.Checked = value;
                rbFisica.Checked = !value;
            }
        }
        public void LimpiarErrores()
        {
            lbPersonaError.Text = "";
            lbCUITError.Text = "";
        }
    }
}
