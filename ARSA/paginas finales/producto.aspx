<%@ Page Title="" Language="C#" MasterPageFile="~/paginas maestras/maestra.Master" AutoEventWireup="true" CodeBehind="producto.aspx.cs" Inherits="ARSA.paginas_finales.empleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPagina" runat="server">
         <asp:Panel ID="Ruteador" runat="server" BackImageUrl="~/images/fondo2.jpg" Font-Size="Medium" ForeColor="#D08133" GroupingText="PRODUCTOS" style="margin-bottom: 0px" Width="100%">
             <table style="width: 100%;">
                 <tr>
                     <td style="width: 259px">

            <asp:Label ID="lblOpcion" runat="server" Text="Seleccion una opcion:(*) " Width="186px"></asp:Label>
                     </td>
                     <td colspan="3">
                         <asp:RadioButton ID="rbCrear" Text="Crear" runat="server" GroupName="uno" OnCheckedChanged="rbCrear_CheckedChanged" AutoPostBack="True"/>
                         <asp:RadioButton ID="rbModificar" Text="Modificar" runat="server" GroupName="uno" OnCheckedChanged="rbModificar_CheckedChanged" AutoPostBack="True" />
                         <asp:RadioButton ID="rbEliminar" Text="Eliminar" runat="server" GroupName="uno" OnCheckedChanged="rbEliminar_CheckedChanged" AutoPostBack="True" />
                     </td>
                 </tr>
                 <tr>
                     <td style="width: 259px">

            <asp:Label ID="lblCodigoProducto" runat="server" Text="Ingrese codigo de producto:(*) " Width="226px"></asp:Label></td>
                     <td colspan="2"><asp:TextBox ID="txtCodigoProducto" runat="server" Width="300px"></asp:TextBox><asp:Button ID="cargarDatos" runat="server" Text="Cargar Datos" OnClick="cargarDatos_Click" />
                     </td>
                     <td>&nbsp;</td>
                 </tr>
                 <tr>
                     <td style="width: 259px">
            <asp:Label ID="lblNombre" runat="server" Text="Nombre del producto:(*) " Width="198px"></asp:Label></td>
                     <td colspan="2"><asp:TextBox ID="txtNombre" runat="server" Width="300px"></asp:TextBox>
                     </td>
                     <td rowspan="2">
                         <asp:Panel ID="PanelConsultador" runat="server" Font-Size="Medium" ForeColor="#D08133" GroupingText="CONSULTAR PRODUCTO" style="margin-bottom: 0px" Width="76%">
                             <table style="width:100%;">
                                 <tr>
                                     <td style="width: 192px">
                                         <asp:Label ID="lblConsultador" runat="server" Text="SELECCIONE NOMBRE: " Width="188px"></asp:Label>
                                     </td>
                                     <td>
                                         <asp:DropDownList ID="listaNombreProducto" runat="server" AutoPostBack="True" Height="16px" OnSelectedIndexChanged="listaNombreProducto_SelectedIndexChanged" Width="203px">
                                         </asp:DropDownList>
                                     </td>
                                 </tr>
                             </table>
                         </asp:Panel>
                     </td>
                 </tr>
                 <tr>
                     <td style="width: 259px">
            <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion del producto: " Width="201px"></asp:Label></td>
                     <td colspan="2"><asp:TextBox ID="txtDescripcion" runat="server" Width="300px" TextMode="MultiLine" Height="45px" AutoPostBack="True"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td style="width: 259px">
            <asp:Label ID="lblImagenEtiqueta" runat="server" Text="Imagen del producto: " Width="168px"></asp:Label></td>
                     <td style="width: 302px">
                         <asp:Image ID="imagenGrafica" runat="server" width="150px" Height="150px" BorderWidth="1px" />
                     </td>
                     <td>
                         <asp:FileUpload ID="cargarImagen" runat="server"/><asp:Button ID="cargarImagen2" runat="server" Text="Cargar Imagen" OnClick="cargarImagen2_Click" />
                
                     </td>
                     <td>&nbsp;</td>
                 </tr>
                 <tr>
                     <td colspan="3"> 
                        <center>
                            <asp:Button ID="guardar" runat="server" Text="Guardar" OnClick="guardar_Click" style="margin-left: 0px" Width="254px" />
                        </center>
                     </td>
                     <td>&nbsp;</td>
                 </tr>
             </table>
        </asp:Panel>
        <asp:Panel ID="Informador" runat="server" BackImageUrl="~/images/fondo1.jpg" Font-Size="Large" ForeColor="#D08133" GroupingText="INFORMACION" style="margin-bottom: 0px" Width="100%">
            <asp:Label ID="lblInformacion" runat="server" Text=""></asp:Label>
        </asp:Panel>
</asp:Content>
