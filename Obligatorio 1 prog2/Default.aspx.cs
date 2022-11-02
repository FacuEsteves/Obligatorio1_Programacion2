using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Obligatorio_1_prog2
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Global.transitoMaritimo.idUsuario = null;

            if (Global.transitoMaritimo.idUsuario == null)
            {
                this.Master.FindControl("Asignar_Tripulacion").Visible = false;
                this.Master.FindControl("RegistroBarco").Visible = false;
                this.Master.FindControl("IngresoCargos").Visible = false;
                this.Master.FindControl("IngresarTripulantes").Visible = false;
                this.Master.FindControl("IngresoEncargados").Visible = false;
                this.Master.FindControl("IngresoMantenimiento").Visible = false;
                this.Master.FindControl("IngresoUsuario").Visible = false;
                this.Master.FindControl("IngresoTipoMantenimiento").Visible = false;
                this.Master.FindControl("BusquedaDeMantenimientos").Visible = false;
                this.Master.FindControl("HistorialCambiosAccesos").Visible = false;
                this.Master.FindControl("BtnSalir").Visible = false;
            }
        }

        protected void btnIniciar_Click(object sender, EventArgs e)
        {
            /*
            string message = "Hello! Mudassar.";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
            */

            LabelError.Text = "";

            if (txtUsuario.Text == "")
            {
                LabelError.Text = "Ingrese el nombre";
                return;
            }
            if (txtContraseña.Text == "")
            {
                LabelError.Text = "Ingrese la contraseña";
                return;
            }

            for (int i = 0; i < Global.transitoMaritimo.usuarios.Count; i++)
            {
                if(Global.transitoMaritimo.usuarios[i].nombreUsuario==txtUsuario.Text && Global.transitoMaritimo.usuarios[i].contrasenia == txtContraseña.Text)
                {
                    Global.transitoMaritimo.idUsuario = Global.transitoMaritimo.usuarios[i].nombreUsuario;
                    Persistencia.RegistroAcceso(Global.transitoMaritimo.idUsuario);
                    Response.Redirect("Bienvenido.aspx");
                    //Server.Transfer("");
                    txtUsuario.Text = "";
                }
                else
                {
                    LabelError.Text = "Usuario o Contraseña Incorrecto";
                }
            }

        }
    }
}

/*
 * PARA ERROR --> "could not find file…\bin\roslyn\csc.exe"
 * Barra superior --> Herramientas --> Administrador de paquetes NuGet --> Consola del Administrador de paquetes
 * pegar este codigo --> update-package Microsoft.CodeDom.Providers.DotNetCompilerPlatform
 */