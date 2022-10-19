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
        public Barco barcos { get; set; }
        public String tipobarco { get; set; }
        public Tipo_de_Mantenimiento TiposMantenimiento { get; set; }
        public Encargado encargados { get; set; }
    }
}