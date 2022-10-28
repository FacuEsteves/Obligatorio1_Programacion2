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
                    this.Master.FindControl("HistorialCambiosAccesos").Visible = Global.transitoMaritimo.usuarios[i].Historial;
                }
            }

            GridUsuario.DataSource = Global.transitoMaritimo.usuarios;
            GridUsuario.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                LabelError.Text = "Datos Faltantes Para La Creación de un Uusuario";
            }
            if (txtCedula.Text == "")
            {
                LabelError.Text = "Datos Faltantes Para La Creación de un Uusuario";
            }
            if (txtContraseña.Text == "")
            {
                LabelError.Text = "Datos Faltantes Para La Creación de un Uusuario";
            }
            if (txtID.Text == "")
            {
                LabelError.Text = "Datos Faltantes Para La Creación de un Uusuario";
            }
            if (txtCorreo.Text == "")
            {
                LabelError.Text = "Datos Faltantes Para La Creación de un Uusuario";
            }

            Usuario us = new Usuario();

            LabelError.Text = "";
            bool existe = false;
            for (int i = 0; i < Global.transitoMaritimo.usuarios.Count; i++)
            {
                if (Global.transitoMaritimo.usuarios[i] != null)
                {
                    if (Global.transitoMaritimo.usuarios[i].cedula == Convert.ToInt32(txtCedula.Text))
                    {
                        LabelError.Text = "Ya se encuentra ingresado este usuario";
                        us.nombre = txtNombre.Text;
                        us.cedula = Convert.ToInt32(txtCedula.Text);
                        us.nombreUsuario = txtID.Text;
                        us.contraseña = txtContraseña.Text;
                        us.correo = txtCorreo.Text;
                        us.AsignarTripulacion = CheckBox1.Checked;
                        us.IngresarCargos = CheckBox2.Checked;
                        us.IngresarTripulantes = CheckBox3.Checked;
                        us.IngresarEncargados = CheckBox4.Checked;
                        us.IngresoMantenimiento = CheckBox5.Checked;
                        us.IngresoTipoMantenimiento = CheckBox6.Checked;
                        us.IngresoUsuarios = CheckBox7.Checked;
                        us.RegistroBarco = CheckBox8.Checked;
                        us.BusquedaMant = CheckBox9.Checked;
                        us.Historial = CheckBox10.Checked;
                        existe = true;
                        break;
                    }
                }
            }

            if (existe == false)
            {
                us.nombre = txtNombre.Text;
                us.cedula = Convert.ToInt32(txtCedula.Text);
                us.nombreUsuario = txtID.Text;
                us.contraseña = txtContraseña.Text;
                us.correo = txtCorreo.Text;
                us.AsignarTripulacion = CheckBox1.Checked;
                us.IngresarCargos = CheckBox2.Checked;
                us.IngresarTripulantes = CheckBox3.Checked;
                us.IngresarEncargados = CheckBox4.Checked;
                us.IngresoMantenimiento = CheckBox5.Checked;
                us.IngresoTipoMantenimiento = CheckBox6.Checked;
                us.IngresoUsuarios = CheckBox7.Checked;
                us.RegistroBarco = CheckBox8.Checked;
                us.BusquedaMant = CheckBox9.Checked;
                us.Historial = CheckBox10.Checked;
                Global.transitoMaritimo.usuarios.Add(us);
            }

            Persistencia.RegistroCambio(Global.transitoMaritimo.idUsuario, "Ingreso usuarios");
            Persistencia.guardarDatos();
            GridUsuario.DataBind();


            txtNombre.Text = "";
            txtCedula.Text = "";
            txtID.Text = "";
            txtContraseña.Text = "";
            txtCorreo.Text = "";
            CheckBox1.Checked = false;
            CheckBox2.Checked = false;
            CheckBox3.Checked = false;
            CheckBox4.Checked = false;
            CheckBox5.Checked = false;
            CheckBox6.Checked = false;
            CheckBox7.Checked = false;
            CheckBox8.Checked = false;
            CheckBox9.Checked = false;
            CheckBox10.Checked = false;
        }

        
        protected void GridUsuario_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String nombre = e.Values["nombreUsuario"].ToString();

            for (int i = 0; i < Global.transitoMaritimo.usuarios.Count; i++)
            {
                if (nombre == Global.transitoMaritimo.usuarios[i].nombreUsuario){
                    LabelError.Text = "Se elimino el usuario " + Global.transitoMaritimo.usuarios[i].nombre;
                    Global.transitoMaritimo.usuarios.Remove(Global.transitoMaritimo.usuarios[i]);
                    break;
                }
            }

            Persistencia.RegistroCambio(Global.transitoMaritimo.idUsuario, "Borrar usuario");
            Persistencia.guardarDatos();
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
                if (txtCedula.Text == Convert.ToString(Global.transitoMaritimo.usuarios[i].cedula))
                {
                    txtNombre.Text = Global.transitoMaritimo.usuarios[i].nombre;
                    txtID.Text = Global.transitoMaritimo.usuarios[i].nombreUsuario;
                    txtContraseña.Text = Global.transitoMaritimo.usuarios[i].contraseña;
                    txtCorreo.Text = Global.transitoMaritimo.usuarios[i].correo;
                    CheckBox1.Checked = Global.transitoMaritimo.usuarios[i].AsignarTripulacion;
                    CheckBox2.Checked = Global.transitoMaritimo.usuarios[i].IngresarCargos;
                    CheckBox3.Checked = Global.transitoMaritimo.usuarios[i].IngresarTripulantes;
                    CheckBox4.Checked = Global.transitoMaritimo.usuarios[i].IngresarEncargados;
                    CheckBox5.Checked = Global.transitoMaritimo.usuarios[i].IngresoMantenimiento;
                    CheckBox6.Checked = Global.transitoMaritimo.usuarios[i].IngresoTipoMantenimiento;
                    CheckBox7.Checked = Global.transitoMaritimo.usuarios[i].IngresoUsuarios;
                    CheckBox8.Checked = Global.transitoMaritimo.usuarios[i].RegistroBarco;
                    CheckBox9.Checked = Global.transitoMaritimo.usuarios[i].BusquedaMant;
                    CheckBox10.Checked = Global.transitoMaritimo.usuarios[i].Historial;

                }
            }
        }
    }
}