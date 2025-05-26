<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionarSucursales.aspx.cs" Inherits="TP7_GRUPO_5.SeleccionarSucursales" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 202px;
        }
        .auto-style3 {
            width: 314px;
        }
        .auto-style10 {
            width: 314px;
            height: 24px;
        }
        .auto-style13 {
            height: 24px;
        }
        .auto-style14 {
            width: 64px;
        }
        .auto-style15 {
            height: 24px;
            width: 64px;
        }
        .auto-style16 {
            width: 226px;
        }
        .auto-style17 {
            width: 226px;
            height: 24px;
        }
        .auto-style19 {
            width: 221px;
            height: 24px;
        }
        .auto-style20 {
            width: 221px;
        }
        .auto-style21 {
            width: 304px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style2">
                        <asp:HyperLink ID="hlListadoSucursales" runat="server" NavigateUrl="~/SeleccionarSucursales.aspx">Listado de Sucursales</asp:HyperLink>
                    </td>
                    <td class="auto-style21">&nbsp;</td>
                    <td>
                        <asp:HyperLink ID="hlMostrarSucursalesSeleccionadas" runat="server" NavigateUrl="~/ListadoSucursalesSeleccionados.aspx">Mostrar Sucursales Seleccionadas</asp:HyperLink>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style16">&nbsp;</td>
                <td class="auto-style20">&nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style16">
                    <asp:Label ID="lblListadoDeSucursales" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="Black" Text="Listado de sucursales"></asp:Label>
                </td>
                <td class="auto-style20">&nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style16">
                    &nbsp;</td>
                <td class="auto-style20">
                    &nbsp;</td>
                <td class="auto-style14">
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style16">
                    <asp:Label ID="LblBusqueda" runat="server" Text="Busqueda por nombre de sucursal:"></asp:Label>
                </td>
                <td class="auto-style20">
                    <asp:TextBox ID="TxtBusqueda" runat="server" Height="22px" Width="204px"></asp:TextBox>
                </td>
                <td class="auto-style14">
                    <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" OnClick="BtnBuscar_Click" />
                </td>
                <td colspan="3">
                    <asp:RegularExpressionValidator ID="revBuscar" runat="server" ControlToValidate="TxtBusqueda" ErrorMessage="No se permiten caracteres especiales" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style10"></td>
                <td class="auto-style17">
                    </td>
                <td class="auto-style19"></td>
                <td class="auto-style15"></td>
                <td class="auto-style13"></td>
                <td class="auto-style13"></td>
                <td class="auto-style13"></td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:DataList ID="DLProvincia" runat="server" DataSourceID="Provincia" OnItemCommand="DLProvincia_ItemCommand">
    <ItemTemplate>
        <br />
        <asp:Button ID="BtnProvincia" runat="server" Text='<%# Eval("DescripcionProvincia") %>' Font-Size="X-Large" CommandName="EventoProvincia" CommandArgument='<%# Eval ("Id_Provincia")%>' />
    </ItemTemplate>
</asp:DataList>
                </td>
                <td colspan="6">
                    <asp:ListView ID="LVSucursales" runat="server" DataKeyNames="Id_Sucursal" GroupItemCount="3" OnPagePropertiesChanging="LVSucursales_PagePropertiesChanging">
                        <EditItemTemplate>
                            <td runat="server" style="background-color: #999999;">NombreSucursal:
                                <asp:TextBox ID="NombreSucursalTextBox" runat="server" Text='<%# Bind("NombreSucursal") %>' />
                                <br />
                                DescripcionSucursal:
                                <asp:TextBox ID="DescripcionSucursalTextBox" runat="server" Text='<%# Bind("DescripcionSucursal") %>' />
                                <br />
                                URL_Imagen_Sucursal:
                                <asp:TextBox ID="URL_Imagen_SucursalTextBox" runat="server" Text='<%# Bind("URL_Imagen_Sucursal") %>' />
                                <br />
                                Id_Sucursal:
                                <asp:Label ID="Id_SucursalLabel1" runat="server" Text='<%# Eval("Id_Sucursal") %>' />
                                <br />
                                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Actualizar" />
                                <br />
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancelar" />
                                <br />
                            </td>
                        </EditItemTemplate>
                        <EmptyDataTemplate>
                            <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                                <tr>
                                    <td>No se han devuelto datos.</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <EmptyItemTemplate>
                            <td runat="server" />
                        </EmptyItemTemplate>
                        <GroupTemplate>
                            <tr id="itemPlaceholderContainer" runat="server">
                                <td id="itemPlaceholder" runat="server"></td>
                            </tr>
                        </GroupTemplate>
                        <InsertItemTemplate>
                            <td runat="server" style="">NombreSucursal:
                                <asp:TextBox ID="NombreSucursalTextBox" runat="server" Text='<%# Bind("NombreSucursal") %>' />
                                <br />
                                DescripcionSucursal:
                                <asp:TextBox ID="DescripcionSucursalTextBox" runat="server" Text='<%# Bind("DescripcionSucursal") %>' />
                                <br />
                                URL_Imagen_Sucursal:
                                <asp:TextBox ID="URL_Imagen_SucursalTextBox" runat="server" Text='<%# Bind("URL_Imagen_Sucursal") %>' />
                                <br />
                                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insertar" />
                                <br />
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Borrar" />
                                <br />
                            </td>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <td runat="server" style="background-color: #E0FFFF;color: #333333;"> <asp:Label ID="NombreSucursalLabel" runat="server" Text='<%# Eval("NombreSucursal") %>' />
                                <br />
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# Eval("URL_Imagen_Sucursal") %>' />
                                <br />
                                <asp:Label ID="DescripcionSucursalLabel" runat="server" Text='<%# Eval("DescripcionSucursal") %>' />
                                <br />
                                <br />
                                <asp:Button ID="BtnSeleccionar" runat="server" Text="Seleccionar" CommandArgument='<%# Eval("Id_Sucursal") + "-" + Eval("NombreSucursal") + "-" + Eval("DescripcionSucursal") %>' CommandName="eventoSeleccionar" OnCommand="BtnSeleccionar_Command" />
                                <br />
                            </td>
                        </ItemTemplate>
                        <LayoutTemplate>
                            <table runat="server">
                                <tr runat="server">
                                    <td runat="server">
                                        <table id="groupPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                            <tr id="groupPlaceholder" runat="server">
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr runat="server">
                                    <td runat="server" style="text-align: center;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF">
                                        <asp:DataPager ID="DataPager1" runat="server" PageSize="6">
                                            <Fields>
                                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                                <asp:NumericPagerField />
                                                <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                            </Fields>
                                        </asp:DataPager>
                                    </td>
                                </tr>
                            </table>
                        </LayoutTemplate>
                        <SelectedItemTemplate>
                            <td runat="server" style="background-color: #E2DED6;font-weight: bold;color: #333333;">NombreSucursal:
                                <asp:Label ID="NombreSucursalLabel" runat="server" Text='<%# Eval("NombreSucursal") %>' />
                                <br />
                                DescripcionSucursal:
                                <asp:Label ID="DescripcionSucursalLabel" runat="server" Text='<%# Eval("DescripcionSucursal") %>' />
                                <br />
                                URL_Imagen_Sucursal:
                                <asp:Label ID="URL_Imagen_SucursalLabel" runat="server" Text='<%# Eval("URL_Imagen_Sucursal") %>' />
                                <br />
                                Id_Sucursal:
                                <asp:Label ID="Id_SucursalLabel" runat="server" Text='<%# Eval("Id_Sucursal") %>' />
                                <br />
                            </td>
                        </SelectedItemTemplate>
                    </asp:ListView>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:SqlDataSource ID="Provincia" runat="server" ConnectionString="<%$ ConnectionStrings:BDSucursalesConnectionString3 %>" ProviderName="<%$ ConnectionStrings:BDSucursalesConnectionString3.ProviderName %>" SelectCommand="SELECT [Id_Provincia], [DescripcionProvincia] FROM [Provincia]"></asp:SqlDataSource>
                </td>
                <td class="auto-style16">
                    &nbsp;</td>
                <td colspan="5">
                    &nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
