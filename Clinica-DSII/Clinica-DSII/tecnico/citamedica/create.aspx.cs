﻿using System;
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
        private SqlConnection cone = new SqlConnection(@"Server=DESKTOP-AS63TOF\MSSQL; Database=clinicaDSII; Integrated Security=true");
        DaoCitaMedica dao = new DaoCitaMedica();
        protected void Page_Load(object sender, EventArgs e)
        {
            string sessioncargo = Session["sessioncargo"] as string;
            if (sessioncargo == null || sessioncargo != "tecnico")
            {
                Response.Redirect("/login");
            }
            if (!IsPostBack)
            {
                llenarPaciente();
                llenarHorario();
                llenarEspecialidad();
                llenarEstado();
                llenarAlerPre();
            }
        }

        public void llenarEstado()
        {
            ddlEstado.Items.Add("Reserva");
            ddlEstado.Items.Add("En curso");
            ddlEstado.Items.Add("No Asistio");
            ddlEstado.Items.Add("Concluido");
        }
        public void llenarPaciente() {
            DataSet ds = new DataSet();
            SqlCommand cm = new SqlCommand("select idpacientes as idpac, " +
                " concat('DNI: ', dni,' - ', apellido,', ', nombre) as detallepaciente" +
                " from pacientes",cone);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(ds);
            ddlpaciente.DataSource = ds;
            ddlpaciente.DataValueField = "idpac";
            ddlpaciente.DataTextField = "detallepaciente";
            ddlpaciente.DataBind();
        }
        public void llenarHorario() {
            DataSet ds = new DataSet();
            SqlCommand cm = new SqlCommand("select " +
                " concat('Hora Inicio: ', CONVERT(varchar,horainicio,24), ' - Hora Final: ', CONVERT(varchar,horafinal,24)) as DetalleHorario, idhorario as IdH" +
                " from horarios", cone);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(ds);
            ddlhorario.DataSource = ds;
            ddlhorario.DataValueField = "IdH";
            ddlhorario.DataTextField = "DetalleHorario";
            ddlhorario.DataBind();
        }
        public void llenarEspecialidad()
        {
            DataSet ds = new DataSet();
            SqlCommand cm = new SqlCommand("select " +
                " concat('Especialidad: ', e.nombre ,' - Médico: ',u.apellido,', ',u.nombre) as Especialidad, ed.idespdoctor as IdEspMed " +
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
        public void llenarAlerPre()
        {
            ddlAler.Items.Add("Si");
            ddlAler.Items.Add("No");
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            CitaMedica cm = new CitaMedica();

            cm.idpaciente = int.Parse(ddlpaciente.Text);
            cm.idhorario = int.Parse(ddlhorario.Text);
            cm.idespdoctor = int.Parse(ddlMedEsp.Text);
            cm.fechacita = DateTime.Parse(txtFecha.Text);
            cm.peso = Decimal.Parse(txtPeso.Text);
            cm.talla = Decimal.Parse(txtEstatura.Text);
            cm.estado = ddlEstado.Text;
            cm.alergiamedicamento = ddlAler.Text;

            dao.insertar(cm);
            Response.Redirect("/tecnico/citamedica/index");
        }

    }
}