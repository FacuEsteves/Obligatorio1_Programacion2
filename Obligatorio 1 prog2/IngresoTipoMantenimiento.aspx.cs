using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio_1_prog2
{
    public partial class IngresoTipoMantenimiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridTiposMantenimiento.DataSource = Global.transitoMaritimo.tiposMantenimiento;
            GridTiposMantenimiento.DataBind();
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            LabelError.Text = "";


            //COMIENZO ERRORES
            if (TxtCodigo.Text == "")
            {
                LabelError.Text = "Ingrese el codigo";
                return;
            }
            if (TxtPrecioBase.Text == "")
            {
                LabelError.Text = "Ingrese el precio base";
                return;
            }
            if (TxtDescripcion.Text == "")
            {
                LabelError.Text = "Ingrese la descripción";
                return;
            }
            //FIN ERRORES

            Tipo_de_Mantenimiento tm = new Tipo_de_Mantenimiento();
            bool existe = false;

            //BUSCAR TIPOS DE MANTENIMEINTOS REGISTRADOS
            for (int i = 0; i < Global.transitoMaritimo.tiposMantenimiento.Count; i++)
            {
                if (Global.transitoMaritimo.tiposMantenimiento[i] != null)
                {
                    if (Convert.ToInt32(TxtCodigo.Text) == Global.transitoMaritimo.tiposMantenimiento[i].codigo)
                    {
                        LabelError.Text = "Ya se encuentra ingresado este tipo de mantenimiento";
                        tm = Global.transitoMaritimo.tiposMantenimiento[i];
                        tm.codigo = Convert.ToInt32(TxtCodigo.Text);
                        tm.precioBase = Convert.ToInt32(TxtPrecioBase.Text);
                        tm.descripcion = TxtDescripcion.Text;
                        existe = true;
                        break;
                    }
                }
            }
            //FIN BUSCAR

            //COMIENZO GUARDADO
            if (existe == false)
            {
                tm.codigo = Convert.ToInt32(TxtCodigo.Text);
                tm.precioBase = Convert.ToInt32(TxtPrecioBase.Text);
                tm.descripcion = TxtDescripcion.Text;
                Global.transitoMaritimo.tiposMantenimiento.Add(tm);
            }
            //FIN GUARDADO

            Persistencia.guardarDatos();

            //cargar grid 
            GridTiposMantenimiento.DataSource = Global.transitoMaritimo.tiposMantenimiento;
            GridTiposMantenimiento.DataBind();



            //LIMPIAR CAMPOS
            TxtCodigo.Text = "";
            TxtPrecioBase.Text = "";
            TxtDescripcion.Text = "";
            LabelError.Text = "";
        }
    }
}