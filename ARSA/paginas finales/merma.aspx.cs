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
    public partial class merma : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                rellenarDropDownList();
                nombreProducto();
            }
        }
        private void rellenarDropDownList(){
            listaCodigoProducto.Items.Clear();
            DataTable tablaCodigoProducto = Controladora.getTableCodigosProducto();
         
            listaCodigoProducto.DataSource = tablaCodigoProducto;
            listaCodigoProducto.DataTextField = "IDPRODUCTO";
            listaCodigoProducto.DataValueField = "IDPRODUCTO";
            listaCodigoProducto.DataBind();
        }
        protected void listaCodigoProducto_SelectedIndexChanged(object sender, EventArgs e){
            nombreProducto();
        }
        private void nombreProducto(){
            int idProducto = int.Parse(listaCodigoProducto.SelectedValue);
            String nombre = Controladora.getNombreProducto(idProducto);
            lblNombreProducto.Text = nombre;
        }

        protected void guardar_Click(object sender, EventArgs e){
            String idMerma;
            try{
                idMerma = (int.Parse(txtIdMerma.Text)).ToString();
            }
            catch (Exception ex){
                mostrar("DEBE ESCRIBIR EL ID DE FORMA NUMERICA");
                return;
            }
            String unidades;
            try{
                unidades = (int.Parse(txtCantidadUnidades.Text)).ToString();
            }
            catch (Exception ex){
                mostrar("DEBE ESCRIBIR LA CANTIDAD DE FORMA NUMERICA");
                return;
            }
            String justificacion = txtJustificacion.Text;
            if (justificacion.Equals("")) {
                mostrar("DEBE JUSTIFICAR LA RAZON DE LA PERDIDA");
                return;
            }
            String valor;
            try{
                valor = (double.Parse(txtValorPerdida.Text)).ToString();
            }
            catch (Exception ex){
                mostrar("DEBE ESCRIBIR EL VALOR DE FORMA NUMERICA");
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
            String idProducto = listaCodigoProducto.SelectedValue;
            String resultado = Controladora.registroMerma(idMerma,unidades,justificacion,valor,fecha,idProducto);
            mostrar2(resultado);
            limpiarCampos();
            rellenarDropDownList();
        }
        private void mostrar(string mensaje){
            lblInformacion.Text = mensaje;
        }
        private void mostrar2(string mensaje){
            this.Page.Response.Write("<script language='JavaScript'>window.alert('"+mensaje+"');</script>");
            lblInformacion.Text = mensaje;
        
        }
        private void limpiarCampos() {
            txtIdMerma.Text = "";
            txtCantidadUnidades.Text = "";
            txtJustificacion.Text = "";
            txtValorPerdida.Text = "";
            txtJustificacion.Text = "";
            lblNombreProducto.Text = "";
        }

        
    }
}