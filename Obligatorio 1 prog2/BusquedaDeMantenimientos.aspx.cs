using System;
using System.Collections.Generic;
using System.Data;
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
            DataTable tabla1 = new DataTable();
            string barco = txtBarco.Text;
            tabla1.Columns.Add("Fecha", typeof(string));
            tabla1.Columns.Add("Tipo", typeof(string));
            tabla1.Columns.Add("Precio", typeof(int));
            for (int i = 0; i < Global.transitoMaritimo.mantenimientos.Count; i++)
            {
                if (barco==Global.transitoMaritimo.mantenimientos[i].nombreBarco)
                {
                    string fecha = Convert.ToString(Global.transitoMaritimo.mantenimientos[i].fechaMantenimiento);
                    string tipo = Global.transitoMaritimo.mantenimientos[i].nombreBarco;
                    string precio = Convert.ToString(Global.transitoMaritimo.mantenimientos[i].precio);

                    tabla1.Rows.Add(fecha, tipo, precio);

                }
            }
            GridView1.DataSource = tabla1;
            GridView1.DataBind();
        }
    }
}