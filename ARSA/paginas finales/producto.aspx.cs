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
    public partial class empleado : System.Web.UI.Page
    {
        private String carpetaImagen = "~/imagenesCargadas/";

        protected void Page_Load(object sender, EventArgs e){
            if(!IsPostBack){
                rellenarDropDownList();
            }
        }
        private void rellenarDropDownList(){
            listaNombreProducto.Items.Clear();
            DataTable tablaProductos = Controladora.getTableNombresProducto();
            listaNombreProducto.DataSource = tablaProductos;
            listaNombreProducto.DataTextField = "NOMBRE";
            listaNombreProducto.DataValueField = "NOMBRE";
            listaNombreProducto.DataBind();
        }
        protected void listaNombreProducto_SelectedIndexChanged(object sender, EventArgs e){
            if(txtCodigoProducto.Enabled){
                string nombre = listaNombreProducto.SelectedValue;
                string nit = Controladora.getCodigoProducto(nombre);
                txtCodigoProducto.Text = nit;
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
                txtCodigoProducto.Enabled = true;
                txtNombre.Enabled = true ;
                txtDescripcion.Enabled = true;
                cargarImagen.Enabled = true;
                cargarImagen2.Enabled = true;
            }
            else if (rbModificar.Checked){
                cargarDatos.Enabled = true;
                txtCodigoProducto.Enabled = true;
                txtNombre.Enabled = false;
                txtDescripcion.Enabled = false;
                cargarImagen.Enabled = false;
                cargarImagen2.Enabled = false;
            }
            else if (rbEliminar.Checked){
                cargarDatos.Enabled = true;
                txtCodigoProducto.Enabled = true;
                txtNombre.Enabled = false;
                txtDescripcion.Enabled = false;
                cargarImagen.Enabled = false;
                cargarImagen2.Enabled = false;
            }
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            lblInformacion.Text = "";
            imagenGrafica.ImageUrl = carpetaImagen;
            Estatica.archivoImagen = "";
        }

        protected void cargarDatos_Click(object sender, EventArgs e){//cargar los datos al querer modificar  
            int idProducto;
            try{
                idProducto = int.Parse(txtCodigoProducto.Text);
                String resultado = Controladora.obtenerProducto(idProducto);
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
                txtCodigoProducto.Enabled = false;
                txtNombre.Enabled = true;
                txtDescripcion.Enabled = true;
                cargarImagen.Enabled = true;
                cargarImagen2.Enabled = true;
            }
            else if (rbEliminar.Checked){
                cargarDatos.Enabled = true;
                txtCodigoProducto.Enabled = true;
                txtNombre.Enabled = false;
                txtDescripcion.Enabled = false;
                cargarImagen.Enabled = false;
                cargarImagen2.Enabled = false;
            }
        }
        private void plasmarDatos(String resultado){
            List<String> palabras = Divisora.getListado(resultado);
            txtNombre.Text = palabras[2];
            txtDescripcion.Text = palabras[3];
            imagenGrafica.ImageUrl = carpetaImagen+palabras[4];
        }

        protected void cargarImagen2_Click(object sender, EventArgs e){
            Estatica.archivoImagen = "";
            Boolean fileOK = false;
            String path = Server.MapPath(carpetaImagen);
            if (cargarImagen.HasFile){
                String fileExtension = System.IO.Path.GetExtension(cargarImagen.FileName).ToLower();
                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
                for (int i = 0; i < allowedExtensions.Length; i++){
                    if (fileExtension == allowedExtensions[i]){
                        fileOK = true;
                    }
                }
            }
            if (fileOK) {
                try{
                    cargarImagen.PostedFile.SaveAs(path + cargarImagen.FileName);
                    pintarImagen();
                }
                catch (Exception ex){
                    mostrar("ARCHIVO NO PUEDE SER CARGADO");
                }
            }
            else{
                mostrar("NO SE ACEPTAN ARCHIVOS DE ESTE FORMATO");
            }
        }
        private void pintarImagen(){
            imagenGrafica.ImageUrl = carpetaImagen + cargarImagen.FileName;
            Estatica.archivoImagen = cargarImagen.FileName;
            //mostrar(carpetaImagen + cargarImagen.FileName);  
        }   

        protected void guardar_Click(object sender, EventArgs e){
            try{
                if (rbCrear.Checked){
                    try{
                        int idProducto = int.Parse(txtCodigoProducto.Text);
                        String nombre = txtNombre.Text;
                        if (nombre.Equals("")) {
                            mostrar("DEBE ESCRIBIR EL NOMBRE");
                            return;
                        }
                        String descripcion = txtDescripcion.Text;
                        String archivoImagen = Estatica.archivoImagen;
                        String opcion = "100";
                        String resultado = Controladora.registroProducto(idProducto, nombre, descripcion, archivoImagen, opcion);
                        mostrar2(resultado);
                        limpiarCampos();
                        rellenarDropDownList();
                    }
                    catch(Exception ex){
                        mostrar("DEBE ESCRIBIR EL CODIGO DE FORMA NUMERICA");
                    }
                }
                else if (rbModificar.Checked){
                    try{
                        int idProducto = int.Parse(txtCodigoProducto.Text);
                        String nombre = txtNombre.Text;
                        if (nombre.Equals("")) {
                            mostrar("DEBE ESCRIBIR EL NOMBRE");
                            return;
                        }
                        String descripcion = txtDescripcion.Text;
                        String archivoImagen = Estatica.archivoImagen;
                        String opcion = "010";
                        String resultado = Controladora.registroProducto(idProducto, nombre, descripcion, archivoImagen, opcion);
                        mostrar2(resultado);
                        limpiarCampos();
                        rellenarDropDownList();
                    }
                    catch(Exception ex){
                        mostrar("DEBE ESCRIBIR EL CODIGO");
                    }
                }
                else if (rbEliminar.Checked){
                    try{
                        int idProducto = int.Parse(txtCodigoProducto.Text);
                        String opcion = "001";
                        String resultado = Controladora.registroProducto(idProducto,"","","",opcion);
                        mostrar2(resultado);
                        limpiarCampos();
                        rellenarDropDownList();
                    }
                    catch(Exception ex){
                        mostrar("DEBE ESCRIBIR EL CODIGO");
                    }
                }
                else{
                    mostrar("DEBE SELECCIONAR UNA OPCION");
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
            txtCodigoProducto.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            imagenGrafica.ImageUrl = carpetaImagen;
        }

        
 
    }
}