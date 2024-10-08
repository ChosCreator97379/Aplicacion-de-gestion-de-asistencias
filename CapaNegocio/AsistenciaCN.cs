﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDato;
using CapaEntidad;

namespace CapaNegocio
{
    public class AsistenciaCN
    {
        public void GuardarAsistencia(int idEmpleado, DateTime fecha, TimeSpan? hora, string tipoRegistro)
        {
            AsistenciaCD asistenciaCD = new AsistenciaCD();
            AsistenciaCE asistencia = new AsistenciaCE
            {
                ID_Empleado = idEmpleado,
                Fecha = fecha,
                HoraEntrada = tipoRegistro == "Entrada" ? hora : (TimeSpan?)null,
                HoraSalida = tipoRegistro == "Salida" ? hora : (TimeSpan?)null
            };
            asistenciaCD.GuardarAsistencia(asistencia);
        }
        public DataTable ObtenerAsistencias()
        {
            AsistenciaCD asistenciaCD = new AsistenciaCD();
            return asistenciaCD.ObtenerAsistencias();
        }
        public void ActualizarAsistencia(int id, DateTime fecha, TimeSpan? horaEntrada, TimeSpan? horaSalida)
        {
            AsistenciaCD asistenciaCD = new AsistenciaCD();
            asistenciaCD.ActualizarAsistencia(id, fecha, horaEntrada, horaSalida);
        }
        public DataTable ObtenerAsistenciaPorId(int id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cnx = ConexionCD.sqlConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Asistencias WHERE ID = @ID", cnx);
                cmd.Parameters.AddWithValue("@ID", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }
}
