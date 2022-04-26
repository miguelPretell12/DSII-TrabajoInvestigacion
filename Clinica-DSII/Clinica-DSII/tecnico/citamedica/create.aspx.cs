using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Clinica_DSII.Dao;
using Clinica_DSII.Entidades;
using System.Data.SqlClient;
using System.Data;

namespace Clinica_DSII.tecnico.citamedica
{
    public partial class create : System.Web.UI.Page
    {
        private SqlConnection cone = new SqlConnection("Server=LAPTOP-OB4D3M28; Database=clinicaDSII; Integrated Security=true");
        DaoCitaMedica dao = new DaoCitaMedica();
        protected void Page_Load(object sender, EventArgs e)
        {
            llenarEstado();
            llenarEspecialidad();
            llenarPaciente();
            llenarHorario();
            llenarAlerPre();
        }

        public void llenarEstado()
        {
            ddlEstado.Items.Add("Reserva");
            ddlEstado.Items.Add("En curso");
            ddlEstado.Items.Add("No Asistio");
            ddlEstado.Items.Add("Concluido");
        }
        public void llenarEspecialidad() {
            DataSet ds = new DataSet();
            SqlCommand cm = new SqlCommand("select " +
                " concat('Especialidad:', e.nombre ,' - Médico: ',u.apellido,',',u.nombre) as Especialidad, ed.idespdoctor as IdEspMed " +
                " from especialidadDoctor ed " +
                " inner join especialidad e on e.idespecialidad = ed.idespecialidad " +
                " inner join usuarios u on u.idusuario = ed.idusuario ", cone);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(ds);
            ddlMedEsp.DataSource = ds;
            ddlMedEsp.DataValueField = "IdEspMed";
            ddlMedEsp.DataTextField = "Especialidad";
            ddlMedEsp.DataBind();
        }
        public void llenarPaciente() {
            DataSet ds = new DataSet();
            SqlCommand cm = new SqlCommand("select " +
                " concat('DNI: ', dni,' - ', apellido,', ', nombre) as Detallepaciente, idpacientes as Idpac " +
                " from pacientes",cone);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(ds);
            ddlpaciente.DataSource = ds;
            ddlpaciente.DataValueField = "Idpac";
            ddlpaciente.DataTextField = "Detallepaciente";
            ddlpaciente.DataBind();
        }
        public void llenarHorario() {
            DataSet ds = new DataSet();
            SqlCommand cm = new SqlCommand("select " +
                " concat('Hora Inicio: ', horainicio, ' - Hora Final: ', horafinal ) as DetalleHorario, idhorario as IdH" +
                " from horarios", cone);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(ds);
            ddlhorario.DataSource = ds;
            ddlhorario.DataValueField = "IdH";
            ddlhorario.DataTextField = "DetalleHorario";
            ddlhorario.DataBind();
        }
        public void llenarAlerPre()
        {
            ddlAler.Items.Add("Si");
            ddlAler.Items.Add("No");
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {

            int idpac, idespdoc, idhorario;
            double peso, estatura;
            string estado, alergm;
            DateTime fecCita;

            idpac = int.Parse(ddlpaciente.Text);
            idespdoc = int.Parse(ddlMedEsp.Text);
            idhorario = int.Parse(ddlhorario.Text);

            fecCita = DateTime.Parse(txtFecha.Text);

            peso = double.Parse(txtPeso.Text);
            estatura = double.Parse(txtEstatura.Text);

            estado = ddlEstado.Text.ToLower();
            alergm = ddlAler.Text;

            CitaMedica cm = new CitaMedica(idpac, idhorario, idespdoc, fecCita, estado, peso, estatura, alergm);
            if (dao.insertar(cm)) {
                Response.Redirect("/tecnico/citamedica/index");
            }else
            {
                Response.Redirect("/tecnico/citamedica/create");
            }

        }
    }
}