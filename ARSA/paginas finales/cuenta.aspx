<%@ Page Title="" Language="C#" MasterPageFile="~/paginas maestras/maestra.Master" AutoEventWireup="true" CodeBehind="cuenta.aspx.cs" Inherits="ARSA.paginas_finales.cuenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPagina" runat="server">
     <asp:Panel ID="Ruteador" runat="server" BackImageUrl="~/images/fondo2.jpg" Font-Size="Medium" ForeColor="#D08133" GroupingText="CREACION DE CUENTA" style="margin-bottom: 0px" Width="100%">
             <table style="width: 100%;">
                 <tr>
                     <td style="width: 259px">

            <asp:Label ID="lblnickName" runat="server" Text="Ingrese nickName de usuario:(*) " Width="243px"></asp:Label></td>
                     <td colspan="2"><asp:TextBox ID="txtNickName" runat="server" Width="300px"></asp:TextBox>
                     </td>
                     <td>&nbsp;</td>
                 </tr>
                 <tr>
                     <td style="width: 259px">
            <asp:Label ID="lblCorreo" runat="server" Text="Ingrese el correo de la cuenta: " Width="228px"></asp:Label></td>
                     <td colspan="2"><asp:TextBox ID="txtCorreo" runat="server" Width="300px"></asp:TextBox>
                     </td>
                     <td>&nbsp;</td>
                 </tr>
                 <tr>
                     <td style="width: 259px">
            <asp:Label ID="lblpassWord" runat="server" Text="Password de la cuenta:(*) " Width="201px"></asp:Label></td>
                     <td colspan="2"><asp:TextBox ID="txtPassword" runat="server" Width="300px" TextMode="Password"></asp:TextBox>
                     </td>
                     <td>&nbsp;</td>
                 </tr>
                 <tr>
                     <td style="width: 259px">
            <asp:Label ID="lblRePass" runat="server" Text="Vuelva a ingresar el password: " Width="229px"></asp:Label></td>
                     <td style="width: 302px">
                         <asp:TextBox ID="txtRePassword" runat="server" Width="300px" TextMode="Password"></asp:TextBox>
                     </td>
                     <td>
                         &nbsp;</td>
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
        <asp:Panel ID="Panel1" runat="server" BackImageUrl="~/images/fondo2.jpg" Font-Size="Medium" ForeColor="#D08133" GroupingText="ELIMINACION DE CUENTA" style="margin-bottom: 0px" Width="100%">
             <table style="width: 100%;">
                 <tr>
                     <td style="width: 259px">

                         &nbsp;</td>
                     <td>&nbsp;</td>
                     <td>
                         <asp:Panel ID="PanelConsultador" runat="server" Font-Size="Medium" ForeColor="#D08133" GroupingText="CONSULTAR CUENTAS" style="margin-bottom: 0px" Width="100%">
                             <table style="width:100%;">
                                 <tr>
                                     <td style="width: 192px">
                                         <asp:Label ID="lblConsultador" runat="server" Text="LAS CUENTAS DISPONIBLES SON: " Width="251px"></asp:Label>
                                     </td>
                                     <td>
                                         <asp:DropDownList ID="listaCuentas" runat="server" AutoPostBack="True" Height="16px" Width="203px">
                                         </asp:DropDownList>
                                     </td>
                                 </tr>
                             </table>
                         </asp:Panel>
                     </td>
                 </tr>
                 <tr>
                     <td style="width: 259px">
                         <asp:Label ID="Label2" runat="server" Text="Ingrese el nombre de la cuenta:(*) " Width="248px"></asp:Label>
                     </td>
                     <td>
                         <asp:TextBox ID="txtNickNameBorrar" runat="server" Width="300px"></asp:TextBox>
                     </td>
                     <td>&nbsp;</td>
                 </tr>
                 <tr>
                     <td colspan="2">
                         <center>
                             <asp:Button ID="guardarEliminar" runat="server" style="margin-left: 0px" Text="Guardar" Width="254px" OnClick="guardarEliminar_Click" />
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
