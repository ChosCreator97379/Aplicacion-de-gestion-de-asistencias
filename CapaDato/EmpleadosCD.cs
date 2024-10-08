﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDato
{
    public class EmpleadoCD
    {
        public static DataTable BuscarEmpleadoPorID(int id)
        {
            using (SqlConnection cnx = ConexionCD.sqlConnection())
            {
                string query = "SELECT e.Nombre, e.Apellido1, e.Apellido2, dl.Cargo, dl.Area " +
                               "FROM Empleados e " +
                               "INNER JOIN DatosLaborales dl ON e.ID = dl.ID_Empleado " +
                               "WHERE e.ID = @ID";

                SqlCommand cmd = new SqlCommand(query, cnx);
                cmd.Parameters.AddWithValue("@ID", id);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }
    }
}
