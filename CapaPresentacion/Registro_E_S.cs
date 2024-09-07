using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Registro_E_S : Form
    {
        private EmpleadoCN empleadoCN = new EmpleadoCN();
        public Registro_E_S()
        {
            InitializeComponent();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Registro_E_S_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int id;
                if (int.TryParse(txtId.Text, out id))
                {
                    DataTable dt = CapaNegocio.EmpleadoCN.BuscarEmpleadoPorID(id);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        txtNombre.Text = row["Nombre"].ToString();
                        txtApellido.Text = $"{row["Apellido1"]} {row["Apellido2"]}";
                        txtCargo.Text = row["Cargo"].ToString();
                        txtArea.Text = row["Area"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún empleado con ese ID.");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese un ID válido.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

    }
}
