using ARSA.clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ARSA.paginas_finales
{
    public partial class venta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e){
            if (!IsPostBack) {
                agregarFilaInicial();
                rellenarDropDownList();
                consultaDeSeleccionDropDownList();
            }
        }
        private void agregarFilaInicial(){
            DataTable tabla = new DataTable();
            DataRow fila = null;
            tabla.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            tabla.Columns.Add(new DataColumn("precio", typeof(string)));
            tabla.Columns.Add(new DataColumn("cantidad", typeof(string)));
            tabla.Columns.Add(new DataColumn("idProducto", typeof(string)));
            fila = tabla.NewRow();
            fila["RowNumber"] = 1;
            fila["precio"] = string.Empty;
            fila["cantidad"] = string.Empty;
            fila["idProducto"] = string.Empty;
            tabla.Rows.Add(fila);
            ViewState["CurrentTable"] = tabla;
            Grid.Columns[0].HeaderText = "ID";
            Grid.Columns[1].HeaderText = "PRECIO";
            Grid.Columns[2].HeaderText = "CANTIDAD";
            Grid.Columns[3].HeaderText = "ID PRODUCTO";
            string resultado = Divisora.getCadena((DataTable)ViewState["CurrentTable"]);
            Grid.DataSource = tabla;
            Grid.DataBind();
        }
        protected void agregarDetalle_Click(object sender, EventArgs e){
            agregarNuevaFila();
        }
        private void agregarNuevaFila(){
            int indiceFila = 0;
            if (ViewState["CurrentTable"] != null){
                DataTable tabla = (DataTable)ViewState["CurrentTable"];
                DataRow fila = null;
                if (tabla.Rows.Count > 0){
                    for (int i = 1; i <= tabla.Rows.Count; i++){
                        TextBox box1 = (TextBox)Grid.Rows[indiceFila].Cells[1].FindControl("TextBox1");
                        TextBox box2 = (TextBox)Grid.Rows[indiceFila].Cells[2].FindControl("TextBox2");
                        TextBox box3 = (TextBox)Grid.Rows[indiceFila].Cells[3].FindControl("TextBox3");

                        fila = tabla.NewRow();
                        fila["RowNumber"] = i + 1;
                        tabla.Rows[i - 1]["precio"] = box1.Text;
                        tabla.Rows[i - 1]["cantidad"] = box2.Text;
                        tabla.Rows[i - 1]["idProducto"] = box3.Text;

                        indiceFila++;
                    }
                    tabla.Rows.Add(fila);
                    ViewState["CurrentTable"] = tabla;
                    String resultado = Divisora.getCadena((DataTable)ViewState["CurrentTable"]);
                    Grid.DataSource = tabla;
                    Grid.DataBind();
                }
            }
            else{
                Response.Write("ViewState is null");
            }
            setDatosPrevios();
        }
        private void setDatosPrevios(){
            int indiceFila = 0;
            if (ViewState["CurrentTable"] != null){
                DataTable tabla = (DataTable)ViewState["CurrentTable"];
                if (tabla.Rows.Count > 0){
                    for (int i = 0; i < tabla.Rows.Count; i++){
                        TextBox box1 = (TextBox)Grid.Rows[indiceFila].Cells[1].FindControl("TextBox1");
                        TextBox box2 = (TextBox)Grid.Rows[indiceFila].Cells[2].FindControl("TextBox2");
                        TextBox box3 = (TextBox)Grid.Rows[indiceFila].Cells[3].FindControl("TextBox3");

                        box1.Text = tabla.Rows[i]["precio"].ToString();
                        box2.Text = tabla.Rows[i]["cantidad"].ToString();
                        box3.Text = tabla.Rows[i]["idProducto"].ToString();

                        indiceFila++;
                    }
                }
            }
        }
     

        protected string formatoParentesisDataTable(){
            String resultado = Divisora.getCadena((DataTable)ViewState["CurrentTable"]);
            return resultado;
        }


        protected void listaSeleccion_SelectedIndexChanged(object sender, EventArgs e){
            consultaDeSeleccionDropDownList();
        }
        private void rellenarDropDownList(){
            listaNombreProducto.Items.Clear();
            DataTable tablaNombreProducto = Controladora.getTableNombresProducto();
            listaNombreProducto.DataSource = tablaNombreProducto;
            listaNombreProducto.DataTextField = "NOMBRE";
            listaNombreProducto.DataValueField = "NOMBRE";
            listaNombreProducto.DataBind();

            listaNitClientes.Items.Clear();
            DataTable tablaNitClientes = Controladora.getTableNitClientes();
            listaNitClientes.DataSource = tablaNitClientes;
            listaNitClientes.DataTextField = "NIT";
            listaNitClientes.DataValueField = "NIT";
            listaNitClientes.DataBind();

            listaNombresEmpleados.Items.Clear();
            DataTable tablaNombreEmpleados = Controladora.getTableNombreEmpleados();
            listaNombresEmpleados.DataSource = tablaNombreEmpleados;
            listaNombresEmpleados.DataTextField = "NOMBRE";
            listaNombresEmpleados.DataValueField = "NOMBRE";
            listaNombresEmpleados.DataBind();
        }
        private void consultaDeSeleccionDropDownList(){
            string nombreProducto = listaNombreProducto.SelectedValue;
            string codigo = Controladora.getCodigoProducto(nombreProducto);
            lblResultadoCodigo.Text = codigo;

            string nitCliente = listaNitClientes.SelectedValue;
            string nombreCliente = Controladora.getNombreCliente(nitCliente);
            lblNombreCliente.Text = nombreCliente;

            string nombreEmpleado = listaNombresEmpleados.SelectedValue;
            string dpiEmpleado = Controladora.getDpiEmpleado(nombreEmpleado);
            lblCodigoVendedor.Text = dpiEmpleado;
        }


        bool banderaVenta = false;
        bool banderaDetalleVenta = true;
        string cadenaErrores = "";
        protected void guardar_Click(object sender, EventArgs e){
            validarCamposVenta();
            if(banderaVenta){
                validarCamposDetalleVenta();
                if (banderaDetalleVenta) {
                    String resultadoIngresoVenta = Controladora.registroVenta(valoresCamposVenta());
                    if (!resultadoIngresoVenta.Contains("YA ESTA REGISTRADA")) {
                        //INGRESAR LOS DETALLES
                        DataTable tabla = (DataTable)ViewState["CurrentTable"];
                        if (tabla.Rows.Count > 0){
                            String resultado = "";
                            for (int i = 0; i < tabla.Rows.Count - 1; i++){
                                DataRow fila = tabla.Rows[i];
                                resultado = resultado + realizarEnvioDetalleVenta(tabla,fila)+"<br>";
                            }
                            resultado = resultadoIngresoVenta + "<br>" + resultado;
                            mostrar3(resultado);
                            limpiarCampos();
                        }
                    }
                    else{
                        mostrar2(resultadoIngresoVenta);
                    }                    
                }
                else{
                    mostrar(cadenaErrores);
                }
            }
        }
        private void validarCamposVenta(){
            banderaVenta = false;
            String idVenta;
            try{
                idVenta = (int.Parse(txtIdVenta.Text)).ToString();
            }
            catch (Exception ex){
                mostrar("DEBE ESCRIBIR EL ID DE FORMA NUMERICA");
                return;
            }
            String fecha;
            if(calendario.SelectedDate.Year == 0001 && calendario.SelectedDate.Month == 01 && calendario.SelectedDate.Day==01){
                mostrar("DEBE SELECCIONAR FECHA");
                return;
            }
            else{
                fecha  = calendario.SelectedDate.Year + "/" + calendario.SelectedDate.Month + "/" + calendario.SelectedDate.Day;
            }
            String descripcion = txtDescripcion.Text;           
            String dpiVendedor = lblCodigoVendedor.Text;
            String nitCliente = listaNitClientes.SelectedValue;
            banderaVenta = true;
        }
        private void validarCamposDetalleVenta(){
            cadenaErrores = "";
            banderaDetalleVenta = true;
            DataTable tabla = (DataTable)ViewState["CurrentTable"];
            String resultado = Divisora.getCadena((DataTable)ViewState["CurrentTable"]);
            if (tabla.Rows.Count > 0){
                for (int i = 0; i < tabla.Rows.Count-1; i++){
                    DataRow fila = tabla.Rows[i];
                    verificarFila(tabla,fila,i);
                }
            }
        }
        private void verificarFila(DataTable tabla,DataRow fila,int numeroFila){
            int contador = 0;
            if (fila[1].ToString().Equals("") && fila[2].ToString().Equals("") && fila[3].ToString().Equals("")) {
                cadenaErrores = cadenaErrores + "WARNING: FILA: "+numeroFila+" NO ENTRARON EN LOS DETALLES. <br>";
            }
            else{
                foreach (DataColumn columna in tabla.Columns){
                    if(contador==0){
                        validarEntero(fila[columna].ToString(), numeroFila, contador);
                    }
                    else if(contador==1){
                        validarDoble(fila[columna].ToString(), numeroFila, contador);
                    }
                    else if(contador==2){
                        validarEntero(fila[columna].ToString(), numeroFila, contador);
                    }
                    else if(contador==3){
                        validarEntero(fila[columna].ToString(), numeroFila, contador);
                    }
                    contador++;
                }
            }
        }
        private void validarDoble(string numerico, int numeroFila, int numeroColumna){
            try {
                double.Parse(numerico);
            }
            catch(Exception e){
                cadenaErrores = cadenaErrores + "PRECIO NO NUMERICO: " + numerico + " FILA: " + (numeroFila + 1) + ", COLUMNA: " + (numeroColumna + 1) + ".<br>";
                banderaDetalleVenta = false;
            }
        }
        private void validarEntero(string numerico, int numeroFila, int numeroColumna){
            try {
                int.Parse(numerico);
            }
            catch(Exception e){
                if(numeroColumna==0){
                    cadenaErrores = cadenaErrores + "ID NO NUMERICO: "+numerico+" FILA: " + (numeroFila + 1) + ", COLUMNA: " + (numeroColumna + 1) + ".<br>";
                }
                else if(numeroColumna==2){
                    cadenaErrores = cadenaErrores + "CANTIDAD NO NUMERICA: " + numerico + " FILA: " + (numeroFila + 1) + ", COLUMNA: " + (numeroColumna + 1) + ".<br>";
                }
                else if(numeroColumna==3){
                    cadenaErrores = cadenaErrores + "ID PRODUCTO NO NUMERICO: " + numerico + " FILA: " + (numeroFila + 1) + ", COLUMNA: " + (numeroColumna + 1) + ".<br>";
                }
                banderaDetalleVenta = false;
            }
        }
        private List<String> valoresCamposVenta(){
            List<String> valores = new List<String>();
            valores.Add(txtIdVenta.Text);
            valores.Add(calendario.SelectedDate.Year + "/" + calendario.SelectedDate.Month + "/" + calendario.SelectedDate.Day);
            valores.Add(txtDescripcion.Text);           
            valores.Add(lblCodigoVendedor.Text);
            valores.Add(listaNitClientes.SelectedValue);
            return valores;
        }
        private string realizarEnvioDetalleVenta(DataTable tabla, DataRow fila) {
            string idDetalleVenta = fila[tabla.Columns[0]].ToString();
            string precio = fila[tabla.Columns[1]].ToString();
            string cantidad = fila[tabla.Columns[2]].ToString();
            string idVenta = txtIdVenta.Text;
            string idProducto = fila[tabla.Columns[3]].ToString();
            return Controladora.registroDetalleVenta(idDetalleVenta, precio, cantidad, idVenta, idProducto);
        }

        private void mostrar(string mensaje){
            lblInformacion.Text = mensaje;
        }
        private void mostrar2(string mensaje){
            this.Page.Response.Write("<script language='JavaScript'>window.alert('"+mensaje+"');</script>");
            lblInformacion.Text = mensaje;
        }
        private void mostrar3(string mensaje){
            this.Page.Response.Write("<script language='JavaScript'>window.alert('FACTURA INGRESO SATISFACTORIAMENTE, MIRE LA INFORMACION');</script>");
            lblInformacion.Text = mensaje;
        }
        private void limpiarCampos() {
            txtIdVenta.Text = "";
            txtDescripcion.Text = "";
            agregarFilaInicial();
        }

        
    }
}