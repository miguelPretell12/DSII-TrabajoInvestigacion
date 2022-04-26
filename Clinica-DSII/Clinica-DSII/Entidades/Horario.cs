using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinica_DSII.Entidades
{
    public class Horario
    {
        public TimeSpan horainicio;
        public TimeSpan horafinal;

        public Horario() { 
        }

        public Horario(TimeSpan horainicio, TimeSpan horafinal)
        {
            this.horainicio = horainicio;
            this.horafinal = horafinal;
        }
    }
}