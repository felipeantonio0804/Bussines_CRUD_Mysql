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
    public partial class gasto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e){
            if (!IsPostBack) { 
                //rellenar los dropdowlist
                rellenarDropDownList();
                plasmarNombreEmpleado();
                plasmarNombreTipoGasto();
            }
        }
        private void rellenarDropDownList(){
            listaTipos.Items.Clear();
            listaEmpleados.Items.Clear();
            DataTable tablaTipos = Controladora.getTableTiposGastos();
            DataTable tablaEmpleados = Controladora.getTableEmpleados();

            listaTipos.DataSource = tablaTipos;
            listaEmpleados.DataSource = tablaEmpleados;
            listaTipos.DataTextField = "IDTIPO_GASTO";
            listaTipos.DataValueField = "IDTIPO_GASTO";
            listaEmpleados.DataTextField = "DPI";
            listaEmpleados.DataValueField = "DPI";
            listaTipos.DataBind();
            listaEmpleados.DataBind();
        }
        protected void listaTipos_SelectedIndexChanged(object sender, EventArgs e){
            plasmarNombreTipoGasto();
        }
        protected void listaEmpleados_SelectedIndexChanged(object sender, EventArgs e){
            plasmarNombreEmpleado();
        }
        private void plasmarNombreTipoGasto(){
            int tipoGasto = int.Parse(listaTipos.SelectedValue);
            String nombre = Controladora.getNombreTipoGasto(tipoGasto);
            lblTipo.Text = nombre;
        }
        private void plasmarNombreEmpleado(){
            int dpi = int.Parse(listaEmpleados.SelectedValue);
            String nombre = Controladora.getNombreEmpleado(dpi);
            lblEmpleado.Text = nombre;
        }

        protected void guardar_Click(object sender, EventArgs e){
            String idTipoGasto;
            try{
                idTipoGasto = (int.Parse(txtIdTipo.Text)).ToString();
            }
            catch (Exception ex){
                mostrar("DEBE ESCRIBIR EL ID DE FORMA NUMERICA",1);
                return;
            } 
            String nombre = txtNombreTipo.Text;
            if (nombre.Equals("")){
                mostrar("DEBE ESCRIBIR EL NOMBRE",1);
                return;
            } 
            String descripcion = txtDescripcionTipo.Text;
            String resultado = Controladora.registroTipoGasto(idTipoGasto,nombre,descripcion);
            mostrar2(resultado,1);
            limpiarCampos(1);
            rellenarDropDownList();
        }
        protected void guardarGasto_Click(object sender, EventArgs e) { 
            String idGasto;
            try{
                idGasto = (int.Parse(txtIdGasto.Text)).ToString();
            }
            catch (Exception ex){
                mostrar("DEBE ESCRIBIR EL ID DE FORMA NUMERICA",2);
                return;
            }
            String fecha;
            if(calendario.SelectedDate.Year == 0001 && calendario.SelectedDate.Month == 01 && calendario.SelectedDate.Day==01){
                mostrar("DEBE SELECCIONAR FECHA", 2);
                return;
            }
            else{
                fecha  = calendario.SelectedDate.Year + "/" + calendario.SelectedDate.Month + "/" + calendario.SelectedDate.Day;
            }
            String monto;
            try{
                monto = (double.Parse(txtMonto.Text)).ToString();
            }
            catch (Exception ex){
                mostrar("DEBE ESCRIBIR EL MONTO DE FORMA NUMERICA",2);
                return;
            } 
            String idTipoGasto = listaTipos.SelectedValue;
            String dpiEmpleado = listaEmpleados.SelectedValue;
            String resultado = Controladora.registroGasto(idGasto,fecha,monto,idTipoGasto,dpiEmpleado);
            mostrar2(resultado,2);
            limpiarCampos(2);
            rellenarDropDownList();
        }
        private void mostrar(string mensaje,int opcion){
            if (opcion == 1) {
                lblInformacionTipo.Text = mensaje;
            }
            else{
                lblInformacionGasto.Text = mensaje;
            }
        }
        private void mostrar2(string mensaje,int opcion){
            this.Page.Response.Write("<script language='JavaScript'>window.alert('"+mensaje+"');</script>");
            if (opcion == 1) {
                lblInformacionTipo.Text = mensaje;
            }
            else{
                lblInformacionGasto.Text = mensaje;
            }
        }
        private void limpiarCampos(int opcion) {
            if(opcion==1){
                txtIdTipo.Text = "";
                txtNombreTipo.Text = "";
                txtDescripcionTipo.Text = "";
                lblInformacionGasto.Text = "";
            }
            else{
                txtIdGasto.Text = "";
                txtMonto.Text = "";
                lblTipo.Text = "";
                lblEmpleado.Text = "";
                lblInformacionTipo.Text = "";
            }
        }
       
    }
}