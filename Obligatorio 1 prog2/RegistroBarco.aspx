<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroBarco.aspx.cs" Inherits="Obligatorio_1_prog2.RegistroBarco" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        Nombre de barco :
        <asp:TextBox ID="TxtNombreBarco" runat="server"></asp:TextBox>
    </p>
    <p>
        Cantiad de pasajeros :
        <asp:TextBox ID="TxtCantPasajeros" runat="server"></asp:TextBox>
    </p>
    <p>
        Cantidad maxima deTripulantes :
        <asp:TextBox ID="TxtCantMaxTripulantes" runat="server"></asp:TextBox>
    </p>
    <p>
        Tipo de barco :&nbsp;
        <asp:DropDownList ID="TipoBarco" runat="server" OnSelectedIndexChanged="TipoBarco_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem Selected="True">(Seleccionar)</asp:ListItem>
            <asp:ListItem Value="BarcoLento">Barco Lento</asp:ListItem>
            <asp:ListItem Value="BarcoRapido">Barco Rapido</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        <asp:Label runat="server" Text="Velocidad Maxima : " ID="LabelVelMax" Visible="False"></asp:Label> 
        <asp:TextBox ID="TxtVelMaxima" runat="server" Visible="False"></asp:TextBox>
    </p>
    <p>
        <asp:Label runat="server" Text="Cantidad de vehiculos : " ID="LabelCantVehi" Visible="False"></asp:Label>
        <asp:TextBox ID="TxtCantVehiculos" runat="server" Visible="False"></asp:TextBox>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="LabelError" runat="server" ForeColor="Red"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="BtnGuardar" runat="server" OnClick="BtnGuardar_Click" Text="Guardar" />
        <asp:Button ID="BtnBuscar" runat="server" OnClick="BtnBuscar_Click" Text="Buscar" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:GridView ID="GridBarcoRapido" runat="server">
        </asp:GridView>
    </p>
    <p>
        <asp:GridView ID="GridBarcoLento" runat="server">
        </asp:GridView>
    </p>
</asp:Content>
