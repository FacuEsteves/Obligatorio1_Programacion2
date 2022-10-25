using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio_1_prog2
{
    public partial class IngresoUsuario : System.Web.UI.Page
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
                }
            }

            GridUsuario.DataSource = Global.transitoMaritimo.usuarios;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            LabelError.Text = "";


            Usuario us = new Usuario();
            us.nombre = txtNombre.Text;
            us.cedula = Convert.ToInt32(txtCedula.Text);
            us.nombreUsuario = txtID.Text;
            us.contraseña = txtContraseña.Text;
            us.correo = txtCorreo.Text;
            us.AsignarTripulacion=CheckBox1.Checked;
            us.IngresarCargos=CheckBox2.Checked;
            us.IngresarTripulantes=CheckBox3.Checked;
            us.IngresarEncargados=CheckBox4.Checked;
            us.IngresoMantenimiento=CheckBox5.Checked;
            us.IngresoTipoMantenimiento = CheckBox6.Checked;
            us.IngresoUsuarios = CheckBox7.Checked;
            us.RegistroBarco = CheckBox8.Checked;
            us.BusquedaMant = CheckBox9.Checked;
            
            Global.transitoMaritimo.usuarios.Add(us);
            GridUsuario.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                LabelError.Text = "Ingrese Nombre de Usuario Para Buscar";
                return;
            }
            for (int i = 0; i < Global.transitoMaritimo.usuarios.Count; i++)
            {
                if (txtID.Text == Global.transitoMaritimo.usuarios[i].nombreUsuario)
                {
                    txtNombre.Text = Global.transitoMaritimo.usuarios[i].nombre;
                    txtCedula.Text = Convert.ToString(Global.transitoMaritimo.usuarios[i].cedula);
                    txtContraseña.Text= Global.transitoMaritimo.usuarios[i].contraseña;
                    txtCorreo.Text= Global.transitoMaritimo.usuarios[i].correo;
                    CheckBox1.Checked= Global.transitoMaritimo.usuarios[i].AsignarTripulacion;
                    CheckBox2.Checked= Global.transitoMaritimo.usuarios[i].IngresarCargos;
                    CheckBox3.Checked= Global.transitoMaritimo.usuarios[i].IngresarTripulantes;
                    CheckBox4.Checked= Global.transitoMaritimo.usuarios[i].IngresarEncargados;
                    CheckBox5.Checked= Global.transitoMaritimo.usuarios[i].IngresoMantenimiento;
                    CheckBox6.Checked= Global.transitoMaritimo.usuarios[i].IngresoTipoMantenimiento;
                    CheckBox7.Checked= Global.transitoMaritimo.usuarios[i].IngresoUsuarios;
                    CheckBox8.Checked= Global.transitoMaritimo.usuarios[i].RegistroBarco;
                    CheckBox9.Checked= Global.transitoMaritimo.usuarios[i].BusquedaMant;

                }
            }
        }
    }
}