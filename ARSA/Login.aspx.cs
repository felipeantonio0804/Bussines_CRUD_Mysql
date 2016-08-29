using ARSA.clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ARSA
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void butIngresar_Click(object sender, EventArgs e){
            string nickName = textUsuario.Text;
            string password = textPassword.Text;
            string resultado = Controladora.logearse(nickName, password);
            mostrar(resultado);
            if (!resultado.Contains("NO VALIDO")) { 
                Session["usuario"] = nickName;
                Response.Redirect("~/paginas finales/cliente.aspx");
            }
        }
        private void mostrar(string mensaje){
            this.Page.Response.Write("<script language='JavaScript'>window.alert('" + mensaje + "');</script>");
        }
    }
}