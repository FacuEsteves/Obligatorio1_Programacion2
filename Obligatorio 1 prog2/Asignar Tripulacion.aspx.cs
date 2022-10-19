using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio_1_prog2
{
    public partial class Asignar_Tripulacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridAsignar.DataSource = Persistencia.TripulantesSinAsignar();
            GridAsignar.DataBind();
        }

        protected void GridAsignar_SelectedIndexChanged(object sender, EventArgs e)
        {
            LabelError.Text = "";

            if(DD_Barcos.SelectedIndex == -1)
            {
                LabelError.Text = "Elija un barco";
                return;
            }
            String barcoAsignado = "";
            int index = GridAsignar.SelectedIndex;

            List<Tripulante> triAsignar = new List<Tripulante>();

            triAsignar = Persistencia.TripulantesSinAsignar();

            int cedula = triAsignar[index].cedula;

            barcoAsignado = DD_Barcos.SelectedValue;

            for(int i = 0; i < Global.transitoMaritimo.tripulantes.Count; i++)
            {
                if(cedula == Global.transitoMaritimo.tripulantes[i].cedula)
                {
                    Global.transitoMaritimo.tripulantes[i].NombreBarco = barcoAsignado;
                }
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridAsignar.DataSource = Persistencia.TripulantesSinAsignar();
            GridAsignar.DataBind();
        }
    }
}