using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio_1_prog2
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
                LabelError.Text = "Ingrese el contraseña";
                return;
            }

            for (int i = 0; i < Global.transitoMaritimo.usuarios.Count; i++)
            {
                if(Global.transitoMaritimo.usuarios[i].nombreUsuario==txtUsuario.Text && Global.transitoMaritimo.usuarios[i].contraseña == txtUsuario.Text)
                {
                    LabelError.ForeColor = System.Drawing.Color.Blue;
                    LabelError.Text = "Bienvenido";
                }
                else
                {
                    LabelError.Text = "Usuario o Contraseña Incorrecto";
                }
            }

        }
    }
}