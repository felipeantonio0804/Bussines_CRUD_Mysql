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
    public partial class cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e){
            if(!IsPostBack){
                rellenarDropDownList();
            }
        }
        private void rellenarDropDownList(){
            listaNombreCliente.Items.Clear();
            DataTable tablaClientes = Controladora.getTableClientes();
            listaNombreCliente.DataSource = tablaClientes;
            listaNombreCliente.DataTextField = "NOMBRE";
            listaNombreCliente.DataValueField = "NOMBRE";
            listaNombreCliente.DataBind();
        }
        protected void listaNombreCliente_SelectedIndexChanged(object sender, EventArgs e){
            if(txtNit.Enabled){
                string nombre = listaNombreCliente.SelectedValue;
                string nit = Controladora.getNitCliente(nombre);
                txtNit.Text = nit;
            }
        }

        protected void rbCrear_CheckedChanged(object sender, EventArgs e){
            habilitarCamposPorOpcion();
        }
        protected void rbModificar_CheckedChanged(object sender, EventArgs e){
            habilitarCamposPorOpcion();
        }
        protected void rbEliminar_CheckedChanged(object sender, EventArgs e){
            habilitarCamposPorOpcion();
        }
        private void habilitarCamposPorOpcion(){
            if (rbCrear.Checked){
                cargarDatos.Enabled = false;
                txtNit.Enabled = true;
                txtNombre.Enabled = true ;
                txtDireccion.Enabled = true;
                txtTelefono.Enabled = true;
            }
            else if (rbModificar.Checked){
                cargarDatos.Enabled = true;
                txtNit.Enabled = true;
                txtNombre.Enabled = false;
                txtDireccion.Enabled = false;
                txtTelefono.Enabled = false;
            }
            else if (rbEliminar.Checked){
                cargarDatos.Enabled = true;
                txtNit.Enabled = true;
                txtNombre.Enabled = false;
                txtDireccion.Enabled = false;
                txtTelefono.Enabled = false;
            }
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            lblInformacion.Text = "";
        }

        protected void cargarDatos_Click(object sender, EventArgs e){//cargar los datos al querer modificar  
            string nitCliente;
            try{
                nitCliente = txtNit.Text;
                String resultado = Controladora.obtenerCliente(nitCliente);
                if (resultado != null){
                    habilitarCamposCargarDatos();
                    plasmarDatos(resultado);
                }
                else{
                    mostrar("NO EXISTE EL REGISTRO");
                }
            }
            catch(Exception ex){
                mostrar(ex.ToString());
            }
        }
        private void habilitarCamposCargarDatos(){
            if (rbModificar.Checked){
                cargarDatos.Enabled = false;
                txtNit.Enabled = false;
                txtNombre.Enabled = true;
                txtDireccion.Enabled = true;
                txtTelefono.Enabled = true;
            }
            else if (rbEliminar.Checked){
                cargarDatos.Enabled = true;
                txtNit.Enabled = true;
                txtNombre.Enabled = false;
                txtDireccion.Enabled = false;
                txtTelefono.Enabled = false;
            }
        }
        private void plasmarDatos(String resultado){
            List<String> palabras = Divisora.getListado(resultado);
            txtNombre.Text = palabras[2];
            txtDireccion.Text = palabras[3];
            if (palabras[4].Equals("0")) {
                txtTelefono.Text = "";
            }
            else{
                txtTelefono.Text = palabras[4];
            }
        }

        protected void guardar_Click(object sender, EventArgs e){
            try{
                if (rbCrear.Checked){
                    String nitProveedor = txtNit.Text;
                    if (nitProveedor.Equals("")) {
                        mostrar("DEBE INGRESAR EL NIT");
                        return;
                    }
                    String nombre = txtNombre.Text;
                    String direccion = txtDireccion.Text;
                    String telefono;
                    try{
                        telefono = (int.Parse(txtTelefono.Text)).ToString();
                        if (telefono.Length != 8) {
                            mostrar("DEBEN SER 8 DIGITOS DEL TELEFONO");
                            return;
                        }
                    }
                    catch(Exception ex){
                        if (txtTelefono.Text.Equals("")) {
                            telefono = "";
                        }
                        else{
                            mostrar("DEBE ESCRIBIR EL TELEFONO EN FORMA NUMERICA");
                            return;
                        }
                    }
                    String opcion = "100";
                    String resultado = Controladora.registroCliente(nitProveedor,nombre,direccion,telefono,opcion);
                    mostrar2(resultado);
                    limpiarCampos();
                    rellenarDropDownList();
                }
                else if (rbModificar.Checked){
                    String nitProveedor = txtNit.Text;
                    if (nitProveedor.Equals("")) {
                        mostrar("DEBE INGRESAR EL NIT");
                        return;
                    }
                    String nombre = txtNombre.Text;
                    String direccion = txtDireccion.Text;
                    String telefono;
                    try{
                        telefono = (int.Parse(txtTelefono.Text)).ToString();
                        if (telefono.Length != 8) {
                            mostrar("DEBEN SER 8 DIGITOS DEL TELEFONO");
                            return;
                        }
                    }
                    catch(Exception ex){
                        if (txtTelefono.Text.Equals("")) {
                            telefono = "";
                        }
                        else{
                            mostrar("DEBE ESCRIBIR EL TELEFONO EN FORMA NUMERICA");
                            return;
                        }
                    }                   
                    String opcion = "010";
                    String resultado = Controladora.registroCliente(nitProveedor,nombre,direccion,telefono,opcion);
                    mostrar2(resultado);
                    limpiarCampos();
                    rellenarDropDownList();
                }
                else if (rbEliminar.Checked){
                    String nitProveedor = txtNit.Text;
                    if (nitProveedor.Equals("")) {
                        mostrar("DEBE INGRESAR EL NIT");
                        return;
                    }
                    String opcion = "001";
                    String resultado = Controladora.registroCliente(nitProveedor,"","","",opcion);
                    mostrar2(resultado);
                    limpiarCampos();
                    rellenarDropDownList();
                }
                else{
                    mostrar("DEBE SELECCIONAR UNA OPCION");
                    return;
                }
            }
            catch(Exception ex){
                mostrar2(ex.ToString());
            }
        }

        private void mostrar(string mensaje){
            lblInformacion.Text = mensaje;
        }
        private void mostrar2(string mensaje){
            this.Page.Response.Write("<script language='JavaScript'>window.alert('"+mensaje+"');</script>");
            lblInformacion.Text = mensaje;
        }
        private void limpiarCampos() {
            txtNit.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
        }


        
       
    }
}