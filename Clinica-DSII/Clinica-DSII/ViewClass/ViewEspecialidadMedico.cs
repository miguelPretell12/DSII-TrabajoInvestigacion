using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinica_DSII.ViewClass
{
    public class ViewEspecialidadMedico
    {
        public int idespmed { get; set; }
        public int idusuario { get; set; }

        public int idespecialidad { get; set; }
        public string medico { get; set; }
        public string dni { get; set; }
        public string correo { get; set; }

        public string especialidad { get; set; }

        public ViewEspecialidadMedico() { }

    }
}