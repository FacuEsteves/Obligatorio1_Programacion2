using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio_1_prog2
{
    public partial class IngresarCargos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridCargos.DataBind();
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            LabelError.Text = "";


            //COMIENZO ERRORES
            if (TxtNombreCargo.Text == "")
            {
                LabelError.Text = "Ingrese la cedula del tripulante";
                return;
            }
            //FIN ERRORES

            Cargo c = new Cargo();
            bool existe = false;

            //BUSCAR TRIPULANTE REGISTRADO
            for (int i = 0; i < Global.transitoMaritimo.cargos.Count; i++)
            {
                if (Global.transitoMaritimo.cargos[i] != null)
                {
                    if (TxtNombreCargo.Text == Global.transitoMaritimo.cargos[i].nombreCargo)
                    {
                        LabelError.Text = "Ya se encuentra ingresado este cargo";
                        c = Global.transitoMaritimo.cargos[i];
                        c.nombreCargo = TxtNombreCargo.Text;
                        existe = true;
                        break;
                    }
                }
            }
            //FIN BUSCAR

            //COMIENZO GUARDADO
            if (existe == false)
            {
                c.nombreCargo = TxtNombreCargo.Text;
                Global.transitoMaritimo.cargos.Add(c);
            }
            //FIN GUARDADO

            Persistencia.guardarDatos();

            //cargar grid 
            GridCargos.DataSource = Global.transitoMaritimo.cargos;
            GridCargos.DataBind();



            //LIMPIAR CAMPOS
            TxtNombreCargo.Text = "";;
            LabelError.Text = "";
        }
    }
}