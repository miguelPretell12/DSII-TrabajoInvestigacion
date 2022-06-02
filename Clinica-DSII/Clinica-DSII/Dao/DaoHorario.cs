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
        public DataSet listarsub()
        {
            SqlDataAdapter da = new SqlDataAdapter("select " +
                " CONVERT(varchar,horainicio,24) as horaInicio , CONVERT(varchar,horafinal,24) as horaFinal " +
                " from horarios", cone);
            da.Fill(ds);
            return ds;
        }

        public List<Horario> listar() {
            List<Horario> list = new List<Horario>();
            SqlCommand cmd = null;
            SqlDataReader reader = null;
            cone.Open();
            try
            {
                cmd = new SqlCommand("LISTAR_HORARIO", cone);
                cmd.CommandType = CommandType.StoredProcedure;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Horario hor = new Horario();
                    hor.idhorario = int.Parse(reader["Idhorario"].ToString());
                    hor.horainicio = TimeSpan.Parse(reader["HoraInicio"].ToString());
                    hor.horafinal = TimeSpan.Parse(reader["HoraFinal"].ToString());
                    list.Add(hor);
                }
            }
            catch (Exception e)
            {

            }
            cone.Close();

            return list;
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
        public Horario getHorario(int id) {
            SqlCommand cmd = new SqlCommand("OBTENER_HORARIO", cone);
            cmd.Parameters.AddWithValue("@idhora", id);
            cmd.CommandType = CommandType.StoredProcedure;
            cone.Open();
            SqlDataReader getUse = cmd.ExecuteReader();
            Horario hora = new Horario();
            if (getUse.Read())
            {
                hora.idhorario = int.Parse(getUse["Idhorario"].ToString());
                hora.horainicio = TimeSpan.Parse(getUse["HoraInicio"].ToString());
                hora.horafinal = TimeSpan.Parse(getUse["HoraFinal"].ToString());
            }
            return hora;
        }

        public int filtro(string horai, string horaf)
        {
            SqlDataReader reader = null;
            int rpta = 0;

            SqlCommand cmd = new SqlCommand("FILTRO_HORARIO", cone);
            cmd.Parameters.AddWithValue("@horainicio", horai);
            cmd.Parameters.AddWithValue("@horafinal", horaf);
            cmd.CommandType = CommandType.StoredProcedure;
            cone.Open();
            reader = cmd.ExecuteReader();
            
            if (reader.Read())
            {
                rpta = int.Parse(reader["Exist"].ToString());
            }
            
            cone.Close();
            cmd.Dispose();

            return rpta;
        }

        public int guardar(Horario hor)
        {
            int rpta;
            SqlCommand cmd = new SqlCommand("PROC_INSERTAR_HORARIO", cone);
            cmd.Parameters.AddWithValue("@horainicio", hor.horainicio);
            cmd.Parameters.AddWithValue("@horafinal", hor.horafinal);

            cmd.CommandType = CommandType.StoredProcedure;
            cone.Open(); // Abrir la conexion al servidor
            rpta = cmd.ExecuteNonQuery(); // Enviar la orden al servidor
            cone.Close(); // Cerrar la conexion al servidor
            cmd.Dispose(); // Liberar recursos del comando   
            return rpta;
        }

        public int actualizar(Horario hor)
        {
            int rpta;
            SqlCommand cmd = new SqlCommand("PROC_UPDATE_HORARIO", cone);
            cmd.Parameters.AddWithValue("@horainicio", hor.horainicio);
            cmd.Parameters.AddWithValue("@horafinal", hor.horafinal);
            cmd.Parameters.AddWithValue("@idhorario", hor.idhorario);

            cmd.CommandType = CommandType.StoredProcedure;
            cone.Open(); // Abrir la conexion al servidor
            rpta = cmd.ExecuteNonQuery(); // Enviar la orden al servidor
            cone.Close(); // Cerrar la conexion al servidor
            cmd.Dispose(); // Liberar recursos del comando   
            return rpta;
        }

        public int eliminar(Horario hor)
        {
            int rpta;
            SqlCommand cmd = new SqlCommand("PROC_DELETE_HORARIO", cone);
            cmd.Parameters.AddWithValue("@idhorario", hor.idhorario);

            cmd.CommandType = CommandType.StoredProcedure;
            cone.Open(); // Abrir la conexion al servidor
            rpta = cmd.ExecuteNonQuery(); // Enviar la orden al servidor
            cone.Close(); // Cerrar la conexion al servidor
            cmd.Dispose(); // Liberar recursos del comando   
            return rpta;
        }
    }
}