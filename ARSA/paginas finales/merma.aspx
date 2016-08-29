<%@ Page Title="" Language="C#" MasterPageFile="~/paginas maestras/maestra.Master" AutoEventWireup="true" CodeBehind="merma.aspx.cs" Inherits="ARSA.paginas_finales.merma" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPagina" runat="server">
        <asp:Panel ID="RuteadorMerma" runat="server" BackImageUrl="~/images/fondo2.jpg" Font-Size="Medium" ForeColor="#D08133" GroupingText="MERMAS" style="margin-bottom: 0px" Width="100%">
             <table style="width: 100%;">
                 <tr>
                     <td style="width: 329px">

            <asp:Label ID="lblIdMerma" runat="server" Text="Ingrese el identificador de la merma:(*) " Width="296px"></asp:Label></td>
                     <td><asp:TextBox ID="txtIdMerma" runat="server" Width="300px"></asp:TextBox>
                     </td>
                     <td>&nbsp;</td>
                 </tr>
                 <tr>
                     <td style="width: 329px">
            <asp:Label ID="lblCantidadUnidades" runat="server" Text="Ingrese el numero de unidades perdidas:(*) " Width="313px"></asp:Label></td>
                     <td>
                         <asp:TextBox ID="txtCantidadUnidades" runat="server" Width="300px" TextMode="Number"></asp:TextBox>
                     </td>
                     <td>&nbsp;</td>
                 </tr>
                 <tr>
                     <td style="width: 329px">
            <asp:Label ID="lblJustificacion" runat="server" Text="Ingrese la justificacion de la perdida:(*) " Width="295px"></asp:Label></td>
                     <td><asp:TextBox ID="txtJustificacion" runat="server" Width="300px" TextMode="MultiLine" Height="45px"></asp:TextBox>
                     </td>
                     <td>&nbsp;</td>
                 </tr>
                 <tr>
                     <td style="width: 329px">
                         <asp:Label ID="lblValorPerdida" runat="server" Text="Ingrese el valor aproximado de la perdida:(*) " Width="325px"></asp:Label>
                     </td>
                     <td>
                         <asp:TextBox ID="txtValorPerdida" runat="server" Width="300px"></asp:TextBox>
                     </td>
                     <td>&nbsp;</td>
                 </tr>
                 <tr>
                     <td style="width: 329px">
                         <asp:Label ID="lblFecha" runat="server" Text="Seleccione la fecha de perdida:(*) " Width="279px"></asp:Label>
                     </td>
                     <td>
                         <asp:Calendar ID="calendario" runat="server" Height="31px" Width="233px"></asp:Calendar>
                     </td>
                     <td>&nbsp;</td>
                 </tr>
                 <tr>
                     <td style="width: 329px">
                         <asp:Label ID="lblProducto" runat="server" Text="Seleccione el codigo del producto:(*) " Width="279px"></asp:Label>
                     </td>
                     <td>
                         <asp:DropDownList ID="listaCodigoProducto" runat="server" AutoPostBack="True" Width="150px" OnSelectedIndexChanged="listaCodigoProducto_SelectedIndexChanged">
                         </asp:DropDownList>
                         <asp:Label ID="lblNombreProducto" runat="server" Text=""></asp:Label>
                     </td>
                     <td>&nbsp;</td>
                 </tr>
                 <tr>
                     <td colspan="2">
                         <center>
                             <asp:Button ID="guardar" runat="server" style="margin-left: 0px" Text="Guardar" Width="254px" OnClick="guardar_Click"/>
                         </center>
                     </td>
                     <td>
                         &nbsp;</td>
                 </tr>
             </table>
        </asp:Panel>
        <asp:Panel ID="InformadorGasto" runat="server" BackImageUrl="~/images/fondo1.jpg" Font-Size="Large" ForeColor="#D08133" GroupingText="INFORMACION" style="margin-bottom: 0px" Width="100%">
            <asp:Label ID="lblInformacion" runat="server" Text=""></asp:Label>
        </asp:Panel>
</asp:Content>
