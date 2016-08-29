<%@ Page Title="" Language="C#" MasterPageFile="~/paginas maestras/maestra.Master" AutoEventWireup="true" CodeBehind="gasto.aspx.cs" Inherits="ARSA.paginas_finales.gasto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPagina" runat="server">
        <asp:Panel ID="RuteadorT" runat="server" BackImageUrl="~/images/fondo2.jpg" Font-Size="Medium" ForeColor="#D08133" GroupingText="TIPOS DE GASTOS" style="margin-bottom: 0px" Width="100%">
             <table style="width: 100%;">
                 <tr>
                     <td style="width: 325px">

            <asp:Label ID="lblIdT" runat="server" Text="Ingrese el identificador del tipo de gasto:(*) " Width="316px"></asp:Label></td>
                     <td><asp:TextBox ID="txtIdTipo" runat="server" Width="300px"></asp:TextBox>
                     </td>
                     <td>&nbsp;</td>
                 </tr>
                 <tr>
                     <td style="width: 325px">
            <asp:Label ID="lblNombreT" runat="server" Text="Nombre del tipo de gasto:(*) " Width="262px"></asp:Label></td>
                     <td><asp:TextBox ID="txtNombreTipo" runat="server" Width="300px"></asp:TextBox>
                     </td>
                     <td>&nbsp;</td>
                 </tr>
                 <tr>
                     <td style="width: 325px">
            <asp:Label ID="lblDescripcionT" runat="server" Text="Descripcion del tipo de gasto: " Width="279px"></asp:Label></td>
                     <td><asp:TextBox ID="txtDescripcionTipo" runat="server" Width="300px" TextMode="MultiLine" Height="45px"></asp:TextBox>
                     </td>
                     <td>&nbsp;</td>
                 </tr>
                 <tr>
                     <td colspan="2">
                         <center>
                             <asp:Button ID="guardar" runat="server" OnClick="guardar_Click" style="margin-left: 0px" Text="Guardar" Width="254px" />
                         </center>
                     </td>
                     <td>
                         &nbsp;</td>
                 </tr>
             </table>
        </asp:Panel>
        <asp:Panel ID="InformadorTipo" runat="server" BackImageUrl="~/images/fondo1.jpg" Font-Size="Large" ForeColor="#D08133" GroupingText="INFORMACION" style="margin-bottom: 0px" Width="100%">
            <asp:Label ID="lblInformacionTipo" runat="server" Text=""></asp:Label>
        </asp:Panel>
    <br />
    <hr width="80%">
         <asp:Panel ID="RuteadorG" runat="server" BackImageUrl="~/images/fondo2.jpg" Font-Size="Medium" ForeColor="#D08133" GroupingText="GASTOS" style="margin-bottom: 0px" Width="100%">
             <table style="width: 100%;">
                 <tr>
                     <td style="width: 308px">

            <asp:Label ID="lblIG" runat="server" Text="Ingrese el identificador del gasto:(*) " Width="296px"></asp:Label></td>
                     <td><asp:TextBox ID="txtIdGasto" runat="server" Width="300px"></asp:TextBox>
                     </td>
                     <td>&nbsp;</td>
                 </tr>
                 <tr>
                     <td style="width: 308px">
            <asp:Label ID="lblfecG" runat="server" Text="Fecha del gasto:(*) " Width="262px"></asp:Label></td>
                     <td><asp:Calendar ID="calendario" runat="server" Height="125px" Width="300px"></asp:Calendar>
                     </td>
                     <td>&nbsp;</td>
                 </tr>
                 <tr>
                     <td style="width: 308px">
            <asp:Label ID="lblMontoG" runat="server" Text="Monto total del gasto:(*) " Width="279px"></asp:Label></td>
                     <td><asp:TextBox ID="txtMonto" runat="server" Width="300px"></asp:TextBox>
                     </td>
                     <td>&nbsp;</td>
                 </tr>
                 <tr>
                     <td style="width: 308px">
                         <asp:Label ID="lblTipoGasto" runat="server" Text="Seleccione el tipo de gasto:(*) " Width="279px"></asp:Label>
                     </td>
                     <td>
                         <asp:DropDownList ID="listaTipos" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="listaTipos_SelectedIndexChanged">
                         </asp:DropDownList>
                         <asp:Label ID="lblTipo" runat="server" Text=""></asp:Label>
                     </td>
                     <td>&nbsp;</td>
                 </tr>
                 <tr>
                     <td style="width: 308px">
                         <asp:Label ID="lblEmpleadoGasto" runat="server" Text="Seleccione el empleado que efectuo pago:(*) " Width="279px"></asp:Label>
                     </td>
                     <td>
                         <asp:DropDownList ID="listaEmpleados" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="listaEmpleados_SelectedIndexChanged">
                         </asp:DropDownList>
                         <asp:Label ID="lblEmpleado" runat="server" Text=""></asp:Label>
                     </td>
                     <td>&nbsp;</td>
                 </tr>
                 <tr>
                     <td colspan="2">
                         <center>
                             <asp:Button ID="guardarGasto" runat="server" OnClick="guardarGasto_Click" style="margin-left: 0px" Text="Guardar" Width="254px" />
                         </center>
                     </td>
                     <td>
                         &nbsp;</td>
                 </tr>
             </table>
        </asp:Panel>
        <asp:Panel ID="InformadorGasto" runat="server" BackImageUrl="~/images/fondo1.jpg" Font-Size="Large" ForeColor="#D08133" GroupingText="INFORMACION" style="margin-bottom: 0px" Width="100%">
            <asp:Label ID="lblInformacionGasto" runat="server" Text=""></asp:Label>
        </asp:Panel>
</asp:Content>
