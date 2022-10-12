using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio_1_prog2
{
    public partial class IngresarTripulantes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            LabelError.Text = "";


            //COMIENZO ERRORES
            if (TxtCedula.Text == "")
            {
                LabelError.Text = "Ingrese la cedula del tripulante";
                return;
            }
            if (TxtNombre.Text == "")
            {
                LabelError.Text = "Ingrese el nombre del tripulante";
                return;
            }
            if (TxtCorreo.Text == "")
            {
                LabelError.Text = "Ingrese el correo del tripulante";
                return;
            }
            //FIN ERRORES

            Tripulante tr = new Tripulante();
            bool existe = false;

            //BUSCAR TRIPULANTE REGISTRADO
            for (int i = 0; i < Global.transitoMaritimo.tripulantes.Count; i++)
            {
                if (Global.transitoMaritimo.tripulantes[i] != null)
                {
                    if (TxtCedula.Text == Global.transitoMaritimo.tripulantes[i].nombre)
                    {
                        LabelError.Text = "Ya se encuentra ingresado este tripulante";
                        tr = Global.transitoMaritimo.tripulantes[i];
                        tr.cedula = Convert.ToInt32(TxtCedula.Text);
                        tr.nombre = TxtNombre.Text;
                        tr.correo = TxtCorreo.Text;
                        existe = true;
                        break;
                    }
                }
            }
            //FIN BUSCAR

            //COMIENZO GUARDADO
            if (existe == false)
            {
                tr.cedula = Convert.ToInt32(TxtCedula.Text);
                tr.nombre = TxtNombre.Text;
                tr.correo = TxtCorreo.Text;
                tr.fechaIngreso = DateTime.Today;
                Global.transitoMaritimo.tripulantes.Add(tr);
            }
            //FIN GUARDADO

            Persistencia.guardarDatos();

            //cargar grid 
            GridTripulantes.DataSource = Global.transitoMaritimo.tripulantes;
            GridTripulantes.DataBind();



            //LIMPIAR CAMPOS
            TxtCedula.Text = "";
            TxtNombre.Text = "";
            TxtCorreo.Text = "";
            LabelError.Text = "";
        }
    }
}