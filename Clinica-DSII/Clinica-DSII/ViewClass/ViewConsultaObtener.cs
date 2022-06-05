using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinica_DSII.ViewClass
{
    public class ViewConsultaObtener
    {
        public int idconsulta { get; set; }
        public int idmedico { get; set; }
        public int idespecialidad { get; set; }
        public string especialidad { get; set; }
        public int idhorario { get; set; }
        public double precio { get; set; }

        public ViewConsultaObtener() { }
    }
}