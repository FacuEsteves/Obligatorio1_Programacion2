﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio_1_prog2
{
    public partial class BusquedaDeMantenimientos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            //Creacion Tabla
            DataTable tabla1 = new DataTable();
            tabla1.Columns.Add("Fecha", typeof(string));
            tabla1.Columns.Add("Tipo", typeof(string));
            tabla1.Columns.Add("Precio", typeof(string));
            tabla1.Columns.Add("Total", typeof(int));

            //Variables Usadas
            string barco = txtBarco.Text;
            string mes = DDMes.SelectedValue;
            int año = Convert.ToInt32(txtAño.Text);
            int TOTAL = 0;

            //Comienzo Busqueda
            for (int i = 0; i < Global.transitoMaritimo.mantenimientos.Count; i++)
            {
                if (barco==Global.transitoMaritimo.mantenimientos[i].nombreBarco && mes == Convert.ToString(Global.transitoMaritimo.mantenimientos[i].fechaMantenimiento.Month) && año == Global.transitoMaritimo.mantenimientos[i].fechaMantenimiento.Year)
                {
                    //Asignacion de Valores a la Tabla
                    string fecha = Convert.ToString(Global.transitoMaritimo.mantenimientos[i].fechaMantenimiento);
                    string tipo = Global.transitoMaritimo.mantenimientos[i].nombreBarco;
                    string precio = Convert.ToString(Global.transitoMaritimo.mantenimientos[i].precio);
                    TOTAL = Global.transitoMaritimo.mantenimientos[i].precio + TOTAL;

                    tabla1.Rows.Add(fecha, tipo, precio);

                }
            }
            tabla1.Rows.Add(' ', ' ', ' ', TOTAL);

            //Mostrar
            GridView1.DataSource = tabla1;
            GridView1.DataBind();
        }
    }
}