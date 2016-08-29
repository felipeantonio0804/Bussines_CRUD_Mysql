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
    public partial class cuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e){
            if (!IsPostBack) {
                rellenarDropDownList();
            }
        }
        private void rellenarDropDownList(){
            listaCuentas.Items.Clear();
            DataTable tablaCuentas= Controladora.getTableCuentas();
            listaCuentas.DataSource = tablaCuentas;
            listaCuentas.DataTextField = "NICKNAME";
            listaCuentas.DataValueField = "NICKNAME";
            listaCuentas.DataBind();
        }

        protected void guardar_Click(object sender, EventArgs e){
            string nickName = txtNickName.Text;
            if (nickName.Equals("")) {
                mostrar("NOMBRE DE LA CUENTA NECESARIO");
                return;
            }
            string correo = txtCorreo.Text;
            string password = txtPassword.Text;
            if (password.Equals("")) {
                mostrar("PASSWORD DE LA CUENTA ES NECESARIO");
                return;
            }
            if (!password.Equals(txtRePassword.Text)) {
                mostrar("LAS CONTRASENAS NO COINCIDEN");
                return;
            }
            String resultado = Controladora.ingresarCuenta(nickName, password, correo);
            mostrar2(resultado);
            limpiarCampos();
            rellenarDropDownList();
        }
        protected void guardarEliminar_Click(object sender, EventArgs e){
            string nickName = txtNickNameBorrar.Text;
            if (nickName.Equals("")) {
                mostrar("NOMBRE DE LA CUENTA NECESARIO PARA BORRAR");
                return;
            }
            String resultado = Controladora.eliminarCuenta(nickName);
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
            txtNickName.Text = "";
            txtCorreo.Text = "";
            txtPassword.Text = "";
            txtRePassword.Text = "";
            txtNickNameBorrar.Text = "";
        }
    }
}