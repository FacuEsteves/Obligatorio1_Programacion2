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
            for (int i = 0; i < Global.transitoMaritimo.usuarios.Count; i++)
            {
                if (Global.transitoMaritimo.idUsuario == Global.transitoMaritimo.usuarios[i].nombreUsuario)
                {
                    this.Master.FindControl("Asignar_Tripulacion").Visible = Global.transitoMaritimo.usuarios[i].AsignarTripulacion;
                    this.Master.FindControl("IngresoCargos").Visible = Global.transitoMaritimo.usuarios[i].IngresarCargos;
                    this.Master.FindControl("IngresarTripulantes").Visible = Global.transitoMaritimo.usuarios[i].IngresarTripulantes;
                    this.Master.FindControl("IngresoEncargados").Visible = Global.transitoMaritimo.usuarios[i].IngresarEncargados;
                    this.Master.FindControl("IngresoMantenimiento").Visible = Global.transitoMaritimo.usuarios[i].IngresoMantenimiento;
                    this.Master.FindControl("IngresoTipoMantenimiento").Visible = Global.transitoMaritimo.usuarios[i].IngresoTipoMantenimiento;
                    this.Master.FindControl("IngresoUsuario").Visible = Global.transitoMaritimo.usuarios[i].IngresoUsuarios;
                    this.Master.FindControl("RegistroBarco").Visible = Global.transitoMaritimo.usuarios[i].RegistroBarco;
                    this.Master.FindControl("BusquedaDeMantenimientos").Visible = Global.transitoMaritimo.usuarios[i].BusquedaMant;
                    this.Master.FindControl("HistorialCambiosAccesos").Visible = Global.transitoMaritimo.usuarios[i].Historial;
                }
            }

            if (!IsPostBack)
            {
     
                DD_Usuarios.DataSource = Global.transitoMaritimo.usuarios;
                DD_Usuarios.DataTextField = "nombre";
                DD_Usuarios.DataValueField = "nombreUsuario";
                DD_Usuarios.DataBind();
                
                DD_Usuarios.SelectedIndex = -1;
                
                GridAccesos.DataSource = Global.transitoMaritimo.registrosA;
                GridAccesos.DataBind();

                GridEgresos.DataSource = Global.transitoMaritimo.registrosE;
                GridEgresos.DataBind();

                GridCambios.DataSource = Global.transitoMaritimo.registrosC;
                GridCambios.DataBind();
            }
        }


        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            
            DateTime fechanull = new DateTime(1, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            //ERRORES
            
            if (FechaFiltro.SelectedDate == fechanull && DD_Usuarios.SelectedIndex == 0 && DD_Cambios.SelectedIndex == 0)
            {
                Label1.Text = "ELIJA UNA OPCION DE FILTRADO";
                return;
            }
            
            
            GridAccesos.DataSource = Persistencia.FiltroAcceso(FechaFiltro.SelectedDate, DD_Usuarios.SelectedValue.ToString());
            GridAccesos.DataBind();
            GridEgresos.DataSource = Persistencia.FiltroEgreso(FechaFiltro.SelectedDate, DD_Usuarios.SelectedValue.ToString());
            GridEgresos.DataBind();
            GridCambios.DataSource = Persistencia.FiltroCambios(FechaFiltro.SelectedDate, DD_Usuarios.SelectedValue.ToString(), DD_Cambios.SelectedValue.ToString());
            GridCambios.DataBind();
        }

        protected void BtnBorrar_Click(object sender, EventArgs e)
        {
            DateTime fechanull = new DateTime(1, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            GridAccesos.DataSource = Global.transitoMaritimo.registrosA;
            GridAccesos.DataBind();

            GridEgresos.DataSource = Global.transitoMaritimo.registrosE;
            GridEgresos.DataBind();

            GridCambios.DataSource = Global.transitoMaritimo.registrosC;
            GridCambios.DataBind();

            DD_Cambios.SelectedIndex = 0;
            DD_Usuarios.SelectedIndex = 0;
            FechaFiltro.SelectedDate = fechanull;
        }
    }
}