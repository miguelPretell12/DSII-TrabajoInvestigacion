using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinica_DSII.Entidades
{
    public class Cargo
    {
        public int idcargos { get; set; }
        public string nombre { get; set; }
        
        public Cargo() { }

        public Cargo(int idcargos, string nombre)
        {
            this.idcargos = idcargos;
            this.nombre = nombre;
        }
    }
}