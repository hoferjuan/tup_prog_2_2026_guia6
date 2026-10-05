using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Form2 miVentana = new Form2();
            bool seguir = true;

            while (seguir == true)
            {
                

                if(miVentana.ShowDialog() == DialogResult.OK)
                {
                    miVentana.NombreError = "";
                    miVentana.CuitError = "";
                    try
                    {
                        Persona persona;
                        if (miVentana.EsJuridica == true)
                        {
                            persona = new PersonaJuridica(miVentana.Nombre, miVentana.Cuit);
                        }
                        else
                        {
                            persona = new Persona(miVentana.Nombre);
                        }
                        ListPersonas.Items.Add(persona.Describir());
                        seguir = false;
                    }
                    catch (FormatoNombreNoValidoException ex)
                    {
                        miVentana.NombreError = ex.Message;
                    }
                    catch (FormatoCUITNoValidoException ex)
                    {
                        miVentana.CuitError = ex.Message;
                    }
                }
                else
                {
                    seguir = false;
                }
            }
            miVentana.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ListPersonas.SelectedIndex != -1)
            {
                ListPersonas.Items.RemoveAt(ListPersonas.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Seleccioná una persona para eliminar.");
            }
        }
    }
}
