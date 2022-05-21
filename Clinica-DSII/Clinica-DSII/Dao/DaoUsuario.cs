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
        DataSet ds = new DataSet();
        public DataTable IniciarSesion(Usuario usu)
        {
            SqlDataAdapter da = new SqlDataAdapter("select correo, contrasenia, estado from usuarios where correo= @email and contrasenia=@cont and estado = 'A' ",cone);
            da.SelectCommand.Parameters.AddWithValue("@email", usu.correo);
            da.SelectCommand.Parameters.AddWithValue("@cont", usu.contrasenia);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public int guardar(Usuario usu) {
            int rpt;    
            SqlCommand cmd = new SqlCommand("PROC_INSERTAR_USUARIO", cone);
            cmd.Parameters.AddWithValue("@nombre", usu.nombre);
            cmd.Parameters.AddWithValue("@apellido", usu.apellido);
            cmd.Parameters.AddWithValue("@dni", usu.dni);
            cmd.Parameters.AddWithValue("@correo", usu.correo);
            cmd.Parameters.AddWithValue("@contrasenia", usu.contrasenia);
            cmd.Parameters.AddWithValue("@idcargo", usu.cargos);
            cmd.CommandType = CommandType.StoredProcedure;
            cone.Open(); // Abrir la conexion al servidor
            rpt = cmd.ExecuteNonQuery(); // Enviar la orden al servidor
            cone.Close(); // Cerrar la conexion al servidor
            cmd.Dispose(); // Liberar recursos del comando            

            return rpt;
        }

        public int eliminarUser(int userid)
        {
            int rpt;
            SqlCommand cmd = new SqlCommand("ELIMINAR_USUARIO", cone);
            cmd.Parameters.AddWithValue("@iduser", userid);
            cmd.CommandType = CommandType.StoredProcedure;
            cone.Open(); // Abrir la conexion al servidor
            rpt = cmd.ExecuteNonQuery(); // Enviar la orden al servidor
            cone.Close(); // Cerrar la conexion al servidor
            cmd.Dispose(); // Liberar recursos del comando         
            return rpt;
        }

        public int actualizar(Usuario usu)
        {
            int rpt;
            SqlCommand cmd = new SqlCommand("PROC_ACTUALIZAR_USUARIO", cone);
            cmd.Parameters.AddWithValue("@nombre", usu.nombre);
            cmd.Parameters.AddWithValue("@apellido", usu.apellido);
            cmd.Parameters.AddWithValue("@dni", usu.dni);
            cmd.Parameters.AddWithValue("@correo", usu.correo);
            cmd.Parameters.AddWithValue("@contrasenia", usu.contrasenia);
            cmd.Parameters.AddWithValue("@idcargo", usu.cargos);
            cmd.Parameters.AddWithValue("@iduser", usu.idusuarios);
            cmd.CommandType = CommandType.StoredProcedure;
            cone.Open(); // Abrir la conexion al servidor
            rpt = cmd.ExecuteNonQuery(); // Enviar la orden al servidor
            cone.Close(); // Cerrar la conexion al servidor
            cmd.Dispose(); // Liberar recursos del comando            

            return rpt;
        }
    
        public DataSet listar()
        {
            SqlDataAdapter da = new SqlDataAdapter("select " +
                "u.nombre as Nombre, u.apellido as Apellido, u.dni as Dni, u.correo as Correo, u.estado as Estado, c.nombre as Cargo" +
                " from usuarios u inner join cargos c on c.idcargo = u.idcargo", cone);
            da.Fill(ds);
            return ds;
        }

        public List<Usuario> listarUsuario()
        {
            List<Usuario> list = new List<Usuario>();
            SqlCommand cmd = null;
            SqlDataReader reader = null;
            cone.Open();
            try {
                cmd = new SqlCommand("LISTAR_USUARIOS", cone);
                cmd.CommandType = CommandType.StoredProcedure;
                reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    Usuario usu = new Usuario();
                    usu.idusuarios = int.Parse(reader["Idusuario"].ToString());
                    usu.nombre = reader["Nombre"].ToString();
                    usu.apellido = reader["Apellido"].ToString();
                    usu.dni = reader["Dni"].ToString();
                    usu.correo = reader["Correo"].ToString();
                    usu.estado = reader["Estado"].ToString();
                    usu.cargo = reader["Cargo"].ToString();

                    list.Add(usu);
                }
            } catch (Exception e) { 
            
            }
            cone.Close();
            return list;
        }

        public List<Cargo> Cargos() {
            List<Cargo> list = new List<Cargo>();
            SqlCommand cmd = null;
            SqlDataReader reader = null;
            cone.Open();
            try
            {
                cmd = new SqlCommand("LISTAR_CARGOS", cone);
                cmd.CommandType = CommandType.StoredProcedure;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cargo carg = new Cargo();
                    carg.idcargos = int.Parse(reader["Idcargo"].ToString());
                    carg.nombre = reader["Nombre"].ToString();

                    list.Add(carg);
                }
            }
            catch (Exception e)
            {

            }
            cone.Close();
            return list;
        }

        public Usuario getUser(int iduser) {
            SqlCommand cmd = new SqlCommand("OBTENER_USUARIO", cone);
            cmd.Parameters.AddWithValue("@iduser",iduser);
            cmd.CommandType = CommandType.StoredProcedure;
            cone.Open();
            SqlDataReader getUse = cmd.ExecuteReader();
            Usuario usu = new Usuario();
            if (getUse.Read())
            {
                usu.nombre = getUse["Nombre"].ToString().Trim();
                usu.apellido = getUse["Apellido"].ToString().Trim();
                usu.dni = getUse["Dni"].ToString().Trim();
                usu.correo = getUse["Correo"].ToString().Trim();
                usu.contrasenia = getUse["Contrasenia"].ToString().Trim();
                usu.cargos = int.Parse(getUse["Idcargo"].ToString().Trim());
                usu.idusuarios = int.Parse(getUse["Idusuario"].ToString().Trim());
            }
            return usu;
        }
    
        public Boolean updatestatus(Usuario usu)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("PROC_STATUS_USERS", cone);
                cmd.Parameters.AddWithValue("@estado", usu.estado);
                cmd.Parameters.AddWithValue("@idusuario", usu.idusuarios);
                cmd.CommandType = CommandType.StoredProcedure;
                cone.Open();
                cmd.ExecuteNonQuery();
                cone.Close();
                cmd.Dispose();
                return true; 
            }
            catch (SqlException e) {
                return false;
            }
        }

        public Usuario consultarEmail(string correo) {
            SqlCommand cmd = new SqlCommand("select correo, idusuario from usuarios where correo = @email", cone);
            cmd.Parameters.AddWithValue("@email", correo);

            cone.Open();
            SqlDataReader getUse = cmd.ExecuteReader();
            Usuario usu = new Usuario();

            if (getUse.Read())
            {
                usu.idusuarios = int.Parse(getUse["idusuario"].ToString().Trim());
                usu.correo = getUse["correo"].ToString().Trim();
            }

            return usu;
        }
    }
}