using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinica_DSII.ViewClass
{
    public class ViewConsultas
    {
        public int idconsulta { get; set; }
        public string medico { get; set; }
        public string especialidad { get; set; }
        public TimeSpan horainicio { get; set; }
        public TimeSpan horafinal { get; set; }
        public double precio { get; set; } 

        public ViewConsultas() { }
    }
}