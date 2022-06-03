using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinica_DSII.Entidades
{
    public class CitaMedica
    {
        public int idcitamedica { get; set; }
        public int idpaciente { get; set; }
        public int idhorario { get; set; }
        public int idespdoctor { get; set; }
        public DateTime fechacita { get; set; }
        public string estado { get; set; }
        public Decimal peso { get; set; }
        public Decimal talla { get; set; }
        public String alergiamedicamento { get; set; }

        public CitaMedica() { }

        public CitaMedica(int idcitamedica, int idpaciente, int idhorario, int idespdoctor, DateTime fechacita, string estado, Decimal peso, Decimal talla, string alergiamedicamento)
        {
            this.idcitamedica = idcitamedica;
            this.idpaciente = idpaciente;
            this.idhorario = idhorario;
            this.idespdoctor = idespdoctor;
            this.fechacita = fechacita;
            this.estado = estado;
            this.peso = peso;
            this.talla = talla;
            this.alergiamedicamento = alergiamedicamento;
        }

        public string paciente(string v)
        {
            return idpaciente.ToString();
        }
        public string horario(string v)
        {
            return idhorario.ToString();
        }
        public string espdoctor(string v)
        {
            return idespdoctor.ToString();
        }
        public string fechaC(string v)
        {
            return fechacita.ToString();
        }
    }
}