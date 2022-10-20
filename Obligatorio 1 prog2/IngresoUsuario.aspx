<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IngresoUsuario.aspx.cs" Inherits="Obligatorio_1_prog2.IngresoUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
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
        Nombre:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
    </p>
    <p>
        &nbsp;</p>
    <p>
        Cedula:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtCedula" runat="server"></asp:TextBox>
    </p>
    <p>
    </p>
    <p>
        ID Usuario:&nbsp;&nbsp;
        <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
    </p>
    <p>
        &nbsp;</p>
    <p>
        Contraseña:
        <asp:TextBox ID="txtContraseña" runat="server"></asp:TextBox>
    </p>
    <p>
        &nbsp;</p>
    <p>
        Correo:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:GridView ID="GridUsuario" runat="server">
        </asp:GridView>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
