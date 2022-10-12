using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio_1_prog2
{
    public class Registro
    {
        public List<Usuario> usuarios = new List<Usuario>();
        public DateTime fechaAcceso { get; set; }
        public DateTime cambio { get; set; }
        public string descripcionCambio { get; set; }
    }
}