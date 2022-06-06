using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Clinica_DSII.Entidades;
using System.Data;
using Clinica_DSII.ViewClass;

namespace Clinica_DSII.Dao
{
    public class DaoMedicoEspecialidad
    {
        private SqlConnection cone = new SqlConnection("Server=LAPTOP-OB4D3M28; Database=clinicaDSII; Integrated Security=true");

        public ViewEspecialidadMedico getMedicoEspecialidad(string dni)
        {
            SqlCommand cmd = new SqlCommand("PROC_OBTENER_MEDICO", cone);
            cmd.Parameters.AddWithValue("@dni", dni);
            cmd.CommandType = CommandType.StoredProcedure;
            cone.Open();
            SqlDataReader getMEspecialidad = cmd.ExecuteReader();
            ViewEspecialidadMedico vme = new ViewEspecialidadMedico();

            if (getMEspecialidad.Read())
            {
                vme.idusuario = int.Parse(getMEspecialidad["Idusuario"].ToString().Trim());
                vme.medico = getMEspecialidad["Medico"].ToString().Trim();
                vme.dni = getMEspecialidad["Dni"].ToString().Trim();
                vme.correo = getMEspecialidad["Correo"].ToString().Trim();
                vme.idespmed = int.Parse(getMEspecialidad["Idespmed"].ToString().Trim());
                vme.idespecialidad = int.Parse(getMEspecialidad["Idespecialidad"].ToString().Trim());
            }
            cone.Close();

            return vme;
        }

        public List<Especialidad> especialidades()
        {
            List<Especialidad> list = new List<Especialidad>();
            SqlCommand cmd = null;
            SqlDataReader reader = null;
            cone.Open();
            try
            {
                cmd = new SqlCommand("PROC_LISTAR_ESPECIALIDAD", cone);
                cmd.CommandType = CommandType.StoredProcedure;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Especialidad esp = new Especialidad();
                    esp.idespecialidad = int.Parse(reader["Idespecialidad"].ToString());
                    esp.nombre = reader["Nombre"].ToString();

                    list.Add(esp);
                }
            }
            catch (Exception e)
            {

            }
            cone.Close();
            return list;
        }

        public List<ViewEspecialidadMedico> searchEspMed(string dni)
        {

            List<ViewEspecialidadMedico> list = new List<ViewEspecialidadMedico>();
            SqlCommand cmd = null;
            SqlDataReader reader = null;
            cone.Open();
            try
            {
                cmd = new SqlCommand("PROC_BUSCAR_ESPMED", cone);
                cmd.Parameters.AddWithValue("@dni", dni);
                cmd.CommandType = CommandType.StoredProcedure;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ViewEspecialidadMedico esp = new ViewEspecialidadMedico();
                    esp.especialidad = reader["especialidad"].ToString();
                    esp.medico = reader["Medico"].ToString();
                    esp.dni = reader["Dni"].ToString();
                    esp.idespmed = int.Parse(reader["Idespmed"].ToString());
                    list.Add(esp);
                }
            }
            catch (Exception e)
            {

            }
            cone.Close();
            return list;
        }

        public List<ViewEspecialidadMedico> ListEspMed()
        {
            List<ViewEspecialidadMedico> list = new List<ViewEspecialidadMedico>();
            SqlCommand cmd = null;
            SqlDataReader reader = null;
            cone.Open();
            try
            {
                cmd = new SqlCommand("PROC_LISTAR_ESPMED", cone);
                cmd.CommandType = CommandType.StoredProcedure;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ViewEspecialidadMedico esp = new ViewEspecialidadMedico();
                    esp.especialidad = reader["especialidad"].ToString();
                    esp.medico = reader["Medico"].ToString();
                    esp.dni = reader["Dni"].ToString();
                    esp.idespmed = int.Parse(reader["Idespmed"].ToString());
                    list.Add(esp);
                }
            }
            catch (Exception e)
            {

            }
            cone.Close();
            return list;
        }

        public int save(string idesp, string idusuario)
        {
            int rpt;
            SqlCommand cmd = new SqlCommand("PROC_GUARDAR_MED_ESP", cone);
            cmd.Parameters.AddWithValue("@idesp", idesp);
            cmd.Parameters.AddWithValue("@idusuario", idusuario);
            cmd.CommandType = CommandType.StoredProcedure;
            cone.Open(); // Abrir la conexion al servidor
            rpt = cmd.ExecuteNonQuery(); // Enviar la orden al servidor
            cone.Close(); // Cerrar la conexion al servidor
            cmd.Dispose(); // Liberar recursos del comando   
            return rpt;
        }

        public int update(string idesp, string idusuario, string idespmed)
        {
            int rpt;
            SqlCommand cmd = new SqlCommand("PROC_ACTUALIZAR_MED_ESP", cone);
            cmd.Parameters.AddWithValue("@idesp", idesp);
            cmd.Parameters.AddWithValue("@idusuario", idusuario);
            cmd.Parameters.AddWithValue("@idespmed", idespmed);
            cmd.CommandType = CommandType.StoredProcedure;
            cone.Open(); // Abrir la conexion al servidor
            rpt = cmd.ExecuteNonQuery(); // Enviar la orden al servidor
            cone.Close(); // Cerrar la conexion al servidor
            cmd.Dispose(); // Liberar recursos del comando   
            return rpt;
        }

        public int delete(string idespmed)
        {
            int rpt;
            SqlCommand cmd = new SqlCommand("PROC_ELIMINAR_MED_ESP", cone);
            cmd.Parameters.AddWithValue("@idespmed", idespmed);
            cmd.CommandType = CommandType.StoredProcedure;
            cone.Open(); // Abrir la conexion al servidor
            rpt = cmd.ExecuteNonQuery(); // Enviar la orden al servidor
            cone.Close(); // Cerrar la conexion al servidor
            cmd.Dispose(); // Liberar recursos del comando   
            return rpt;
        }
    }
}