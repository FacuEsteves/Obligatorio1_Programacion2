using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.IO;
using System.Web.Services.Description;
using System.Web.UI.HtmlControls;
using Microsoft.Ajax.Utilities;
using System.Net.Mail;
using System.Net;

namespace Obligatorio_1_prog2
{
    public class Persistencia
    {
        private static String rutaArchivo = HttpRuntime.AppDomainAppPath + "Datos\\" + "Informacion.xml";

        public static void guardarDatos()
        {
            XmlSerializer writer = new XmlSerializer(typeof(TransitoMaritimo), new Type[] { typeof(BarcoLento), typeof(BarcoRapido), typeof(Cargo), typeof(Encargado), typeof(Mantenimiento), typeof(RegistroAcceso), typeof(RegistroEgreso), typeof(RegistroCambio), typeof(Tipo_de_Mantenimiento), typeof(Tripulante), typeof(Usuario) });

            System.IO.StreamWriter file = new System.IO.StreamWriter(rutaArchivo);
            writer.Serialize(file, Global.transitoMaritimo);
            file.Close();
        }


        public static void leerDatos()
        {

            if (File.Exists(rutaArchivo))
            {
                XmlSerializer reader = new XmlSerializer(typeof(TransitoMaritimo), new Type[] { typeof(BarcoLento), typeof(BarcoRapido), typeof(Cargo), typeof(Encargado), typeof(Mantenimiento), typeof(RegistroAcceso), typeof(RegistroEgreso), typeof(RegistroCambio), typeof(Tipo_de_Mantenimiento), typeof(Tripulante), typeof(Usuario) });

                System.IO.StreamReader file = new System.IO.StreamReader(rutaArchivo);
                Global.transitoMaritimo = (TransitoMaritimo)reader.Deserialize(file);
                file.Close();
            }
        }

        public static List<Tripulante> TripulantesSinAsignar()
        {
            List<Tripulante> tri = new List<Tripulante>();

            for (int i = 0; i < Global.transitoMaritimo.tripulantes.Count; i++)
            {
                if (Global.transitoMaritimo.tripulantes[i].NombreBarco == null)
                {
                    tri.Add(Global.transitoMaritimo.tripulantes[i]);
                }
            }

            return tri;
        }

        public static List<Tripulante> TripulantesAsignados(String barcoSeleccionado)
        {
            List<Tripulante> trip = new List<Tripulante>();

            for (int i = 0; i < Global.transitoMaritimo.tripulantes.Count; i++)
            {
                if (Global.transitoMaritimo.tripulantes[i].NombreBarco == barcoSeleccionado)
                {
                    trip.Add(Global.transitoMaritimo.tripulantes[i]);
                }
            }

            return trip;
        }

        public static List<Barco> ListaBarcos()
        {
            List<Barco> barcos = new List<Barco>();

            for (int i = 0; i < Global.transitoMaritimo.barcoLentos.Count; i++)
            {
                barcos.Add(Global.transitoMaritimo.barcoLentos[i]);
            }
            for (int i = 0; i < Global.transitoMaritimo.barcoRapidos.Count; i++)
            {
                barcos.Add(Global.transitoMaritimo.barcoRapidos[i]);
            }

            return barcos;
        }

        public static int idmantenimiento()
        {
            int ultimoN = Global.transitoMaritimo.mantenimientos.Count;
            int id = ultimoN + 1;

            return id;
        }


        public static void tipostripulantes()
        {
            
            for(int i = 0; i < Global.transitoMaritimo.cargos.Count; i++)
            {
                cantidadTripulantesXtipo a = new cantidadTripulantesXtipo();
                int cant = 0;
                for (int index = 0; index < Global.transitoMaritimo.tripulantes.Count; index++)
                {
                    if (Global.transitoMaritimo.tripulantes[index].Cargo == Global.transitoMaritimo.cargos[i].nombreCargo)
                    {
                        cant++;
                    }

                }
                a.Cargo = Global.transitoMaritimo.cargos[i].nombreCargo;
                a.Cantidad = cant;
                Global.transitoMaritimo.cantidadTripulantesXtipos.Add(a);
            }



        }

        public static void RegistroAcceso (String Usuario)
        {
            RegistroAcceso a = new RegistroAcceso();
            a.usuarios = Usuario;
            a.fechaAcceso = DateTime.Now;
            Global.transitoMaritimo.registrosA.Add(a);

            Persistencia.guardarDatos();
        }
        public static void RegistroEgreso (String Usuario)
        {
            RegistroEgreso eg = new RegistroEgreso();
            eg.usuarios = Usuario;
            eg.fechaEgreso = DateTime.Now;
            Global.transitoMaritimo.registrosE.Add(eg);

            Persistencia.guardarDatos();
        }
        public static void RegistroCambio (String Usuario, String Descripcion)
        {
            RegistroCambio c = new RegistroCambio();
            c.usuarios = Usuario;
            c.fechaCambio = DateTime.Now;
            c.descripcion = Descripcion;
            Global.transitoMaritimo.registrosC.Add(c);

            Persistencia.guardarDatos();
        }

