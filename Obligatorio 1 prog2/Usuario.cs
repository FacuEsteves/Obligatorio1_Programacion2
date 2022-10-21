using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio_1_prog2
{
    public class Usuario:Persona
    {
        public string nombreUsuario { get; set; }
        public string contraseña { get; set; }
        public string tipoUsuario { get; set; }
        public Boolean AsignarTripulacion { get; set; }
        public Boolean BusquedaMant { get; set; }
        public Boolean IngresarCargos { get; set; }
        public Boolean IngresarTripulantes { get; set; }
        public Boolean IngresarEncargados { get; set; }
        public Boolean IngresoMantenimiento { get; set; }
        public Boolean IngresoUsuarios { get; set; }
        public Boolean RegistroBarco { get; set; }
    }
}