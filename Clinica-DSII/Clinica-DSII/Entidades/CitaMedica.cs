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
        public Double peso { get; set; }
        public Double talla { get; set; }
        public String alergiamedicamento { get; set; }

        public CitaMedica() { }

        public CitaMedica(int idpaciente, int idhorario, int idespdoctor, DateTime fechacita, string estado, double peso, double talla, string alergiamedicamento)
        {
            this.idpaciente = idpaciente;
            this.idhorario = idhorario;
            this.idespdoctor = idespdoctor;
            this.fechacita = fechacita;
            this.estado = estado;
            this.peso = peso;
            this.talla = talla;
            this.alergiamedicamento = alergiamedicamento;
        }
    }
}