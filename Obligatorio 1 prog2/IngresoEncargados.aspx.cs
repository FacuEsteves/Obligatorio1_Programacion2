using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio_1_prog2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridEncargados.DataSource = Global.transitoMaritimo.encargados;
            GridEncargados.DataBind();
        }

        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            LabelError.Text = "";


            //COMIENZO ERRORES
            if (TxtCedula.Text == "")
            {
                LabelError.Text = "Ingrese la cedula del encargado";
                return;
            }
            if (TxtNombre.Text == "")
            {
                LabelError.Text = "Ingrese el nombre del encargado";
                return;
            }
            if (TxtCorreo.Text == "")
            {
                LabelError.Text = "Ingrese el correo del encargado";
                return;
            }
            if (TxtCantPersonas.Text == "")
            {
                LabelError.Text = "Ingrese la cantidad de personas a cargo del encargado";
                return;
            }
            //FIN ERRORES

            Encargado en = new Encargado();
            bool existe = false;

            //BUSCAR BARCO LENTO REGISTRADO
            for (int i = 0; i < Global.transitoMaritimo.encargados.Count; i++)
            {
                if (Global.transitoMaritimo.encargados[i] != null)
                {
                    if (TxtCedula.Text == Global.transitoMaritimo.encargados[i].nombre)
                    {
                        LabelError.Text = "Ya se encuentra ingresado este encargado";
                        en = Global.transitoMaritimo.encargados[i];
                        en.cedula = Convert.ToInt32(TxtCedula.Text);
                        en.nombre = TxtNombre.Text;
                        en.correo = TxtCorreo.Text;
                        en.cantidadPersonal = Convert.ToInt32(TxtCantPersonas.Text);
                        existe = true;
                        break;
                    }
                }
            }
            //FIN BUSCAR

            //COMIENZO GUARDADO
            if (existe == false)
            {
                en.cedula = Convert.ToInt32(TxtCedula.Text);
                en.nombre = TxtNombre.Text;
                en.correo = TxtCorreo.Text;
                en.cantidadPersonal = Convert.ToInt32(TxtCantPersonas.Text);
                Global.transitoMaritimo.encargados.Add(en);
                LabelError.Text = "Se guardó con exito";
            }
            //FIN GUARDADO

            //cargar grid 
            GridEncargados.DataSource = Global.transitoMaritimo.encargados;
            GridEncargados.DataBind();

            

            //LIMPIAR CAMPOS
            TxtCedula.Text = "";
            TxtNombre.Text = "";
            TxtCorreo.Text = "";
            TxtCantPersonas.Text = "";
            LabelError.Text = "";

        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            bool existe = false;

            int cedula = Convert.ToInt32(TxtCedula.Text);

            //BUSCAR BARCO LENTO REGISTRADO
            for (int i = 0; i < Global.transitoMaritimo.encargados.Count; i++)
            {
                if (Global.transitoMaritimo.encargados[i].cedula == cedula)
                {
                    TxtNombre.Text = Global.transitoMaritimo.encargados[i].nombre;
                    TxtCorreo.Text = Global.transitoMaritimo.encargados[i].correo;
                    TxtCantPersonas.Text = Convert.ToString(Global.transitoMaritimo.encargados[i].cantidadPersonal);
                    existe = true;
                    break;
                }
            }

            if (existe == false)
            {
                LabelError.Text = "No se encontro registro de este encargado";
            }
        }
    }
}
