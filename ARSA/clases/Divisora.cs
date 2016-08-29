using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ARSA.clases
{
    public class Divisora
    {
        public static List<String> getListado(String cadena) {
            List<String> resultado = new List<String>();
            string[] palabras = cadena.Split(',',')','(');
            foreach (String palabra in palabras){
                resultado.Add(palabra);
            }
            return resultado;
        }

        public static String getCadena(DataTable tabla) {
            if (tabla.Rows.Count == 0){
                return null;
            }
            else{
                String cadena = "";
                foreach (DataRow row in tabla.Rows){
                    cadena = cadena + "(";
                    foreach (DataColumn column in tabla.Columns){
                        cadena = cadena + row[column]+",";
                    }
                    cadena = cadena.Substring(0, cadena.Length - 1);
                    cadena = cadena + ")\n";
                }
                if (cadena.Equals("")){
                    return null;
                }
                return cadena;
            }
        }
    }
}