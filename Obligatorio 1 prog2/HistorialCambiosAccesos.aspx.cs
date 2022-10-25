using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio_1_prog2
{
    public partial class HistorialCambiosAccesos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /*
                DD_Usuarios.DataSource = Global.transitoMaritimo.usuarios;
                DD_Usuarios.DataTextField = "nombre";
                DD_Usuarios.DataValueField = "nombreUsuario";
                DD_Usuarios.DataBind();
                */
                GridAccesos.DataSource = Global.transitoMaritimo.registrosA;
                GridAccesos.DataBind();

                GridEgresos.DataSource = Global.transitoMaritimo.registrosE;
                GridEgresos.DataBind();

                GridCambios.DataSource = Global.transitoMaritimo.registrosC;
                GridCambios.DataBind();
            }
        }

        protected void BtnEntrar_Click(object sender, EventArgs e)
        {
            Persistencia.RegistroAcceso(usua.Text);
            GridAccesos.DataSource = Global.transitoMaritimo.registrosA;
            GridAccesos.DataBind();
        }

        protected void BtnSalir_Click(object sender, EventArgs e)
        {
            Persistencia.RegistroEgreso(usua.Text);
            GridEgresos.DataSource = Global.transitoMaritimo.registrosE;
            GridEgresos.DataBind();
        }

        protected void BtnCambio_Click(object sender, EventArgs e)
        {
            Persistencia.RegistroCambio(usua.Text, descripcion.Text);

            GridCambios.DataSource = Global.transitoMaritimo.registrosC;
            GridCambios.DataBind();
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            GridAccesos.DataSource = Persistencia.FiltroAcceso(FechaFiltro.SelectedDate, DD_Usuarios.SelectedValue.ToString());
            GridAccesos.DataBind();
            GridEgresos.DataSource = Persistencia.FiltroEgreso(FechaFiltro.SelectedDate, DD_Usuarios.SelectedValue.ToString());
            GridEgresos.DataBind();
            GridCambios.DataSource = Persistencia.FiltroCambios(FechaFiltro.SelectedDate, DD_Usuarios.SelectedValue.ToString(), DD_Cambios.SelectedValue.ToString());
            GridCambios.DataBind();
        }

        protected void BtnBorrar_Click(object sender, EventArgs e)
        {
            GridAccesos.DataSource = Global.transitoMaritimo.registrosA;
            GridAccesos.DataBind();

            GridEgresos.DataSource = Global.transitoMaritimo.registrosE;
            GridEgresos.DataBind();

            GridCambios.DataSource = Global.transitoMaritimo.registrosC;
            GridCambios.DataBind();

            DD_Cambios.SelectedIndex = 0;
            DD_Usuarios.SelectedIndex = 0;
            FechaFiltro.SelectedDate = DateTime.Now;
        }
    }
}