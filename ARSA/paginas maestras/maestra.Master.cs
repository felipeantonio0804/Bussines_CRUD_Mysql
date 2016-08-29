using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ARSA.paginas_maestras
{
    public partial class maestra : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                if (Session["usuario"] == null) {
                    Response.Redirect("~/Login.aspx");
                }
                else{
                    lblUsuario.Text = Session["usuario"].ToString();
                }
            }
        }

        protected void gestionDatos_Click(object sender, EventArgs e)//gestiones principales
        {
            string opcion = gestionesPrincipales.SelectedValue;
            if (opcion.Contains("CLIENTES")) {
                Response.Redirect("~/paginas finales/cliente.aspx");
            }
            else if (opcion.Contains("PROVEEDORES")){
                Response.Redirect("~/paginas finales/proveedor.aspx");
            }
            else if (opcion.Contains("EMPLEADOS")){
                Response.Redirect("~/paginas finales/empleado.aspx");
            }
            else if (opcion.Contains("PRODUCTOS")){
                Response.Redirect("~/paginas finales/producto.aspx");
            }
            else if (opcion.Contains("MERMAS")){
                Response.Redirect("~/paginas finales/merma.aspx");
            }
            else if (opcion.Contains("GASTOS")){
                Response.Redirect("~/paginas finales/gasto.aspx");
            }
        }

        protected void gestionDatos0_Click(object sender, EventArgs e)//ventas y compras
        {
            string opcion = comprasYVentas.SelectedValue;
            if (opcion.Contains("VENTAS")) {
                Response.Redirect("~/paginas finales/venta.aspx");
            }
            else if (opcion.Contains("COMPRAS")){
                Response.Redirect("~/paginas finales/compra.aspx");
            }
        }

        protected void gestionDatos1_Click(object sender, EventArgs e)//reportes
        {
            if (reportes.SelectedValue.Contains("1")) {
                ReportDocument crystalReport = new ReportDocument();
                crystalReport.Load(Server.MapPath("~/paginas finales/reportes/reporte1.rpt"));
                crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Reporte_Estado");
            }
            else if (reportes.SelectedValue.Contains("2")) {
                ReportDocument crystalReport = new ReportDocument();
                crystalReport.Load(Server.MapPath("~/paginas finales/reportes/reporte2.rpt"));
                crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Reporte_Vendedores");
            }
            else if (reportes.SelectedValue.Contains("3")) {
                ReportDocument crystalReport = new ReportDocument();
                crystalReport.Load(Server.MapPath("~/paginas finales/reportes/reporte3.rpt"));
                crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Reporte_DiasSemana");
            }
            else if (reportes.SelectedValue.Contains("4")) {
                ReportDocument crystalReport = new ReportDocument();
                crystalReport.Load(Server.MapPath("~/paginas finales/reportes/reporte4.rpt"));
                crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Reporte_Clientes");
            }
        }

        protected void gestionCuentas_Click(object sender, EventArgs e)//gestion de cuentas
        {
            Response.Redirect("~/paginas finales/cuenta.aspx");
        }

        protected void salir_Click(object sender, EventArgs e){
            Session["usuario"] = null;
            Response.Redirect("~/Login.aspx");
        }
    }
}