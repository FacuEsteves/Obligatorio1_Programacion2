<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BusquedaDeMantenimientos.aspx.cs" Inherits="Obligatorio_1_prog2.BusquedaDeMantenimientos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Diseño/General.css" />
    <p>
        <br />
    </p>
    <p>
        &nbsp;</p>
    <p>
        Barco:&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DD_Barco" class="form-select" runat="server" AppendDataBoundItems="True">
            <asp:ListItem>(Seleccionar)</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        &nbsp;</p>
    <p>
        Mes:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DDMes" class="form-select" runat="server">
            <asp:ListItem>(Seleccionar)</asp:ListItem>
            <asp:ListItem Value="1">Enero</asp:ListItem>
            <asp:ListItem Value="2">Febrero</asp:ListItem>
            <asp:ListItem Value="3">Marzo</asp:ListItem>
            <asp:ListItem Value="4">Abril</asp:ListItem>
            <asp:ListItem Value="5">Mayo</asp:ListItem>
            <asp:ListItem Value="6">Junio</asp:ListItem>
            <asp:ListItem Value="7">Julio</asp:ListItem>
            <asp:ListItem Value="8">Agosto</asp:ListItem>
            <asp:ListItem Value="9">Septiembre</asp:ListItem>
            <asp:ListItem Value="10">Octubre</asp:ListItem>
            <asp:ListItem Value="11">Noviembre</asp:ListItem>
            <asp:ListItem Value="12">Diciembre</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        &nbsp;</p>
    <p>
        Año:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtAño" class="form-control" runat="server"></asp:TextBox>
    </p>
    <p>
        &nbsp;<asp:Label ID="LabelError" runat="server" ForeColor="Red"></asp:Label>
    </p>
    <p>
        <asp:Button ID="btnBuscar" class="btn-success" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:GridView ID="GridView1" class="table table-dark table-striped" runat="server">
        </asp:GridView>
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
    </p>
</asp:Content>
