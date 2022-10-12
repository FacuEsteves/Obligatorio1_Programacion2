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
    }
}