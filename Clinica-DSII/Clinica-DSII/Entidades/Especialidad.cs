using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinica_DSII.Entidades
{
    public class Especialidad
    {
        public int idespecialidad { get; set; }
        public string nombre { get; set; }

        public Especialidad() { }

        public Especialidad(int idespecialidad, string nombre)
        {
            this.idespecialidad = idespecialidad;
            this.nombre = nombre;
        }
    }
}