using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinica_DSII.Entidades
{
    public class Paciente
    {
        public int idpacientes { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string dni { get; set; }
        public string correo { get; set; }
        public DateTime fechanacimiento { get; set; }

        public Paciente()
        {
        }

        public Paciente(int idpacientes, string nombre, string apellido, string dni, string correo, DateTime fechanacimiento)
        {
            this.idpacientes = idpacientes;
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.correo = correo;
            this.fechanacimiento = fechanacimiento;
        }
    }
}