﻿using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.IO;

namespace Obligatorio_1_prog2
{
    public class Persistencia
    {
        private static String rutaArchivo = HttpRuntime.AppDomainAppPath + "Datos\\" + "Informacion.xml";

        public static void guardarDatos()
        {
            XmlSerializer writer = new XmlSerializer(typeof(TransitoMaritimo), new Type[] { typeof(BarcoLento), typeof(BarcoRapido), typeof(Cargo), typeof(Encargado), typeof(Mantenimiento), typeof(Registro), typeof(Tipo_de_Mantenimiento), typeof(Tripulante), typeof(Usuario) });

            System.IO.StreamWriter file = new System.IO.StreamWriter(rutaArchivo);
            writer.Serialize(file, Global.transitoMaritimo);
            file.Close();
        }


        public static void leerDatos()
        {

            if (File.Exists(rutaArchivo))
            {
                XmlSerializer reader = new XmlSerializer(typeof(TransitoMaritimo), new Type[] { typeof(BarcoLento), typeof(BarcoRapido), typeof(Cargo), typeof(Encargado), typeof(Mantenimiento), typeof(Registro), typeof(Tipo_de_Mantenimiento), typeof(Tripulante), typeof(Usuario) });

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
        public static List<Mantenimiento> MantenimientosRealizados(String barcoSeleccionado)
        {
            List<Mantenimiento> mant = new List<Mantenimiento>();

            for (int i = 0; i < Global.transitoMaritimo.mantenimientos.Count; i++)
            {
                if (Global.transitoMaritimo.mantenimientos[i].nombreBarco == barcoSeleccionado)
                {
                    mant.Add(Global.transitoMaritimo.mantenimientos[i]);
                }
            }

            return mant;
        }
    }
}