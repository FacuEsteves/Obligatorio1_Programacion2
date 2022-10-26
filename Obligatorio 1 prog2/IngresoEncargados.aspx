<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IngresoEncargados.aspx.cs" Inherits="Obligatorio_1_prog2.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        Cedula :
        <asp:TextBox ID="TxtCedula" runat="server"></asp:TextBox>
    </p>
    <p>
        Nombre :
        <asp:TextBox ID="TxtNombre" runat="server"></asp:TextBox>
    </p>
    <p>
        Correo :
        <asp:TextBox ID="TxtCorreo" runat="server"></asp:TextBox>
    </p>
    <p>
        Cantidad de personas a cargo : <asp:TextBox ID="TxtCantPersonas" runat="server"></asp:TextBox>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="LabelError" runat="server" ForeColor="Red"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="BtnIngresar" runat="server" OnClick="BtnIngresar_Click" Text="Ingresar" />
        <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" OnClick="BtnBuscar_Click" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:GridView ID="GridEncargados" runat="server">
        </asp:GridView>
    </p>
</asp:Content>
