using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio_1_prog2
{
    public class TransitoMaritimo
    {
        public List<BarcoLento> barcoLentos = new List<BarcoLento>();
        public List<BarcoRapido> barcoRapidos = new List<BarcoRapido>();
        public List<Cargo> cargos = new List<Cargo>();
        public List<Mantenimiento> mantenimientos = new List<Mantenimiento>();
        public List<Tipo_de_Mantenimiento> tiposMantenimiento = new List<Tipo_de_Mantenimiento>();
        public List<Usuario> usuarios = new List<Usuario>();
        public List<Tripulante> tripulantes = new List<Tripulante>();
        public List<Encargado> encargados = new List<Encargado>();
        public List<cantidadTripulantesXtipo> cantidadTripulantesXtipos = new List<cantidadTripulantesXtipo>();
        public string idUsuario;
    }
}
