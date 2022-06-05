using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Clinica_DSII.Entidades;

namespace Clinica_DSII.Dao
{
    public class DaoPaciente
    {
        private SqlConnection cone = new SqlConnection(@"Server=DESKTOP-AS63TOF\MSSQL;Database=clinicaDSII;Integrated Security = true");
        DataSet ds = new DataSet();

        public DataSet listar()
        {
            SqlDataAdapter da = new SqlDataAdapter("select " +
                " nombre as Nombre, apellido as Apellido, dni as DNI, correo as Correo_Electronico, fechanacimiento as Fecha_nacimiento " +
                " from pacientes", cone);
            da.Fill(ds);
            return ds;
        }

        public Boolean insertar(Paciente pac) {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Insert into pacientes values (@nom, @ape, @dni, @correo, @fechan)";
                cmd.Parameters.AddWithValue("@nom", pac.nombre);
                cmd.Parameters.AddWithValue("@ape", pac.apellido);
                cmd.Parameters.AddWithValue("@dni", pac.dni);
                cmd.Parameters.AddWithValue("@correo", pac.correo);
                cmd.Parameters.AddWithValue("@fechan", pac.fechanacimiento);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cone;
                cone.Open(); // Abrir la conexion al servidor
                cmd.ExecuteNonQuery(); // Enviar la orden al servidor
                cone.Close(); // Cerrar la conexion al servidor
                cmd.Dispose(); // Liberar recursos del comando

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}