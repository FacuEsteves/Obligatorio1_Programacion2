﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio_1_prog2
{
    public partial class IngresoMantenimiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DD_Barco.DataSource = Persistencia.ListaBarcos();
                DD_Barco.DataTextField = "nombre";
                DD_Barco.DataValueField = "nombre";
                DD_Barco.DataBind();

                DD_TipoM.DataSource = Global.transitoMaritimo.tiposMantenimiento;
                DD_TipoM.DataTextField = "descripcion";
                DD_TipoM.DataValueField = "codigo";
                DD_TipoM.DataBind();

                DD_Encargado.DataSource = Global.transitoMaritimo.encargados;
                DD_Encargado.DataTextField = "nombre";
                DD_Encargado.DataValueField = "cedula";
                DD_Encargado.DataBind();
            }

            CalendarDate.SelectedDate = DateTime.Today;

            GridMantenimientos.DataSource = Global.transitoMaritimo.mantenimientos;
            GridMantenimientos.DataBind();

           
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            LabelError.Text = "";


            //COMIENZO ERRORES
            if (TxtDescripcion.Text == "")
            {
                LabelError.Text = "Ingrese la descripción";
                return;
            }
            if (DD_Barco.SelectedIndex == -1)
            {
                LabelError.Text = "Elija un barco";
                return;
            }
            if (DD_TipoM.SelectedIndex == -1)
            {
                LabelError.Text = "Elija un tipo de mantenimiento";
                return;
            }
            if (DD_Encargado.SelectedIndex == -1)
            {
                LabelError.Text = "Elija un encargado";
                return;
            }
            //FIN ERRORES

            Mantenimiento m = new Mantenimiento();
            bool existe = false;


            //COMIENZO GUARDADO
            if (existe == false)
            {
                m.fechaMantenimiento = CalendarDate.SelectedDate;
                m.descripcion = TxtDescripcion.Text;

                String barco = DD_Barco.SelectedValue;
                m.nombreBarco = barco;
                for (int i = 0; i < Global.transitoMaritimo.barcoLentos.Count; i++)
                {
                    if(barco == Global.transitoMaritimo.barcoLentos[i].nombre)
                    {
                        m.barcos = Global.transitoMaritimo.barcoLentos[i];
                        m.tipobarco = "Barco Lento";
                        break;
                    }
                }
                for (int i = 0; i < Global.transitoMaritimo.barcoRapidos.Count; i++)
                {
                    if (barco == Global.transitoMaritimo.barcoRapidos[i].nombre)
                    {
                        m.barcos = Global.transitoMaritimo.barcoRapidos[i];
                        m.tipobarco = "Barco Rapido";
                        break;
                    }
                }

                Int64 codigo = Convert.ToInt32(DD_TipoM.SelectedValue);
                for (int i = 0; i < Global.transitoMaritimo.tiposMantenimiento.Count; i++)
                {
                    if (codigo == Global.transitoMaritimo.tiposMantenimiento[i].codigo)
                    {
                        m.TiposMantenimiento = Global.transitoMaritimo.tiposMantenimiento[i];
                        if (m.tipobarco=="Barco Lento") 
                        {
                            m.precio = Global.transitoMaritimo.tiposMantenimiento[i].precioBase;
                        }
                        if (m.tipobarco=="Barco Rapido")
                        {
                            double porcentaje = Global.transitoMaritimo.tiposMantenimiento[i].precioBase * 0.30;
                            m.precio = Global.transitoMaritimo.tiposMantenimiento[i].precioBase+Convert.ToInt32(porcentaje)+200;
                        }
                        break;
                    }
                }

                Int64 cedula = Convert.ToInt32(DD_Encargado.SelectedValue);
                for (int i = 0; i < Global.transitoMaritimo.encargados.Count; i++)
                {
                    if (cedula == Global.transitoMaritimo.encargados[i].cedula)
                    {
                        m.encargados = Global.transitoMaritimo.encargados[i];
                        break;
                    }
                }
                m.Terminado = false;
                Global.transitoMaritimo.mantenimientos.Add(m);
            }
            //FIN GUARDADO

            Persistencia.guardarDatos();

            //cargar grid 
            GridMantenimientos.DataSource = Global.transitoMaritimo.mantenimientos;
            GridMantenimientos.DataBind();


            //LIMPIAR CAMPOS
            CalendarDate.SelectedDate = DateTime.Today;
            TxtDescripcion.Text = "";
            DD_Barco.SelectedIndex = -1;
            DD_TipoM.SelectedIndex = -1;
            DD_Encargado.SelectedIndex = -1;
            LabelError.Text = "";
        }

        protected void GridMantenimientos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //dar como terminado el mantenimeinto

            String descripcion = e.Values["descripcion"].ToString();

            for(int i=0; i< Global.transitoMaritimo.mantenimientos.Count; i++)
            {
                if (true == Global.transitoMaritimo.mantenimientos[i].Terminado)
                {
                    LabelError.Text = "Este mantenimiento ya esta terminado";
                    return;
                }
                else
                {
                    if (descripcion == Global.transitoMaritimo.mantenimientos[i].descripcion)
                    {
                        Global.transitoMaritimo.mantenimientos[i].Terminado = true;
                        LabelError.Text = "Se registro el mantenimiento " + descripcion + " como terminado";
                        break;
                    }
                }
                
            }
            Persistencia.guardarDatos();

            GridMantenimientos.DataSource = Global.transitoMaritimo.mantenimientos;
            GridMantenimientos.DataBind();
        }
    }
}