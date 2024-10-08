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
    public partial class EditarRegistro : Form
    {
        private int _id;

        public EditarRegistro(int id)
        {
            InitializeComponent();
            _id = id;
        }

        private void EditarRegistro_Load(object sender, EventArgs e)
        {
            CargarDatos(_id);

            txtId.ReadOnly = true;
            txtIdEmpleado.ReadOnly = true;
        }
        private void CargarDatos(int id)
        {
            AsistenciaCN asistenciaCN = new AsistenciaCN();
            DataTable dt = asistenciaCN.ObtenerAsistenciaPorId(id);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                // Asignar los valores a los controles del formulario
                txtId.Text = row["ID"].ToString(); // Asegúrate de tener un TextBox llamado txtID
                txtIdEmpleado.Text = row["ID_empleado"].ToString(); // Asegúrate de tener un TextBox llamado txtIDEmpleado
                dtpFecha.Value = Convert.ToDateTime(row["Fecha"]);

                // Convertir a TimeSpan antes de asignar al DateTimePicker
                if (row["HoraEntrada"] != DBNull.Value)
                {
                    dtpHoraEntrada.Value = DateTime.Today.Add((TimeSpan)row["HoraEntrada"]);
                }
                else
                {
                    dtpHoraEntrada.Value = DateTime.Today; // Valor predeterminado si es necesario
                }

                if (row["HoraSalida"] != DBNull.Value)
                {
                    dtpHoraSalida.Value = DateTime.Today.Add((TimeSpan)row["HoraSalida"]);
                }
                else
                {
                    dtpHoraSalida.Value = DateTime.Today; // Valor predeterminado si es necesario
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Aquí iría el código para guardar los datos editados en la base de datos
            AsistenciaCN asistenciaCN = new AsistenciaCN();
            asistenciaCN.ActualizarAsistencia(_id, dtpFecha.Value, dtpHoraEntrada.Value.TimeOfDay, dtpHoraSalida.Value.TimeOfDay);
            MessageBox.Show("Datos actualizados correctamente.");
            this.Close();
        }
    }
}
