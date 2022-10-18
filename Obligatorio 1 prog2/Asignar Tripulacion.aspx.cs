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

        protected void GridAsignar_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Asignar")
            {
                LabelError.Text = Convert.ToString(e);
            }
        }
    }
}