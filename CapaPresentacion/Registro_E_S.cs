﻿using CapaNegocio;
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

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int idEmpleado = Convert.ToInt32(txtId.Text); // ID del empleado que buscaste
            DateTime fecha = Fecha.Value; // Fecha seleccionada
            TimeSpan hora = Hora.Value.TimeOfDay; // Hora seleccionada
            string tipoRegistro = txtTipoRegistro.SelectedItem.ToString(); // 'Entrada' o 'Salida'

            asistenciaCN.GuardarAsistencia(idEmpleado, fecha, hora, tipoRegistro);

            MessageBox.Show("Asistencia registrada correctamente.");
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = asistenciaCN.ObtenerAsistencias();
                if (dt != null && dt.Rows.Count > 0)
                {
                    dataGridView.AutoGenerateColumns = true; // Deshabilitar la autogeneración de columnas
                    dataGridView.DataSource = dt; // Asignar el DataTable al DataGridView
                }
                else
                {
                    dataGridView.DataSource = null;
                    MessageBox.Show("No se encontraron datos para mostrar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los datos: {ex.Message}");
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Asegúrate de que se ha seleccionado una fila
            if (e.RowIndex >= 0)
            {
                // Obtén el ID del registro seleccionado. Suponiendo que el ID está en la primera columna.
                int id = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value);

                // Abre el formulario de edición y pasa el ID del registro
                EditarRegistro editarFormulario = new EditarRegistro(id);
                editarFormulario.ShowDialog();
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                // Obtener el ID de la fila seleccionada
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["ID"].Value);

                // Crear una nueva instancia del formulario de edición, pasando el ID del registro
                EditarRegistro editarRegistro = new EditarRegistro(id);

                // Mostrar el formulario de edición
                editarRegistro.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para editar.");
            }
=======
>>>>>>> parent of ee59dab (añadir)
=======
>>>>>>> parent of ee59dab (añadir)
=======
>>>>>>> parent of ee59dab (añadir)
        }
    }
}
