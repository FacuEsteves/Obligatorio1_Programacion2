using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio_1_prog2
{
    public partial class RegistroBarco : System.Web.UI.Page
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

            //cargar grid lentos
            GridBarcoLento.DataSource = Global.transitoMaritimo.barcoLentos;
            GridBarcoLento.DataBind();

            //cargar grid rapidos
            GridBarcoRapido.DataSource = Global.transitoMaritimo.barcoRapidos;
            GridBarcoRapido.DataBind();
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            LabelError.Text = "";
            

            //COMIENZO ERRORES
            if (TxtNombreBarco.Text == "")
            {
                LabelError.Text = "Ingrese el nombre del barco";
                return;
            }
            if (TipoBarco.SelectedIndex == 0)
            {
                LabelError.Text = "Elija un tipo de barco";
                return;
            }
            if (TxtCantPasajeros.Text == "")
            {
                LabelError.Text = "Ingrese cantidad de pasajeros";
                return;
            }
            if (TxtCantMaxTripulantes.Text == "")
            {
                LabelError.Text = "Ingrese numero maximo de tripulantes";
                return;
            }
            //FIN ERRORES
            
            
            BarcoLento bl = new BarcoLento();
            BarcoRapido br = new BarcoRapido();
            bool existe = false;

            //BUSCAR BARCO LENTO REGISTRADO
            for (int i = 0; i < Global.transitoMaritimo.barcoLentos.Count; i++)
            {
                if (Global.transitoMaritimo.barcoLentos[i] != null)
                {
                    if (TxtNombreBarco.Text == Global.transitoMaritimo.barcoLentos[i].nombre)
                    {
                        LabelError.Text = "Ya se encuentra ingresado este barco";
                        bl = Global.transitoMaritimo.barcoLentos[i];
                        bl.nombre = TxtNombreBarco.Text;
                        bl.cantidadPasajeros = Convert.ToInt32(TxtCantPasajeros.Text);
                        bl.cantidadTripulantes = Convert.ToInt32(TxtCantMaxTripulantes.Text);
                        bl.cantidadVehiculos = Convert.ToInt32(TxtCantVehiculos.Text);
                        bl.precioMantenimiento = Convert.ToInt32(TxtPrecioMant.Text);
                        existe = true;
                        break;
                    }
                }
            }

            //BUSCAR BARCO RAPIDO REGISTRADO
            for (int i = 0; i < Global.transitoMaritimo.barcoRapidos.Count; i++)
            {
                if (Global.transitoMaritimo.barcoRapidos[i] != null)
                {
                    if (TxtNombreBarco.Text == Global.transitoMaritimo.barcoRapidos[i].nombre)
                    {
                        LabelError.Text = "Ya se encuentra ingresado este barco";
                        br = Global.transitoMaritimo.barcoRapidos[i];
                        br.nombre = TxtNombreBarco.Text;
                        br.cantidadPasajeros = Convert.ToInt32(TxtCantPasajeros.Text);
                        br.cantidadTripulantes = Convert.ToInt32(TxtCantMaxTripulantes.Text);
                        br.velocidadMax = Convert.ToInt32(TxtVelMaxima.Text);
                        existe = true;
                        break;
                    }
                }
            }
            //FIN BUSCAR

            //COMIENZO GUARDADO
            if ( existe == false )
            {
                if (TipoBarco.SelectedIndex == 1)
                {
                    if (TxtCantVehiculos.Text != "")
                    {
                        bl.nombre = TxtNombreBarco.Text;
                        bl.cantidadPasajeros = Convert.ToInt32(TxtCantPasajeros.Text);
                        bl.cantidadTripulantes = Convert.ToInt32(TxtCantMaxTripulantes.Text);
                        bl.cantidadVehiculos = Convert.ToInt32(TxtCantVehiculos.Text);
                        bl.precioMantenimiento = Convert.ToInt32(TxtPrecioMant.Text);
                        Global.transitoMaritimo.barcoLentos.Add(bl);
                        LabelError.Text = "Se guardó con exito";

                    }
                    else
                    {
                        LabelError.Text = "Ingrese la cantidad maxima de vehiculos";
                        return;
                    }

                }
                else
                {
                    if (TxtVelMaxima.Text != "")
                    {
                        br.nombre = TxtNombreBarco.Text;
                        br.cantidadPasajeros = Convert.ToInt32(TxtCantPasajeros.Text);
                        br.cantidadTripulantes = Convert.ToInt32(TxtCantMaxTripulantes.Text);
                        br.velocidadMax = Convert.ToInt32(TxtVelMaxima.Text);
                        Global.transitoMaritimo.barcoRapidos.Add(br);
                        LabelError.Text = "Se guardó con exito";
                    }
                    else
                    {
                        LabelError.Text = "Ingrese Velocidad Maxima";
                        return;
                    }
                }
            }

            Persistencia.RegistroCambio(Global.transitoMaritimo.idUsuario, "Registro barco");
            Persistencia.guardarDatos();
            //cargar grid lentos
            GridBarcoLento.DataSource = Global.transitoMaritimo.barcoLentos;
            GridBarcoLento.DataBind();

            //cargar grid rapidos
            GridBarcoRapido.DataSource = Global.transitoMaritimo.barcoRapidos;
            GridBarcoRapido.DataBind();

            //FIN GUARDADO

            //LIMPIAR CAMPOS
            TxtNombreBarco.Text="";
            TxtCantPasajeros.Text ="";
            TxtCantMaxTripulantes.Text ="";
            TipoBarco.SelectedIndex=0;
            TxtCantVehiculos.Text="";
            TxtVelMaxima.Text = "";
            LabelError.Text = "";

        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            bool existe = false;

            String nombreBarco = TxtNombreBarco.Text;

            //BUSCAR BARCO LENTO REGISTRADO
            for (int i = 0; i < Global.transitoMaritimo.barcoLentos.Count; i++)
            {
                if (Global.transitoMaritimo.barcoLentos[i].nombre == nombreBarco)
                {
                    TxtCantPasajeros.Text = Convert.ToString(Global.transitoMaritimo.barcoLentos[i].cantidadPasajeros);
                    TxtCantMaxTripulantes.Text = Convert.ToString(Global.transitoMaritimo.barcoLentos[i].cantidadTripulantes);
                    TipoBarco.SelectedIndex = 1;
                    TxtCantVehiculos.Text = Convert.ToString(Global.transitoMaritimo.barcoLentos[i].cantidadVehiculos);
                    existe = true;
                    break;
                }
            
            }

            //BUSCAR BARCO RAPIDO REGISTRADO
            for (int i = 0; i < Global.transitoMaritimo.barcoRapidos.Count; i++)
            {
                if (Global.transitoMaritimo.barcoRapidos[i] != null)
                {
                    if (TxtNombreBarco.Text == Global.transitoMaritimo.barcoRapidos[i].nombre)
                    {
                        TxtCantPasajeros.Text = Convert.ToString(Global.transitoMaritimo.barcoRapidos[i].cantidadPasajeros);
                        TxtCantMaxTripulantes.Text = Convert.ToString(Global.transitoMaritimo.barcoRapidos[i].cantidadTripulantes);
                        TipoBarco.SelectedIndex=2;
                        TxtVelMaxima.Text = Convert.ToString(Global.transitoMaritimo.barcoRapidos[i].velocidadMax);
                        existe = true;
                        break;
                    }
                }
            }
            
            if(existe == false)
            {
                LabelError.Text = "No se encontro registro de ese barco";
            }
        }

        protected void TipoBarco_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(TipoBarco.SelectedValue == "(Seleccionar)")
            {
                LabelCantVehi.Visible = false;
                LabelVelMax.Visible = false;
                LabelPrecioM.Visible = false;
                TxtVelMaxima.Visible = false;
                TxtCantVehiculos.Visible = false;
                TxtPrecioMant.Visible = false;

            }
            else if (TipoBarco.SelectedValue == "BarcoLento")
            {
                LabelCantVehi.Visible = true;
                LabelVelMax.Visible = false;
                LabelPrecioM.Visible = true;
                TxtVelMaxima.Visible = false;
                TxtCantVehiculos.Visible = true;
                TxtPrecioMant.Visible = true;
            }
            else
            {
                LabelCantVehi.Visible = false;
                LabelVelMax.Visible = true;
                LabelPrecioM.Visible = false;
                TxtVelMaxima.Visible = true;
                TxtCantVehiculos.Visible = false;
                TxtPrecioMant.Visible = false;
            }
        }

        protected void GridBarcoRapido_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String nombreB = e.Values["nombre"].ToString();

            for (int i = 0; i < Global.transitoMaritimo.barcoRapidos.Count; i++)
            {
                if (Global.transitoMaritimo.barcoRapidos[i] != null)
                {
                    if (nombreB == Global.transitoMaritimo.barcoRapidos[i].nombre)
                    {
                        LabelError.Text = "Se borro el barco " + Global.transitoMaritimo.barcoRapidos[i].nombre;
                        Global.transitoMaritimo.barcoRapidos.Remove(Global.transitoMaritimo.barcoRapidos[i]);
                        break;
                    }
                }
            }

            Persistencia.RegistroCambio(Global.transitoMaritimo.idUsuario, "Borrar barco");
            Persistencia.guardarDatos();

            GridBarcoRapido.DataBind();
        }

        protected void GridBarcoLento_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String nombreB = e.Values["nombre"].ToString();

            for (int i = 0; i < Global.transitoMaritimo.barcoLentos.Count; i++)
            {
                if (Global.transitoMaritimo.barcoLentos[i].nombre == nombreB)
                {
                    LabelError.Text = "Se borro el barco " + Global.transitoMaritimo.barcoLentos[i].nombre;
                    Global.transitoMaritimo.barcoLentos.Remove(Global.transitoMaritimo.barcoLentos[i]);
                    break;
                }

            }

            Persistencia.RegistroCambio(Global.transitoMaritimo.idUsuario, "Borrar barco");
            Persistencia.guardarDatos();

            GridBarcoLento.DataBind();
        }
    }
}