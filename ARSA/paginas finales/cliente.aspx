<%@ Page Title="" Language="C#" MasterPageFile="~/paginas maestras/maestra.Master" AutoEventWireup="true" CodeBehind="cliente.aspx.cs" Inherits="ARSA.paginas_finales.cliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPagina" runat="server">
        <asp:Panel ID="Ruteador" runat="server" BackImageUrl="~/images/fondo2.jpg" Font-Size="Medium" ForeColor="#D08133" GroupingText="CLIENTES" style="margin-bottom: 0px" Width="100%">
             <table style="width: 100%;">
                 <tr>
                     <td style="width: 259px; height: 26px;">

            <asp:Label ID="lblOpcion" runat="server" Text="Seleccion una opcion:(*) " Width="186px"></asp:Label>
                     </td>
                     <td colspan="2" style="height: 26px">
                         <asp:RadioButton ID="rbCrear" Text="Crear" runat="server" GroupName="uno" OnCheckedChanged="rbCrear_CheckedChanged" AutoPostBack="True"/>
                         <asp:RadioButton ID="rbModificar" Text="Modificar" runat="server" GroupName="uno" OnCheckedChanged="rbModificar_CheckedChanged" AutoPostBack="True" />
                         <asp:RadioButton ID="rbEliminar" Text="Eliminar" runat="server" GroupName="uno" OnCheckedChanged="rbEliminar_CheckedChanged" AutoPostBack="True" />
                     </td>
                 </tr>
                 <tr>
                     <td style="width: 259px">

            <asp:Label ID="lblnit" runat="server" Text="Ingrese numero de nit: " Width="226px"></asp:Label></td>
                     <td style="width: 452px"><asp:TextBox ID="txtNit" runat="server" Width="300px"></asp:TextBox><asp:Button ID="cargarDatos" runat="server" Text="Cargar Datos" OnClick="cargarDatos_Click" Width="89px" />
                     </td>
                     <td rowspan="3">
                         <asp:Panel ID="PanelConsultador" runat="server" Font-Size="Medium" ForeColor="#D08133" GroupingText="CONSULTAR CLIENTE" style="margin-bottom: 0px" Width="76%">
                            <table style="width:100%;">
                                <tr>
                                    <td style="width: 192px">
                                        <asp:Label ID="lblConsultador" runat="server" Text="SELECCIONE NOMBRE: " Width="188px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="listaNombreCliente" runat="server" AutoPostBack="True" Height="16px" OnSelectedIndexChanged="listaNombreCliente_SelectedIndexChanged" Width="203px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                     </td>
                 </tr>
                 <tr>
                     <td style="width: 259px">
            <asp:Label ID="lblNombre" runat="server" Text="Nombre del cliente: " Width="198px"></asp:Label></td>
                     <td style="width: 452px"><asp:TextBox ID="txtNombre" runat="server" Width="300px"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td style="width: 259px; height: 26px;">
            <asp:Label ID="lblDireccion" runat="server" Text="Direccion del cliente: " Width="201px"></asp:Label></td>
                     <td style="height: 26px; width: 452px"><asp:TextBox ID="txtDireccion" runat="server" Width="300px"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td style="width: 259px">
            <asp:Label ID="lblTelefono" runat="server" Text="Telefono del cliente: " Width="229px"></asp:Label></td>
                     <td style="width: 452px">
                         <asp:TextBox ID="txtTelefono" runat="server" Width="300px"></asp:TextBox>
                     </td>
                     <td rowspan="2">&nbsp;</td>
                 </tr>
                 <tr>
                     <td colspan="2"> 
                        <center>
                            <asp:Button ID="guardar" runat="server" Text="Guardar" OnClick="guardar_Click" style="margin-left: 0px" Width="254px" />
                        </center>
                     </td>
                 </tr>
             </table>
        </asp:Panel>
        <asp:Panel ID="Informador" runat="server" BackImageUrl="~/images/fondo1.jpg" Font-Size="Large" ForeColor="#D08133" GroupingText="INFORMACION" style="margin-bottom: 0px" Width="100%">
            <asp:Label ID="lblInformacion" runat="server" Text=""></asp:Label>
        </asp:Panel>
</asp:Content>
