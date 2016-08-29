<%@ Page Title="" Language="C#" MasterPageFile="~/paginas maestras/maestra.Master" AutoEventWireup="true" CodeBehind="venta.aspx.cs" Inherits="ARSA.paginas_finales.venta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPagina" runat="server">
    <asp:Panel ID="RuteadorVenta" runat="server" BackImageUrl="~/images/fondo5.jpg" Font-Size="Medium" ForeColor="#D08133" GroupingText="VENTA" style="margin-bottom: 0px">       
            <table style="width:100%;">
                <tr>
                    <td style="width: 172px">
                        <asp:Label ID="lblNombre" runat="server" Text="Ingrese codigo de venta:(*) " Width="222px"></asp:Label>
                    </td>
                    <td style="width: 410px">
                        <asp:TextBox ID="txtIdVenta" runat="server" Width="224px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 172px">
                        <asp:Label ID="lblNombre0" runat="server" Text="Fecha de la venta:(*) " Width="229px"></asp:Label>
                    </td>
                    <td style="width: 410px">
                        <asp:Calendar ID="calendario" runat="server" Height="92px" Width="143px"></asp:Calendar>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 172px">
                        <asp:Label ID="lblNombre1" runat="server" Text="Descripcion de la venta:" Width="229px"></asp:Label>
                    </td>
                    <td style="width: 410px">
                        <asp:TextBox ID="txtDescripcion" runat="server" Width="224px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 172px">
                        <asp:Label ID="lblNombre2" runat="server" Text="Vendedor realizador de la venta:(*)" Width="253px"></asp:Label>
                    </td>
                    <td style="width: 410px">
                        <asp:DropDownList ID="listaNombresEmpleados" runat="server" Height="16px" Width="230px" AutoPostBack="True" OnSelectedIndexChanged="listaSeleccion_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:Label ID="lblCodigoVendedor" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 172px">
                        <asp:Label ID="lblNombre3" runat="server" Text="Cliente adquisisor de la venta:(*)" Width="250px"></asp:Label>
                    </td>
                    <td style="width: 410px">
                        <asp:DropDownList ID="listaNitClientes" runat="server" Height="16px" Width="230px" AutoPostBack="True" OnSelectedIndexChanged="listaSeleccion_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:Label ID="lblNombreCliente" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Panel ID="RuteadorT" runat="server" BackImageUrl="~/images/fondo6.jpg" Font-Size="Medium" ForeColor="#D08133" GroupingText="DETALLE DE VENTA" style="margin-bottom: 0px" Width="1012px">
                            <table style="width:100%;">
                                <tr>
                                    <td style="width: 201px">&nbsp;</td>
                                    <td colspan="2" rowspan="2">
                                        <asp:Panel ID="PanelConsultador" runat="server" Font-Size="Medium" ForeColor="#D08133" GroupingText="CONSULTAR PRODUCTO" style="margin-bottom: 0px" Width="100%">
                                            <table style="width:100%;">
                                                <tr>
                                                    <td style="width: 192px">
                                                        <asp:Label ID="lblConsultador" runat="server" Text="SELECCIONE NOMBRE: " Width="188px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="listaNombreProducto" runat="server" AutoPostBack="True" Height="16px" OnSelectedIndexChanged="listaSeleccion_SelectedIndexChanged" Width="203px">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 192px">
                                                        <asp:Label ID="lblConsultador1" runat="server" Text="EL CODIGO ES: "></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblResultadoCodigo" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 201px">
                                        <asp:Button ID="agregarDetalle" runat="server" OnClick="agregarDetalle_Click" Text="Agregar detalle" />
                                    </td>
                                </tr>
                                <tr>
                                    <td rowspan="4" style="width: 201px">
                                        <asp:GridView ID="Grid" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" ShowFooter="True" Width="581px">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="RowNumber" HeaderText="Row Number" />
                                                <asp:TemplateField HeaderText="Header 1">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Header 2">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Header 3">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EditRowStyle BackColor="#2461BF" />
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#EFF3FB" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                        </asp:GridView>
                                    </td>
                                    <td style="width: 203px">&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 203px">&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 203px">&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 203px">&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <center>
                            <asp:Button ID="guardar" runat="server" Text="Guardar" Height="35px" Width="240px" OnClick="guardar_Click"/>
                        </center>
                    </td>
                </tr>
            </table>
        
    </asp:Panel>  
    <asp:Panel ID="InformadorGasto" runat="server" BackImageUrl="~/images/fondo1.jpg" Font-Size="Large" ForeColor="#D08133" GroupingText="INFORMACION" style="margin-bottom: 0px" Width="100%">
        <asp:Label ID="lblInformacion" runat="server" Text=""></asp:Label>
    </asp:Panel>
</asp:Content>
