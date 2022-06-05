using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinica_DSII.Entidades
{
    public class Consulta
    {
        public int idconsulta { get; set; }
        public int idmedico { get; set; }
        public int especialidad { get; set; }
        public int horario { get; set; }
        public double precio { get; set; }

        public Consulta() { }
    }
}