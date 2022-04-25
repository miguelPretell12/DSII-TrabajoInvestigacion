using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Clinica_DSII.Entidades;

namespace Clinica_DSII.Dao
{
    public class DaoUsuario
    {
        private SqlConnection cone = new SqlConnection("Server=LAPTOP-OB4D3M28;Database=clinicaDSII;Integrated Security = true");

        public DataTable IniciarSesion(Usuario usu)
        {
            SqlDataAdapter da = new SqlDataAdapter("select correo, contrasenia, estado from usuarios where correo= @email and contrasenia=@cont and estado = 'A' ",cone);
            da.SelectCommand.Parameters.AddWithValue("@email", usu.correo);
            da.SelectCommand.Parameters.AddWithValue("@cont", usu.contrasenia);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public string guardar(Usuario usu) {
            string rpt;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Insert into Usuarios values (@nom, @ape, @dni, @correo, @contr, @estado, @idcargo)";
                cmd.Parameters.AddWithValue("@nom", usu.nombre);
                cmd.Parameters.AddWithValue("@ape", usu.apellido);
                cmd.Parameters.AddWithValue("@dni", usu.dni);
                cmd.Parameters.AddWithValue("@correo", usu.correo);
                cmd.Parameters.AddWithValue("@contr", usu.contrasenia);
                cmd.Parameters.AddWithValue("@estado", usu.estado);
                cmd.Parameters.AddWithValue("@idcargo", usu.cargos);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cone;
                cone.Open(); // Abrir la conexion al servidor
                cmd.ExecuteNonQuery(); // Enviar la orden al servidor
                cone.Close(); // Cerrar la conexion al servidor
                cmd.Dispose(); // Liberar recursos del comando
                rpt = "";
            }
            catch (Exception ex)
            {
                rpt = "error al grabar" + ex.Message;
            }

            return rpt;
         }
    }
}