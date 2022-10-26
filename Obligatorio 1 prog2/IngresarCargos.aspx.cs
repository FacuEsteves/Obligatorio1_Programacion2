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

            GridCargos.DataSource = Global.transitoMaritimo.cargos;
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

            Persistencia.RegistroCambio(Global.transitoMaritimo.idUsuario, "Ingresar cargo");
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