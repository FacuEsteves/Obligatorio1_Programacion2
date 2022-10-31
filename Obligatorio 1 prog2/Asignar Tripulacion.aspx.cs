using Newtonsoft.Json.Linq;
using Obligatorio_1_prog2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio_1_prog2
{
    public partial class Asignar_Tripulacion : System.Web.UI.Page
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

            if (!IsPostBack)
            {
                DD_Barcos.DataSource = Persistencia.ListaBarcos();
                DD_Barcos.DataTextField = "nombre";
                DD_Barcos.DataValueField = "nombre";
                DD_Barcos.DataBind();
            }
            GridAsignar.DataSource = Persistencia.TripulantesSinAsignar();
            GridAsignar.DataBind();

            GridAsignados.DataSource = Persistencia.TripulantesAsignados(DD_Barcos.SelectedValue);
            GridAsignados.DataBind();
        }

        protected void GridAsignar_SelectedIndexChanged(object sender, EventArgs e)
        {
            LabelError.Text = "";

            if(DD_Barcos.SelectedIndex == -1)
            {
                LabelError.ForeColor = System.Drawing.Color.Red;
                LabelError.Text = "Elija un barco";
                return;
            }
            String barcoAsignado = DD_Barcos.SelectedValue; 
            int index = GridAsignar.SelectedIndex;

            List<Tripulante> triAsignar = new List<Tripulante>();

            triAsignar = Persistencia.TripulantesSinAsignar();

            int cedula = triAsignar[index].cedula;
            int countCapitan = 0;
            int maximo=0;
            int contador = 1;

            for (int j = 0; j < Global.transitoMaritimo.barcoLentos.Count; j++)
            {
                if (barcoAsignado == Global.transitoMaritimo.barcoLentos[j].nombre)
                {
                    maximo = Global.transitoMaritimo.barcoLentos[j].cantidadTripulantes;
                    break;
                }
            }

            for (int j = 0; j < Global.transitoMaritimo.barcoRapidos.Count; j++)
            {
                if (barcoAsignado == Global.transitoMaritimo.barcoRapidos[j].nombre)
                {
                    maximo = Global.transitoMaritimo.barcoRapidos[j].cantidadTripulantes;
                    break;
                }
            }

            //recorre la tripulacion
            foreach (var item in Global.transitoMaritimo.tripulantes)
            {
                //buscar que la tripulacion tenga un barco asignado
                if (!String.IsNullOrEmpty(item.NombreBarco))
                {
                    //buscar que un barco ya tenga o no capitan
                    if(item.NombreBarco == barcoAsignado)
                    {
                        if(item.Cargo == "Capitán") {
                            countCapitan++;
                        }
                        
                    }        
                   
                }
            }
            //si el cargo del seleccionado es distinto a capitan se setea el contador 0 para que lo ingrese pq no es necesario validar
            if(triAsignar[index].Cargo != "Capitán") {
                countCapitan = 0;
            }


            if (countCapitan == 1)
            {
                LabelError.ForeColor = System.Drawing.Color.Red;
                LabelError.Text = "Ya existe un capitan en este barco";
            }
            else
            {
                for (int i = 0; i < Global.transitoMaritimo.tripulantes.Count; i++)
                {
                    if (Global.transitoMaritimo.tripulantes[i].NombreBarco == barcoAsignado)
                    {
                        contador++;
                        if (contador > maximo)
                        {
                            LabelError.ForeColor = System.Drawing.Color.Red;
                            LabelError.Text = "El barco " + barcoAsignado+" "+"supero su maximo de: "+maximo+ " tripulantes";
                            return;
                        }
                        else
                        {
                            if (cedula == Global.transitoMaritimo.tripulantes[i].cedula)
                            {
                                Global.transitoMaritimo.tripulantes[i].NombreBarco = barcoAsignado;
                                LabelError.ForeColor = System.Drawing.Color.Green;
                                LabelError.Text = "Se asigno el tripulante " + cedula + " al barco " + barcoAsignado;
                                break;
                            }
                        }
                    }
                }
            }
            GridAsignar.DataSource = Persistencia.TripulantesSinAsignar();
            GridAsignar.DataBind();

            Persistencia.RegistroCambio(Global.transitoMaritimo.idUsuario, "Asignar tripulación");
            Persistencia.guardarDatos();

            GridAsignados.DataSource = Persistencia.TripulantesAsignados(DD_Barcos.SelectedValue);
            GridAsignados.DataBind();
        }
       

        protected void DD_Barcos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridAsignados.DataSource = Persistencia.TripulantesAsignados(DD_Barcos.SelectedValue);
            GridAsignados.DataBind();

            GridAsignar.DataSource = Persistencia.TripulantesSinAsignar();
            GridAsignar.DataBind();
        }

        protected void GridAsignados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String cedula = e.Values["cedula"].ToString();

            LabelError.Text = "";

            if (DD_Barcos.SelectedIndex == -1)
            {
                LabelError.Text = "Elija un barco";
                return;
            }
            String barcoAsignados = DD_Barcos.SelectedValue;

            for (int i = 0; i < Global.transitoMaritimo.tripulantes.Count; i++)
            {
                if (Convert.ToUInt32(cedula) == Global.transitoMaritimo.tripulantes[i].cedula)
                {
                    Global.transitoMaritimo.tripulantes[i].NombreBarco = null;
                    LabelError.Text = "Se elimino el tripulante " + cedula + " del barco " + barcoAsignados;
                    break;
                }
            }

            Persistencia.RegistroCambio(Global.transitoMaritimo.idUsuario, "Borrar asignado");
            Persistencia.guardarDatos();

            GridAsignados.DataSource = Persistencia.TripulantesAsignados(DD_Barcos.SelectedValue);
            GridAsignados.DataBind();

            GridAsignar.DataSource = Persistencia.TripulantesSinAsignar();
            GridAsignar.DataBind();

            
        }
    }
}