using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Clinica_DSII.Entidades;
using Clinica_DSII.ViewClass;

namespace Clinica_DSII.Dao
{
    public class DaoConsulta
    {
        private SqlConnection cone = new SqlConnection("Server=LAPTOP-OB4D3M28; Database=clinicaDSII; Integrated Security=true");

        public List<ViewConsultas> getConsultas()
        {
            List<ViewConsultas> list = new List<ViewConsultas>();
            SqlCommand cmd = null;
            SqlDataReader reader = null;
            cone.Open();
            try
            {
                cmd = new SqlCommand("PROC_LISTAR_CONSULTAS", cone);
                cmd.CommandType = CommandType.StoredProcedure;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ViewConsultas vcons = new ViewConsultas();
                    vcons.idconsulta = int.Parse(reader["Idconsulta"].ToString());
                    vcons.medico = reader["Medico"].ToString();
                    vcons.especialidad = reader["Especialidad"].ToString();
                    vcons.horainicio = TimeSpan.Parse(reader["Horainicio"].ToString());
                    vcons.horafinal = TimeSpan.Parse(reader["Horafinal"].ToString());
                    vcons.precio = double.Parse(reader["Precio"].ToString());
                    list.Add(vcons);
                }
            }
            catch (Exception e)
            {

            }
            cone.Close();

            return list;
        }

        public List<ViewMedico> getMedicos() {
            List<ViewMedico> list = new List<ViewMedico>();
            SqlCommand cmd = null;
            SqlDataReader reader = null;
            cone.Open();
            try
            {
                cmd = new SqlCommand("PROC_LISTAR_MEDICO", cone);
                cmd.CommandType = CommandType.StoredProcedure;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ViewMedico vmed = new ViewMedico();
                    vmed.idmedico = int.Parse(reader["Idmedico"].ToString());
                    vmed.medico = reader["Medico"].ToString();
                    list.Add(vmed);
                }
            }
            catch (Exception e)
            {

            }
            cone.Close();

            return list;
        }

        public Especialidad getMedEsp(int idmedico )
        {
            Especialidad esp = new Especialidad();
            SqlCommand cmd = null;
            SqlDataReader reader = null;
            cone.Open();
            try
            {
                cmd = new SqlCommand("PROC_OBTENER_MED_ESP", cone);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idmedico", idmedico);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    esp.idespecialidad = int.Parse(reader["Idespecialidad"].ToString());
                    esp.nombre = reader["Especialidad"].ToString();
                }
            }
            catch (Exception e)
            {

            }
            cone.Close();
            return esp;
        }

        public int save(Consulta cons)
        {
            SqlCommand cmd = new SqlCommand("PROC_GUARDAR_CONSULTA", cone);
            cmd.Parameters.AddWithValue("@idmedico", cons.idmedico);
            cmd.Parameters.AddWithValue("@idespecialidad", cons.especialidad);
            cmd.Parameters.AddWithValue("@idhorario", cons.horario);
            cmd.Parameters.AddWithValue("@precio", cons.precio); 
            cmd.CommandType = CommandType.StoredProcedure;

            // sql parameter
            SqlParameter retorno = new SqlParameter();
            retorno.Direction = ParameterDirection.ReturnValue;

            cmd.Parameters.Add(retorno);
            cone.Open(); // Abrir la conexion al servidor
            cmd.ExecuteNonQuery(); // Enviar la orden al servidor

            int rpt = (int) retorno.Value;
            cone.Close(); // Cerrar la conexion al servidor
            cmd.Dispose(); // Liberar recursos del comando            

            return rpt;
        }

        public ViewConsultaObtener getConsulta ()
        {
            return null;
        }
    }
}