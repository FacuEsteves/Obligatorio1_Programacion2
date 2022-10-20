using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio_1_prog2
{
    public partial class BusquedaDeMantenimientos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DDBarco.DataSource = Persistencia.ListaBarcos();
            DDBarco.DataTextField = "nombre";
            DDBarco.DataValueField = "nombre";
            DDBarco.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            String barco = DDBarco.SelectedValue;
            for (int i = 0; i < Global.transitoMaritimo.mantenimientos.Count; i++)
            {
                if (barco == Global.transitoMaritimo.mantenimientos[i].nombreBarco)
                {
                }
            }
        }
    }
}