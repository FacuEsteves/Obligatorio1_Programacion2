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
            Persistencia.RegistroCambio(Global.transitoMaritimo.idUsuario, "Ingreso encargados");
            Persistencia.guardarDatos();

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
            int cedula = 00000000;

            if (TxtCedula.Text != "")
            {
                cedula = Convert.ToInt32(TxtCedula.Text);
            }
            

            //BUSCAR ENCARGADO REGISTRADO
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

        protected void GridEncargados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String cedula = e.Values["cedula"].ToString();

            for (int i = 0; i < Global.transitoMaritimo.encargados.Count; i++)
            {
                if (Global.transitoMaritimo.encargados[i].cedula == Convert.ToInt32(cedula))
                {
                    LabelError.Text = "Se borro el encargado " + Global.transitoMaritimo.encargados[i].nombre;
                    Global.transitoMaritimo.encargados.Remove(Global.transitoMaritimo.encargados[i]);
                    break;
                }
            }

            Persistencia.RegistroCambio(Global.transitoMaritimo.idUsuario, "Borrar encargado");
            Persistencia.guardarDatos();

            GridEncargados.DataBind();
        }
    }
}
