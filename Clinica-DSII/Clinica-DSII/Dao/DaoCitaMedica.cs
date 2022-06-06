using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Clinica_DSII.Entidades;

namespace Clinica_DSII.Dao
{
    public class DaoCitaMedica
    {
        private SqlConnection cone = new SqlConnection(@"Server=DESKTOP-AS63TOF\MSSQL; Database=clinicaDSII; Integrated Security=true");
        DataSet ds = new DataSet();
        public DataSet listar()
        {
            SqlDataAdapter da = new SqlDataAdapter("PROC_LISTAR_CITAS", cone);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(ds);
            return ds;
        }

        public bool insertar(CitaMedica cm) {
            try
            {
                SqlCommand cmd = new SqlCommand("PROC_INSERTAR_CITA", cone);    
                cmd.Parameters.AddWithValue("@idpac", cm.idpaciente);
                cmd.Parameters.AddWithValue("@idhor", cm.idhorario);
                cmd.Parameters.AddWithValue("@idespdoc", cm.idespdoctor);
                cmd.Parameters.AddWithValue("@fechac", cm.fechacita);
                cmd.Parameters.AddWithValue("@estado", cm.estado);
                cmd.Parameters.AddWithValue("@peso", cm.peso);
                cmd.Parameters.AddWithValue("@talla", cm.talla);
                cmd.Parameters.AddWithValue("@aler", cm.alergiamedicamento);
                cmd.CommandType = CommandType.StoredProcedure;
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

        public CitaMedica buscarRegistro(int idcitamedica)
        {
            CitaMedica cm = null;
            SqlCommand cmd = new SqlCommand("OBTENER_CITA", cone);
            cmd.Parameters.AddWithValue("@idcitamedica", idcitamedica);
            cmd.CommandType = CommandType.StoredProcedure;
            cone.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                cm = new CitaMedica();
                cm.idcitamedica = dr.GetInt32(0);
                cm.idpaciente = dr.GetInt32(1);
                cm.idhorario = dr.GetInt32(2);
                cm.idespdoctor = dr.GetInt32(3);
                cm.fechacita = dr.GetDateTime(4);
                cm.estado = dr.GetString(5);
                cm.peso = dr.GetDecimal(6);
                cm.talla = dr.GetDecimal(7);
                cm.alergiamedicamento = dr.GetString(8);
            }
            cone.Close();
            return cm;
        }
        public bool actualizar(CitaMedica citmed)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("PROC_ACTUALIZAR_CITA", cone);
                cmd.Parameters.AddWithValue("@idpaciente", citmed.idpaciente);
                cmd.Parameters.AddWithValue("@idhorario", citmed.idhorario);
                cmd.Parameters.AddWithValue("@idespdoctor", citmed.idespdoctor);
                cmd.Parameters.AddWithValue("@fechacita", citmed.fechacita);
                cmd.Parameters.AddWithValue("@estado", citmed.estado);
                cmd.Parameters.AddWithValue("@peso", citmed.peso);
                cmd.Parameters.AddWithValue("@talla", citmed.talla);
                cmd.Parameters.AddWithValue("@alergiamedicamento", citmed.alergiamedicamento);
                cmd.Parameters.AddWithValue("@idcitamedica", citmed.idcitamedica);
                cmd.CommandType = CommandType.StoredProcedure;
                cone.Open();
                cmd.ExecuteNonQuery();
                cone.Close();
                cmd.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool eliminar(int idcitamedica)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("ELIMINAR_CITA", cone);
                cmd.Parameters.AddWithValue("@idcitamedica", idcitamedica);
                cmd.CommandType = CommandType.StoredProcedure;
                cone.Open();
                cmd.ExecuteReader();
                cone.Close();
                cmd.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataSet consultarxpaciente(String param)
        {
            SqlDataAdapter da = new SqlDataAdapter
                ("select  concat(p.apellido, ', ', p.nombre) as Paciente," +
                " CONCAT(CONVERT(varchar,horainicio,24), ' - ', CONVERT(varchar,horafinal,24)) as Horario," +
                " CONCAT(u.apellido, ', ', u.nombre) as Doctor," +
                " CONCAT(e.nombre, '') as Especialidad, CONCAT(cm.fechacita, '') as FechaCita," +
                " cm.estado as Estado, cm.peso as 'Peso(Kg)', cm.talla as 'Talla(m)'," +
                " cm.alergiamedicamento as Alergia from citamedica cm" +
                " inner join pacientes p on p.idpacientes = cm.idpaciente" +
                " inner join horarios h on h.idhorario = cm.idhorario" +
                " inner join especialidadDoctor ed on ed.idespdoctor = cm.idespdoctor" +
                " inner join usuarios u on u.idusuario = ed.idusuario" +
                " inner join especialidad e on e.idespecialidad = ed.idespecialidad" +
                " where p.apellido like @param",cone);
            da.SelectCommand.Parameters.AddWithValue("@param", "%" + param + "%");
            da.Fill(ds);
            return ds;
        }

        public DataSet consultarxfecha(DateTime fechaini, DateTime fechafi)
        {
            SqlDataAdapter da = new SqlDataAdapter
                ("select  concat(p.apellido, ', ', p.nombre) as Paciente," +
                " CONCAT(CONVERT(varchar,horainicio,24), ' - ', CONVERT(varchar,horafinal,24)) as Horario," +
                " CONCAT(u.apellido, ', ', u.nombre) as Doctor," +
                " CONCAT(e.nombre, '') as Especialidad, CONCAT(cm.fechacita, '') as FechaCita," +
                " cm.estado as Estado, cm.peso as 'Peso(Kg)', cm.talla as 'Talla(m)'," +
                " cm.alergiamedicamento as Alergia from citamedica cm" +
                " inner join pacientes p on p.idpacientes = cm.idpaciente" +
                " inner join horarios h on h.idhorario = cm.idhorario" +
                " inner join especialidadDoctor ed on ed.idespdoctor = cm.idespdoctor" +
                " inner join usuarios u on u.idusuario = ed.idusuario" +
                " inner join especialidad e on e.idespecialidad = ed.idespecialidad" +
                " where cm.fechacita >= @fechaini and cm.fechacita <= @fechafi", cone);
            da.SelectCommand.Parameters.AddWithValue("@fechaini", fechaini);
            da.SelectCommand.Parameters.AddWithValue("@fechafi", fechafi);
            da.Fill(ds);
            return ds;
        }

        
    }
}