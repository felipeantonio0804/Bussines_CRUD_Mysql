using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ARSA.clases
{
    public class Controladora{
        
        public static String obtenerProducto(int idProducto){
            String cadenaConexion = "server=127.0.0.1; database=almacen; Uid=root; pwd=felipemisterio;";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            String query = "CALL REGISTRO("+idProducto+",1111);";
            MySqlCommand comando = new MySqlCommand(query, conexion);
            MySqlDataReader lector = comando.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(lector);
            conexion.Close();

            if (tabla.Rows.Count==0) {
                return null;
            }
            else{
                String cadena = "";
                foreach (DataRow row in tabla.Rows){
                    foreach (DataColumn column in tabla.Columns){
                        cadena = cadena + row[column];
                    }
                }
                if (cadena.Equals("")) {
                    return null;
                }
                return cadena;
            }
        }
    
        public static String registroProducto(int idProducto,String nombre,String descripcion,String ruta,String opcion){
            String cadenaConexion = "server=127.0.0.1; database=almacen; Uid=root; pwd=felipemisterio;";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            String query = "CALL REGISTROPRODUCTO("+idProducto+",'"+nombre+"','"+descripcion+"','"+ruta+"','"+opcion+"');";
            MySqlCommand comando = new MySqlCommand(query, conexion);
            MySqlDataReader lector = comando.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(lector);
            conexion.Close();

            if (tabla.Rows.Count==0) {
                return null;
            }
            else{
                String cadena = "";
                foreach (DataRow row in tabla.Rows){
                    foreach (DataColumn column in tabla.Columns){
                        cadena = cadena + row[column];
                    }
                }
                if (cadena.Equals("")) {
                    return null;
                }
                return cadena;
            }
        }


        public static string obtenerEmpleado(int dpiEmpleado){
            String cadenaConexion = "server=127.0.0.1; database=almacen; Uid=root; pwd=felipemisterio;";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            String query = "CALL REGISTRO(" + dpiEmpleado + ",1110);";
            MySqlCommand comando = new MySqlCommand(query, conexion);
            MySqlDataReader lector = comando.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(lector);
            conexion.Close();

            if (tabla.Rows.Count == 0){
                return null;
            }
            else{
                String cadena = "";
                foreach (DataRow row in tabla.Rows){
                    foreach (DataColumn column in tabla.Columns){
                        cadena = cadena + row[column];
                    }
                }
                if (cadena.Equals("")){
                    return null;
                }
                return cadena;
            }   
        }

        public static string registroEmpleado(int dpiEmpleado, string nombre, string direccion, string telefono, string opcion){
            String cadenaConexion = "server=127.0.0.1; database=almacen; Uid=root; pwd=felipemisterio;";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            String query; 
                if(telefono.Equals("")){
                    query = "CALL REGISTROEMPLEADO("+dpiEmpleado+",'"+nombre+"','"+direccion+"','','"+opcion+"');";
                }
                else{
                    query = "CALL REGISTROEMPLEADO(" + dpiEmpleado + ",'" + nombre + "','" + direccion + "',"+telefono+",'" + opcion + "');";
                }
            MySqlCommand comando = new MySqlCommand(query, conexion);
            MySqlDataReader lector = comando.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(lector);
            conexion.Close();

            if (tabla.Rows.Count==0) {
                return null;
            }
            else{
                String cadena = "";
                foreach (DataRow row in tabla.Rows){
                    foreach (DataColumn column in tabla.Columns){
                        cadena = cadena + row[column];
                    }
                }
                if (cadena.Equals("")) {
                    return null;
                }
                return cadena;
            }
        }

        
        public static string obtenerProveedor(string nitProveedor){
            String cadenaConexion = "server=127.0.0.1; database=almacen; Uid=root; pwd=felipemisterio;";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            String query = "CALL REGISTROVARCHAR('" + nitProveedor + "',1101);";
            MySqlCommand comando = new MySqlCommand(query, conexion);
            MySqlDataReader lector = comando.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(lector);
            conexion.Close();

            if (tabla.Rows.Count == 0){
                return null;
            }
            else{
                String cadena = "";
                foreach (DataRow row in tabla.Rows){
                    foreach (DataColumn column in tabla.Columns){
                        cadena = cadena + row[column];
                    }
                }
                if (cadena.Equals("")){
                    return null;
                }
                return cadena;
            }   
        }

        public static string registroProveedor(string nitProveedor, string nombre, string direccion, string telefono, string email, string opcion){
            String cadenaConexion = "server=127.0.0.1; database=almacen; Uid=root; pwd=felipemisterio;";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            String query; 
                if(telefono.Equals("")){
                    query = "CALL REGISTROPROVEEDOR('"+nitProveedor+"','"+nombre+"','"+direccion+"','','"+email+"','"+opcion+"');";
                }
                else{
                    query = "CALL REGISTROPROVEEDOR('" + nitProveedor + "','" + nombre + "','" + direccion + "',"+telefono+",'" + email + "','" + opcion + "');";
                }
            MySqlCommand comando = new MySqlCommand(query, conexion);
            MySqlDataReader lector = comando.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(lector);
            conexion.Close();

            if (tabla.Rows.Count==0) {
                return null;
            }
            else{
                String cadena = "";
                foreach (DataRow row in tabla.Rows){
                    foreach (DataColumn column in tabla.Columns){
                        cadena = cadena + row[column];
                    }
                }
                if (cadena.Equals("")) {
                    return null;
                }
                return cadena;
            }    
        }


        public static string obtenerCliente(string nitCliente){
            String cadenaConexion = "server=127.0.0.1; database=almacen; Uid=root; pwd=felipemisterio;";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            String query = "CALL REGISTROVARCHAR('" + nitCliente + "',1100);";
            MySqlCommand comando = new MySqlCommand(query, conexion);
            MySqlDataReader lector = comando.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(lector);
            conexion.Close();

            if (tabla.Rows.Count == 0){
                return null;
            }
            else{
                String cadena = "";
                foreach (DataRow row in tabla.Rows){
                    foreach (DataColumn column in tabla.Columns){
                        cadena = cadena + row[column];
                    }
                }
                if (cadena.Equals("")){
                    return null;
                }
                return cadena;
            }   
        }

        public static string registroCliente(string nitCliente, string nombre, string direccion, string telefono, string opcion){
            String cadenaConexion = "server=127.0.0.1; database=almacen; Uid=root; pwd=felipemisterio;";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            String query; 
                if(telefono.Equals("")){
                    query = "CALL REGISTROCLIENTE('"+nitCliente+"','"+nombre+"','"+direccion+"','','"+opcion+"');";
                }
                else{
                    query = "CALL REGISTROCLIENTE('" + nitCliente + "','" + nombre + "','" + direccion + "',"+telefono+",'" + opcion + "');";
                }
            MySqlCommand comando = new MySqlCommand(query, conexion);
            MySqlDataReader lector = comando.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(lector);
            conexion.Close();

            if (tabla.Rows.Count==0) {
                return null;
            }
            else{
                String cadena = "";
                foreach (DataRow row in tabla.Rows){
                    foreach (DataColumn column in tabla.Columns){
                        cadena = cadena + row[column];
                    }
                }
                if (cadena.Equals("")) {
                    return null;
                }
                return cadena;
            }    
        }


        public static string registroTipoGasto(string idTipoGasto, string nombre, string descripcion){
            String cadenaConexion = "server=127.0.0.1; database=almacen; Uid=root; pwd=felipemisterio;";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            String query = "CALL REGISTROTIPOGASTO("+idTipoGasto+",'"+nombre+"','"+descripcion+"');";
            MySqlCommand comando = new MySqlCommand(query, conexion);
            MySqlDataReader lector = comando.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(lector);
            conexion.Close();

            if (tabla.Rows.Count == 0){
                return null;
            }
            else{
                String cadena = "";
                foreach (DataRow row in tabla.Rows){
                    foreach (DataColumn column in tabla.Columns){
                        cadena = cadena + row[column];
                    }
                }
                if (cadena.Equals("")){
                    return null;
                }
                return cadena;
            }
        }


        public static string registroGasto(string idGasto, string fecha, string monto, string idTipoGasto, string dpiEmpleado){
            String cadenaConexion = "server=127.0.0.1; database=almacen; Uid=root; pwd=felipemisterio;";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            String query = "CALL REGISTROGASTO("+idGasto+",'"+fecha+"',"+monto+","+idTipoGasto+","+dpiEmpleado+");";
            MySqlCommand comando = new MySqlCommand(query, conexion);
            MySqlDataReader lector = comando.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(lector);
            conexion.Close();

            if (tabla.Rows.Count == 0){
                return null;
            }
            else{
                String cadena = "";
                foreach (DataRow row in tabla.Rows){
                    foreach (DataColumn column in tabla.Columns){
                        cadena = cadena + row[column];
                    }
                }
                if (cadena.Equals("")){
                    return null;
                }
                return cadena;
            }
        }

        
        public static string registroMerma(string idMerma, string unidades, string justificacion, string valor, string fecha, string idProducto){
            String cadenaConexion = "server=127.0.0.1; database=almacen; Uid=root; pwd=felipemisterio;";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            String query = "CALL REGISTROMERMA("+idMerma+","+unidades+",'"+justificacion+"',"+valor+",'"+fecha+"',"+idProducto+");";
            MySqlCommand comando = new MySqlCommand(query, conexion);
            MySqlDataReader lector = comando.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(lector);
            conexion.Close();

            if (tabla.Rows.Count == 0){
                return null;
            }
            else{
                String cadena = "";
                foreach (DataRow row in tabla.Rows){
                    foreach (DataColumn column in tabla.Columns){
                        cadena = cadena + row[column];
                    }
                }
                if (cadena.Equals("")){
                    return null;
                }
                return cadena;
            }
        }


        public static string registroVenta(List<string> valores){
            String cadenaConexion = "server=127.0.0.1; database=almacen; Uid=root; pwd=felipemisterio;";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            String query = "CALL REGISTROVENTA("+valores[0]+",'"+valores[1]+"','"+valores[2]+"',"+valores[3]+",'"+valores[4]+"');";
            MySqlCommand comando = new MySqlCommand(query, conexion);
            MySqlDataReader lector = comando.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(lector);
            conexion.Close();

            if (tabla.Rows.Count==0) {
                return null;
            }
            else{
                String cadena = "";
                foreach (DataRow row in tabla.Rows){
                    foreach (DataColumn column in tabla.Columns){
                        cadena = cadena + row[column];
                    }
                }
                if (cadena.Equals("")) {
                    return null;
                }
                return cadena;
            }
        }


        public static string registroDetalleVenta(string idDetalleVenta, string precio, string cantidad, string idVenta, string idProducto){
            String cadenaConexion = "server=127.0.0.1; database=almacen; Uid=root; pwd=felipemisterio;";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            String query = "CALL REGISTRODETALLEVENTA("+idDetalleVenta+","+precio+","+cantidad+","+idVenta+","+idProducto+");";
            MySqlCommand comando = new MySqlCommand(query, conexion);
            MySqlDataReader lector = comando.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(lector);
            conexion.Close();

            if (tabla.Rows.Count == 0){
                return null;
            }
            else{
                String cadena = "";
                foreach (DataRow row in tabla.Rows){
                    foreach (DataColumn column in tabla.Columns){
                        cadena = cadena + row[column];
                    }
                }
                if (cadena.Equals("")){
                    return null;
                }
                return cadena;
            }
        }

        
        public static string registroCompra(List<string> valores){
            String cadenaConexion = "server=127.0.0.1; database=almacen; Uid=root; pwd=felipemisterio;";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            String query = "CALL REGISTROCOMPRA("+valores[0]+",'"+valores[1]+"','"+valores[2]+"','"+valores[3]+"');";
            MySqlCommand comando = new MySqlCommand(query, conexion);
            MySqlDataReader lector = comando.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(lector);
            conexion.Close();

            if (tabla.Rows.Count==0) {
                return null;
            }
            else{
                String cadena = "";
                foreach (DataRow row in tabla.Rows){
                    foreach (DataColumn column in tabla.Columns){
                        cadena = cadena + row[column];
                    }
                }
                if (cadena.Equals("")) {
                    return null;
                }
                return cadena;
            }
        }


        public static string registroDetalleCompra(string idDetalleCompra, string precio, string cantidad, string idCompra, string idProducto){
            String cadenaConexion = "server=127.0.0.1; database=almacen; Uid=root; pwd=felipemisterio;";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            String query = "CALL REGISTRODETALLECOMPRA("+idDetalleCompra+","+precio+","+cantidad+","+idCompra+","+idProducto+");";
            MySqlCommand comando = new MySqlCommand(query, conexion);
            MySqlDataReader lector = comando.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(lector);
            conexion.Close();

            if (tabla.Rows.Count == 0){
                return null;
            }
            else{
                String cadena = "";
                foreach (DataRow row in tabla.Rows){
                    foreach (DataColumn column in tabla.Columns){
                        cadena = cadena + row[column];
                    }
                }
                if (cadena.Equals("")){
                    return null;
                }
                return cadena;
            }
        }


        public static DataTable getTableTiposGastos(){
            String cadenaConexion = "server=127.0.0.1; database=almacen; Uid=root; pwd=felipemisterio;";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            String query = "CALL LISTAREGISTROS(1);";
            MySqlCommand comando = new MySqlCommand(query, conexion);
            MySqlDataReader lector = comando.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(lector);
            conexion.Close();
            return tabla;
        }

        public static DataTable getTableEmpleados(){
            String cadenaConexion = "server=127.0.0.1; database=almacen; Uid=root; pwd=felipemisterio;";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            String query = "CALL LISTAREGISTROS(0);";
            MySqlCommand comando = new MySqlCommand(query, conexion);
            MySqlDataReader lector = comando.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(lector);
            conexion.Close();
            return tabla;
        }

        public static DataTable getTableCodigosProducto(){
            String cadenaConexion = "server=127.0.0.1; database=almacen; Uid=root; pwd=felipemisterio;";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            String query = "CALL LISTAREGISTROS(10);";
            MySqlCommand comando = new MySqlCommand(query, conexion);
            MySqlDataReader lector = comando.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(lector);
            conexion.Close();
            return tabla;
        }

        public static DataTable getTableNombresProducto(){
            String cadenaConexion = "server=127.0.0.1; database=almacen; Uid=root; pwd=felipemisterio;";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            String query = "CALL LISTAREGISTROS(11);";
            MySqlCommand comando = new MySqlCommand(query, conexion);
            MySqlDataReader lector = comando.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(lector);
            conexion.Close();
            return tabla;
        }

        public static DataTable getTableNitClientes(){
            String cadenaConexion = "server=127.0.0.1; database=almacen; Uid=root; pwd=felipemisterio;";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            String query = "CALL LISTAREGISTROS(100);";
            MySqlCommand comando = new MySqlCommand(query, conexion);
            MySqlDataReader lector = comando.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(lector);
            conexion.Close();
            return tabla;
        }

        public static DataTable getTableNombreEmpleados(){
            String cadenaConexion = "server=127.0.0.1; database=almacen; Uid=root; pwd=felipemisterio;";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            String query = "CALL LISTAREGISTROS(101);";
            MySqlCommand comando = new MySqlCommand(query, conexion);
            MySqlDataReader lector = comando.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(lector);
            conexion.Close();
            return tabla;
        }

        public static DataTable getTableNitProveedores(){
            String cadenaConexion = "server=127.0.0.1; database=almacen; Uid=root; pwd=felipemisterio;";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            String query = "CALL LISTAREGISTROS(110);";
            MySqlCommand comando = new MySqlCommand(query, conexion);
            MySqlDataReader lector = comando.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(lector);
            conexion.Close();
            return tabla;
        }

        public static DataTable getTableClientes(){
            String cadenaConexion = "server=127.0.0.1; database=almacen; Uid=root; pwd=felipemisterio;";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            String query = "CALL LISTAREGISTROS(1000);";
            MySqlCommand comando = new MySqlCommand(query, conexion);
            MySqlDataReader lector = comando.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(lector);
            conexion.Close();
            return tabla;
        }

        public static DataTable getTableProveedores(){
            String cadenaConexion = "server=127.0.0.1; database=almacen; Uid=root; pwd=felipemisterio;";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            String query = "CALL LISTAREGISTROS(1001);";
            MySqlCommand comando = new MySqlCommand(query, conexion);
            MySqlDataReader lector = comando.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(lector);
            conexion.Close();
            return tabla;
        }



        public static string getNombreEmpleado(int dpi){
            String cadenaConexion = "server=127.0.0.1; database=almacen; Uid=root; pwd=felipemisterio;";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            String query = "CALL REGISTRO(" + dpi + ",1010);";
            MySqlCommand comando = new MySqlCommand(query, conexion);
            MySqlDataReader lector = comando.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(lector);
            conexion.Close();

            if (tabla.Rows.Count == 0){
                return null;
            }
            else{
                String cadena = "";
                foreach (DataRow row in tabla.Rows){
                    foreach (DataColumn column in tabla.Columns){
                        cadena = cadena + row[column];
                    }
                }
                if (cadena.Equals("")){
                    return null;
                }
                return cadena;
            }   
        }

        public static string getNombreTipoGasto(int tipoGasto){
            String cadenaConexion = "server=127.0.0.1; database=almacen; Uid=root; pwd=felipemisterio;";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            String query = "CALL REGISTRO(" + tipoGasto + ",1011);";
            MySqlCommand comando = new MySqlCommand(query, conexion);
            MySqlDataReader lector = comando.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(lector);
            conexion.Close();

            if (tabla.Rows.Count == 0){
                return null;
            }
            else{
                String cadena = "";
                foreach (DataRow row in tabla.Rows){
                    foreach (DataColumn column in tabla.Columns){
                        cadena = cadena + row[column];
                    }
                }
                if (cadena.Equals("")){
                    return null;
                }
                return cadena;
            }   
        }      

        public static string getNombreProducto(int idProducto){
            String cadenaConexion = "server=127.0.0.1; database=almacen; Uid=root; pwd=felipemisterio;";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            String query = "CALL REGISTRO(" + idProducto + ",1001);";
            MySqlCommand comando = new MySqlCommand(query, conexion);
            MySqlDataReader lector = comando.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(lector);
            conexion.Close();

            if (tabla.Rows.Count == 0){
                return null;
            }
            else{
                String cadena = "";
                foreach (DataRow row in tabla.Rows){
                    foreach (DataColumn column in tabla.Columns){
                        cadena = cadena + row[column];
                    }
                }
                if (cadena.Equals("")){
                    return null;
                }
                return cadena;
            }
        }



        public static string getCodigoProducto(string nombreProducto){
            String cadenaConexion = "server=127.0.0.1; database=almacen; Uid=root; pwd=felipemisterio;";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            String query = "CALL REGISTROVARCHAR('" + nombreProducto + "',1000);";
            MySqlCommand comando = new MySqlCommand(query, conexion);
            MySqlDataReader lector = comando.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(lector);
            conexion.Close();

            if (tabla.Rows.Count == 0){
                return null;
            }
            else{
                String cadena = "";
                foreach (DataRow row in tabla.Rows){
                    foreach (DataColumn column in tabla.Columns){
                        cadena = cadena + row[column];
                    }
                }
                if (cadena.Equals("")){
                    return null;
                }
                return cadena;
            }    
        }

        public static string getNombreCliente(string nitCliente){
            String cadenaConexion = "server=127.0.0.1; database=almacen; Uid=root; pwd=felipemisterio;";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            String query = "CALL REGISTROVARCHAR('" + nitCliente + "',111);";
            MySqlCommand comando = new MySqlCommand(query, conexion);
            MySqlDataReader lector = comando.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(lector);
            conexion.Close();

            if (tabla.Rows.Count == 0){
                return null;
            }
            else{
                String cadena = "";
                foreach (DataRow row in tabla.Rows){
                    foreach (DataColumn column in tabla.Columns){
                        cadena = cadena + row[column];
                    }
                }
                if (cadena.Equals("")){
                    return null;
                }
                return cadena;
            }    
        }

        public static string getDpiEmpleado(string nombreEmpleado){
            String cadenaConexion = "server=127.0.0.1; database=almacen; Uid=root; pwd=felipemisterio;";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            String query = "CALL REGISTROVARCHAR('" + nombreEmpleado + "',110);";
            MySqlCommand comando = new MySqlCommand(query, conexion);
            MySqlDataReader lector = comando.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(lector);
            conexion.Close();

            if (tabla.Rows.Count == 0){
                return null;
            }
            else{
                String cadena = "";
                foreach (DataRow row in tabla.Rows){
                    foreach (DataColumn column in tabla.Columns){
                        cadena = cadena + row[column];
                    }
                }
                if (cadena.Equals("")){
                    return null;
                }
                return cadena;
            }   
        }

        public static string getNombreProveedor(string nitProveedor){
            String cadenaConexion = "server=127.0.0.1; database=almacen; Uid=root; pwd=felipemisterio;";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            String query = "CALL REGISTROVARCHAR('" + nitProveedor + "',101);";
            MySqlCommand comando = new MySqlCommand(query, conexion);
            MySqlDataReader lector = comando.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(lector);
            conexion.Close();

            if (tabla.Rows.Count == 0){
                return null;
            }
            else{
                String cadena = "";
                foreach (DataRow row in tabla.Rows){
                    foreach (DataColumn column in tabla.Columns){
                        cadena = cadena + row[column];
                    }
                }
                if (cadena.Equals("")){
                    return null;
                }
                return cadena;
            }
        }

        public static string getNitCliente(string nombre){
            String cadenaConexion = "server=127.0.0.1; database=almacen; Uid=root; pwd=felipemisterio;";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            String query = "CALL REGISTROVARCHAR('" + nombre + "',100);";
            MySqlCommand comando = new MySqlCommand(query, conexion);
            MySqlDataReader lector = comando.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(lector);
            conexion.Close();

            if (tabla.Rows.Count == 0){
                return null;
            }
            else{
                String cadena = "";
                foreach (DataRow row in tabla.Rows){
                    foreach (DataColumn column in tabla.Columns){
                        cadena = cadena + row[column];
                    }
                }
                if (cadena.Equals("")){
                    return null;
                }
                return cadena;
            }
        }

        public static string getNitProveedor(string nombre){
            String cadenaConexion = "server=127.0.0.1; database=almacen; Uid=root; pwd=felipemisterio;";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            String query = "CALL REGISTROVARCHAR('" + nombre + "',11);";
            MySqlCommand comando = new MySqlCommand(query, conexion);
            MySqlDataReader lector = comando.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(lector);
            conexion.Close();

            if (tabla.Rows.Count == 0){
                return null;
            }
            else{
                String cadena = "";
                foreach (DataRow row in tabla.Rows){
                    foreach (DataColumn column in tabla.Columns){
                        cadena = cadena + row[column];
                    }
                }
                if (cadena.Equals("")){
                    return null;
                }
                return cadena;
            }
        }



        public static string ingresarCuenta(string nickName, string password, string correo){
            String cadenaConexion = "server=127.0.0.1; database=almacen; Uid=root; pwd=felipemisterio;";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            String query = "CALL INSERTARUSUARIO('"+nickName+"','"+password+"','"+correo+"');";
            MySqlCommand comando = new MySqlCommand(query, conexion);
            MySqlDataReader lector = comando.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(lector);
            conexion.Close();

            if (tabla.Rows.Count == 0){
                return null;
            }
            else{
                String cadena = "";
                foreach (DataRow row in tabla.Rows){
                    foreach (DataColumn column in tabla.Columns){
                        cadena = cadena + row[column];
                    }
                }
                if (cadena.Equals("")){
                    return null;
                }
                return cadena;
            }
        }

        public static DataTable getTableCuentas(){
            String cadenaConexion = "server=127.0.0.1; database=almacen; Uid=root; pwd=felipemisterio;";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            String query = "CALL LISTAREGISTROS(111);";
            MySqlCommand comando = new MySqlCommand(query, conexion);
            MySqlDataReader lector = comando.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(lector);
            conexion.Close();
            return tabla;
        }

        public static string eliminarCuenta(string nickName){
            String cadenaConexion = "server=127.0.0.1; database=almacen; Uid=root; pwd=felipemisterio;";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            String query = "CALL ELIMINARUSUARIO('"+nickName+"');";
            MySqlCommand comando = new MySqlCommand(query, conexion);
            MySqlDataReader lector = comando.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(lector);
            conexion.Close();

            if (tabla.Rows.Count == 0){
                return null;
            }
            else{
                String cadena = "";
                foreach (DataRow row in tabla.Rows){
                    foreach (DataColumn column in tabla.Columns){
                        cadena = cadena + row[column];
                    }
                }
                if (cadena.Equals("")){
                    return null;
                }
                return cadena;
            }
        }

        public static string logearse(string nickName, string password){
            String cadenaConexion = "server=127.0.0.1; database=almacen; Uid=root; pwd=felipemisterio;";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            String query = "SELECT COMPROBARLOGIN('"+nickName+"','"+password+"');";
            MySqlCommand comando = new MySqlCommand(query, conexion);
            MySqlDataReader lector = comando.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(lector);
            conexion.Close();
            if (tabla.Rows.Count == 0){
                return null;
            }
            else{
                String cadena = "";
                foreach (DataRow row in tabla.Rows){
                    foreach (DataColumn column in tabla.Columns){
                        cadena = cadena + row[column];
                    }
                }
                if (cadena.Equals("")){
                    return null;
                }
                return cadena;
            }
        }







        

       
    }
}