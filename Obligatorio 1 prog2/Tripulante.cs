using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio_1_prog2
{
    public class Tripulante:Persona
    {
        public DateTime fechaIngreso { get; set; }
        public String NombreBarco { get; set; }
        public String Cargo { get; set; }
    }
}