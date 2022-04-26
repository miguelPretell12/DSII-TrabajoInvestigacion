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
        private SqlConnection cone = new SqlConnection("Server=LAPTOP-OB4D3M28; Database=clinicaDSII; Integrated Security=true");
        DataSet ds = new DataSet();
        public bool insertar(CitaMedica cm) {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Insert into citamedica values (@idpac, @idhor, @idespdoc, @fechac, @estado, @peso, @talla, @aler)";
                cmd.Parameters.AddWithValue("@idpac", cm.idpaciente);
                cmd.Parameters.AddWithValue("@idhor", cm.idhorario);
                cmd.Parameters.AddWithValue("@idespdoc", cm.idespdoctor );
                cmd.Parameters.AddWithValue("@fechac", cm.fechacita);
                cmd.Parameters.AddWithValue("@estado", cm.estado);
                cmd.Parameters.AddWithValue("@peso", cm.peso);
                cmd.Parameters.AddWithValue("@talla", cm.talla);
                cmd.Parameters.AddWithValue("@aler", cm.alergiamedicamento);
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

        public DataSet listar()
        {
            SqlDataAdapter da = new SqlDataAdapter("select  concat(p.apellido, ', ', p.nombre) as Paciente, CONCAT(h.horainicio, ' - ', h.horafinal) as Horario, CONCAT(u.apellido, ', ', u.nombre) as Doctor, CONCAT(e.nombre, '') as Especialidad, CONCAT(cm.fechacita, '') as FechaCita, cm.estado as Estado from citamedica cm inner join pacientes p on p.idpacientes = cm.idpaciente inner join horarios h on h.idhorario = cm.idhorario inner join especialidadDoctor ed on ed.idespdoctor = cm.idespdoctor inner join usuarios u on u.idusuario = ed.idusuario inner join especialidad e on e.idespecialidad = ed.idespecialidad", cone);
            da.Fill(ds);
            return ds;
        }
    
    }
}