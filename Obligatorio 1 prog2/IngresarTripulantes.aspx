<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IngresarTripulantes.aspx.cs" Inherits="Obligatorio_1_prog2.IngresarTripulantes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Cedula:"></asp:Label>
&nbsp;<asp:TextBox ID="TxtCedula" runat="server"></asp:TextBox>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Nombre:"></asp:Label>
        <asp:TextBox ID="TxtNombre" runat="server"></asp:TextBox>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="Label3" runat="server" Text="Correo:"></asp:Label>
&nbsp;
        <asp:TextBox ID="TxtCorreo" runat="server"></asp:TextBox>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="Label4" runat="server" Text="Cargo:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DDCargo" runat="server">
        </asp:DropDownList>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" Text="Ingresar" />
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="LabelError" runat="server" ForeColor="Red"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:GridView ID="GridTripulantes" runat="server">
        </asp:GridView>
    </p>
    <p>
        &nbsp;</p>
    <p>
        Cantidad de tripulantes registrados :
        <asp:Label ID="TotalTripulantes" runat="server"></asp:Label>
    </p>
    <p>
        Cantidad por tipo:</p>
    <p>
        &nbsp;<asp:GridView ID="GridTipoTripulante" runat="server">
        </asp:GridView>
    </p>
    <p>
        &nbsp;</p>
</asp:Content>
