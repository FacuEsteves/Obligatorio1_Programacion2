using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio_1_prog2
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void BtnSalir_Click(object sender, EventArgs e)
        {
            Persistencia.RegistroEgreso(Global.transitoMaritimo.idUsuario);
            Server.Transfer("Default.aspx");
        }
    }
}