<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarMantenimiento.aspx.cs" Inherits="Obligatorio_1_prog2.BuscarMantenimiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        Barco:<asp:DropDownList ID="DDBarco" runat="server">
        </asp:DropDownList>
    </p>
    <p>
        Mes:&nbsp;&nbsp;
        <asp:DropDownList ID="DDMes" runat="server">
            <asp:ListItem>Enero</asp:ListItem>
            <asp:ListItem>Febrero</asp:ListItem>
            <asp:ListItem>Marzo</asp:ListItem>
            <asp:ListItem>Abril</asp:ListItem>
            <asp:ListItem>Mayo</asp:ListItem>
            <asp:ListItem>Junio</asp:ListItem>
            <asp:ListItem>Julio</asp:ListItem>
            <asp:ListItem>Agosto</asp:ListItem>
            <asp:ListItem>Septiembre</asp:ListItem>
            <asp:ListItem>Octubre</asp:ListItem>
            <asp:ListItem>Noviembre</asp:ListItem>
            <asp:ListItem>Diciembre</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        Año:&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
    </p>
    <p>
        <asp:Label ID="LabelError" runat="server" ForeColor="Red"></asp:Label>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Buscar" OnClick="Button1_Click" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:GridView ID="GridMantenimiento" runat="server">
        </asp:GridView>
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</asp:Content>
