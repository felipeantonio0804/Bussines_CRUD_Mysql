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
    public partial class producto : System.Web.UI.Page{
        protected void Page_Load(object sender, EventArgs e){
            if(!IsPostBack){
                rellenarDropDownList();
            }
        }
        private void rellenarDropDownList(){
            listaNombreEmpleado.Items.Clear();
            DataTable tablaEmpleados = Controladora.getTableNombreEmpleados();
            listaNombreEmpleado.DataSource = tablaEmpleados;
            listaNombreEmpleado.DataTextField = "NOMBRE";
            listaNombreEmpleado.DataValueField = "NOMBRE";
            listaNombreEmpleado.DataBind();
        }
        protected void listaNombreEmpleado_SelectedIndexChanged(object sender, EventArgs e){
            if(txtDpi.Enabled){
                string nombre = listaNombreEmpleado.SelectedValue;
                string nit = Controladora.getDpiEmpleado(nombre);
                txtDpi.Text = nit;
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
                txtDpi.Enabled = true;
                txtNombre.Enabled = true ;
                txtDireccion.Enabled = true;
                txtTelefono.Enabled = true;
            }
            else if (rbModificar.Checked){
                cargarDatos.Enabled = true;
                txtDpi.Enabled = true;
                txtNombre.Enabled = false;
                txtDireccion.Enabled = false;
                txtTelefono.Enabled = false;
            }
            else if (rbEliminar.Checked){
                cargarDatos.Enabled = true;
                txtDpi.Enabled = true;
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
            int dpiEmpleado;
            try{
                dpiEmpleado = int.Parse(txtDpi.Text);
                String resultado = Controladora.obtenerEmpleado(dpiEmpleado);
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
                txtDpi.Enabled = false;
                txtNombre.Enabled = true;
                txtDireccion.Enabled = true;
                txtTelefono.Enabled = true;
            }
            else if (rbEliminar.Checked){
                cargarDatos.Enabled = true;
                txtDpi.Enabled = true;
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
                    int dpiEmpleado;
                    try{
                        dpiEmpleado = int.Parse(txtDpi.Text);
                    }
                    catch(Exception ex){
                        mostrar("DEBE ESCRIBIR EL DPI DE FORMA NUMERICA");
                        return;
                    }
                    String nombre = txtNombre.Text;
                    if (nombre.Equals("")) {
                        mostrar("DEBE ESCRIBIR EL NOMBRE");
                        return;
                    }
                    String direccion = txtDireccion.Text;
                    if (direccion.Equals("")) {
                        mostrar("DEBE ESCRIBIR LA DIRECCION");
                        return;
                    }
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
                    String resultado = Controladora.registroEmpleado(dpiEmpleado,nombre,direccion,telefono,opcion);
                    mostrar2(resultado);
                    limpiarCampos();
                    rellenarDropDownList();
                }
                else if (rbModificar.Checked){
                    int dpiEmpleado;
                    try{
                        dpiEmpleado = int.Parse(txtDpi.Text);
                    }
                    catch(Exception ex){
                        mostrar("DEBE ESCRIBIR EL DPI DE FORMA NUMERICA");
                        return;
                    }
                    String nombre = txtNombre.Text;
                    if (nombre.Equals("")) {
                        mostrar("DEBE ESCRIBIR EL NOMBRE");
                        return;
                    }
                    String direccion = txtDireccion.Text;
                    if (direccion.Equals("")) {
                        mostrar("DEBE ESCRIBIR LA DIRECCION");
                        return;
                    }
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
                    String resultado = Controladora.registroEmpleado(dpiEmpleado,nombre,direccion,telefono,opcion);
                    mostrar2(resultado);
                    limpiarCampos();
                    rellenarDropDownList();
                }
                else if (rbEliminar.Checked){
                    try{
                        int dpiEmpleado = int.Parse(txtDpi.Text);
                        String opcion = "001";
                        String resultado = Controladora.registroEmpleado(dpiEmpleado, "", "", "", opcion);
                        mostrar2(resultado);
                        limpiarCampos();
                        rellenarDropDownList();
                    }
                    catch(Exception ex){
                        mostrar("DEBE ESCRIBIR EL DPI DE FORMA NUMERICA");
                        return;
                    }
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
            txtDpi.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
        }

       
       

        
    }
}