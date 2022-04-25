using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Clinica_DSII.Entidades;
using System.Data.SqlClient;

namespace Clinica_DSII.Dao
{
    public class DaoCargo
    {

        private SqlConnection cone = new SqlConnection("Server=LAPTOP-OB4D3M28;Database=clinicaDSII;Integrated Security = true");
        DataSet ds = new DataSet();

        public DataSet listar()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from cargos", cone);
            da.Fill(ds);
            return ds;
        }
    }
}