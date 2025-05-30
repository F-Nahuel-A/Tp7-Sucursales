﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoSucursalesSeleccionados.aspx.cs" Inherits="TP7_GRUPO_5.ListadoSucursalesSeleccionados" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style4 {
            width: 202px;
        }
        .auto-style5 {
            width: 122px;
            height: 23px;
        }
        .auto-style6 {
            height: 23px;
        }
        .auto-style7 {
            width: 147px;
        }
        .auto-style8 {
            width: 122px;
        }
        .auto-style9 {
            width: 121px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style4">
                        <asp:HyperLink ID="hlListadoSucursales" runat="server" NavigateUrl="~/SeleccionarSucursales.aspx">Listado de Sucursales</asp:HyperLink>
                    </td>
                    <td class="auto-style7">&nbsp;</td>
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
                <td class="auto-style8">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">&nbsp;</td>
                <td>
                    <asp:Label ID="lblMostrarSucursalesSeleccionadas" runat="server" Font-Bold="True" Font-Overline="False" Font-Size="X-Large" Text="Mostrar sucursales seleccionadas"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style6" colspan="6">
                    <asp:GridView ID="GvMostrarSucursalesSeleccionadas" runat="server" AllowPaging="True" OnPageIndexChanging="GvMostrarSucursalesSeleccionadas_PageIndexChanging" PageSize="3">
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