        public static List<RegistroAcceso> FiltroAcceso(DateTime fecha, String Usuario)
        {
            List<RegistroAcceso> lista = new List<RegistroAcceso>();

            if (fecha != null && Usuario == "(Seleccionar)")//null)
            {
                for (int i = 0; i < Global.transitoMaritimo.registrosA.Count; i++)
                {
                    if(fecha == Global.transitoMaritimo.registrosA[i].fechaAcceso)
                    {
                        lista.Add(Global.transitoMaritimo.registrosA[i]);
                    }
                }
            }
            else if(fecha == null && Usuario != "(Seleccionar)")//null)
            {
                for (int i = 0; i < Global.transitoMaritimo.registrosA.Count; i++)
                {
                    if (Usuario == Global.transitoMaritimo.registrosA[i].usuarios)
                    {
                        lista.Add(Global.transitoMaritimo.registrosA[i]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < Global.transitoMaritimo.registrosA.Count; i++)
                {
                    if (fecha == Global.transitoMaritimo.registrosA[i].fechaAcceso && Usuario == Global.transitoMaritimo.registrosA[i].usuarios)
                    {
                        lista.Add(Global.transitoMaritimo.registrosA[i]);
                    }
                }
            }

            return lista;
        }
        public static List<RegistroEgreso> FiltroEgreso(DateTime fecha, String Usuario)
        {
            List<RegistroEgreso> lista = new List<RegistroEgreso>();

            if (fecha != null && Usuario == "(Seleccionar)")//null)
            {
                for (int i = 0; i < Global.transitoMaritimo.registrosE.Count; i++)
                {
                    if (fecha == Global.transitoMaritimo.registrosE[i].fechaEgreso)
                    {
                        lista.Add(Global.transitoMaritimo.registrosE[i]);
                    }
                }
            }
            else if (fecha == null && Usuario != "(Seleccionar)")//null)
            {
                for (int i = 0; i < Global.transitoMaritimo.registrosE.Count; i++)
                {
                    if (Usuario == Global.transitoMaritimo.registrosE[i].usuarios)
                    {
                        lista.Add(Global.transitoMaritimo.registrosE[i]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < Global.transitoMaritimo.registrosE.Count; i++)
                {
                    if (fecha == Global.transitoMaritimo.registrosE[i].fechaEgreso && Usuario == Global.transitoMaritimo.registrosE[i].usuarios)
                    {
                        lista.Add(Global.transitoMaritimo.registrosE[i]);
                    }
                }
            }

            return lista;
        }
        public static List<RegistroCambio> FiltroCambios(DateTime fecha, String Usuario, String Descripcion)
        {
            List<RegistroCambio> lista = new List<RegistroCambio>();

            if (fecha != null && Usuario == "(Seleccionar)" && Descripcion == null)
            {
                for (int i = 0; i < Global.transitoMaritimo.registrosC.Count; i++)
                {
                    if (fecha == Global.transitoMaritimo.registrosC[i].fechaCambio)
                    {
                        lista.Add(Global.transitoMaritimo.registrosC[i]);
                    }
                }
            }
            else if (fecha == null && Usuario != "(Seleccionar)" && Descripcion == null)
            {
                for (int i = 0; i < Global.transitoMaritimo.registrosC.Count; i++)
                {
                    if (Usuario == Global.transitoMaritimo.registrosC[i].usuarios)
                    {
                        lista.Add(Global.transitoMaritimo.registrosC[i]);
                    }
                }
            }
            else if (fecha == null && Usuario == "(Seleccionar)" && Descripcion != null)
            {
                for (int i = 0; i < Global.transitoMaritimo.registrosC.Count; i++)
                {
                    if (Descripcion == Global.transitoMaritimo.registrosC[i].descripcion)
                    {
                        lista.Add(Global.transitoMaritimo.registrosC[i]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < Global.transitoMaritimo.registrosC.Count; i++)
                {
                    if (fecha == Global.transitoMaritimo.registrosC[i].fechaCambio && Usuario == Global.transitoMaritimo.registrosC[i].usuarios && Descripcion == Global.transitoMaritimo.registrosC[i].descripcion)
                    {
                        lista.Add(Global.transitoMaritimo.registrosC[i]);
                    }
                }
            }

            return lista;
        }
        public static string enviarEmail(string asunto, string htmlString, string emailDestinatario)
        {
            string resultado = "";
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                message.From = new MailAddress("maritimotransito@gmail.com");
                message.To.Add(new MailAddress(emailDestinatario));
                message.Subject = asunto;
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = htmlString;

                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("maritimotransito@gmail.com", "cptswphhphgvkohq");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }
    }
}

/*public static string SplitMes(string Fecha)
{
    string[] FechaDes = Fecha.Split('/');
    string Mes = FechaDes[1];
    return Mes;
}
public static string SplitAño(string Fecha)
{
    string[] FechaDes = Fecha.Split('/');
    string Año = FechaDes[2];
    return Año;
}*/