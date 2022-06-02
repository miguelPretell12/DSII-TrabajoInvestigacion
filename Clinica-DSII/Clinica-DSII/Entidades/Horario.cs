using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinica_DSII.Entidades
{
    public class Horario
    {
        public int idhorario { get; set; }
        public TimeSpan horainicio { get; set; }
        public TimeSpan horafinal { get; set; }

        public Horario() { 
        }

        public Horario(TimeSpan horainicio, TimeSpan horafinal)
        {
            this.horainicio = horainicio;
            this.horafinal = horafinal;
        }


    }
}