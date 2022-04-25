using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinica_DSII.Entidades
{
    public class Usuario
    {
        public int idusuarios {  get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string dni { get; set; }
        public string correo { get; set; }
        public string contrasenia { get; set; }
        public int cargos { get; set; }
        public string estado { get; set; }

        public Usuario() { }

        public Usuario( string nombre, string apellido, string dni, string correo, string contrasenia, int cargos, string estado)
        {
            
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.correo = correo;
            this.contrasenia = contrasenia;
            this.cargos = cargos;
            this.estado = estado;
        }
    }
}