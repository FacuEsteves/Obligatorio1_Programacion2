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

            GridTripulantes.DataSource = Global.transitoMaritimo.tripulantes;
            GridTripulantes.DataBind();

            if (!Page.IsPostBack)
            {
                DDCargo.DataSource = Global.transitoMaritimo.cargos;
                DDCargo.DataTextField = "nombreCargo";
                DDCargo.DataValueField = "nombreCargo";
                DDCargo.DataBind();
            }

            TotalTripulantes.Text = Convert.ToString(Global.transitoMaritimo.tripulantes.Count);
            Persistencia.tipostripulantes();

            GridTipoTripulante.DataSource = Global.transitoMaritimo.cantidadTripulantesXtipos;
            GridTipoTripulante.DataBind();
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
                    if (Global.transitoMaritimo.tripulantes[i].cedula == Convert.ToInt32(TxtCedula.Text))
                    {
                        LabelError.Text = "Ya se encuentra ingresado este tripulante";
                        tr = Global.transitoMaritimo.tripulantes[i];
                        tr.cedula = Convert.ToInt32(TxtCedula.Text);
                        tr.nombre = TxtNombre.Text;
                        tr.correo = TxtCorreo.Text;
                        tr.Cargo = DDCargo.SelectedValue;
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
                tr.Cargo = DDCargo.SelectedValue;
                Global.transitoMaritimo.tripulantes.Add(tr);
            }
            //FIN GUARDADO

            Persistencia.guardarDatos();
            Persistencia.tipostripulantes();

            //cargar grid 
            GridTripulantes.DataSource = Global.transitoMaritimo.tripulantes;
            GridTripulantes.DataBind();



            //LIMPIAR CAMPOS
            TxtCedula.Text = "";
            TxtNombre.Text = "";
            TxtCorreo.Text = "";
            LabelError.Text = "";
            TotalTripulantes.Text = Convert.ToString(Global.transitoMaritimo.tripulantes.Count);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            bool existe = false;

            int cedula = Convert.ToInt32(TxtCedula.Text);

            //BUSCAR BARCO LENTO REGISTRADO
            for (int i = 0; i < Global.transitoMaritimo.tripulantes.Count; i++)
            {
                if (Global.transitoMaritimo.tripulantes[i].cedula == cedula)
                {
                    TxtNombre.Text = Global.transitoMaritimo.tripulantes[i].nombre;
                    TxtCorreo.Text = Global.transitoMaritimo.tripulantes[i].correo;
                    DDCargo.SelectedValue = Global.transitoMaritimo.tripulantes[i].Cargo;
                    
                    existe = true;
                    break;
                }
            }

            if (existe == false)
            {
                LabelError.Text = "No se encontro registro de este tripulante";
            }
        }
    }
}