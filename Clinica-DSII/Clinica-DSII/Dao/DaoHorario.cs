using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Clinica_DSII.Entidades;
using System.Data.SqlClient;

namespace Clinica_DSII.Dao
{
    public class DaoHorario
    {
        private SqlConnection cone = new SqlConnection("Server=LAPTOP-OB4D3M28;Database=clinicaDSII;Integrated Security = true");
        DataSet ds = new DataSet();

        public DataSet listar()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from horarios", cone);
            da.Fill(ds);
            return ds;
        }

        public Boolean insertar(Horario hr)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Insert into horarios values (@hinicio, @hfinal)";
                cmd.Parameters.AddWithValue("@hinicio", hr.horainicio);
                cmd.Parameters.AddWithValue("@hfinal", hr.horafinal);
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