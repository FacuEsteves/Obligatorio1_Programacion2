using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;   

namespace Obligatorio_1_prog2
{
    public class Mantenimiento
    {
        public DateTime fechaMantenimiento { get; set; }
        public string descripcion { get; set; }
        public List<Barco> barcos = new List<Barco>();
        public List<Tipo_de_Mantenimiento> tiposMantenimiento = new List<Tipo_de_Mantenimiento>();
        public List<Encargado> encargados = new List<Encargado>();
    }
}