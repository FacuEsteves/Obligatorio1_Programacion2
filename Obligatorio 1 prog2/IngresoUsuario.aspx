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
        Nombre:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
    </p>
    <p>
        Cedula:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtCedula" runat="server"></asp:TextBox>
    </p>
    <p>
        ID Usuario:&nbsp;&nbsp;
        <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
    </p>
    <p>
        Contraseña:
        <asp:TextBox ID="txtContraseña" runat="server"></asp:TextBox>
    </p>
    <p>
        Correo:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
    </p>
    <p>
        &nbsp;</p>
    <p>
        Permisos:</p>
    <p>
        <asp:CheckBoxList ID="CBpermisos" runat="server">
            <asp:ListItem Value="AsignarTripulación">Asignar Tripulación</asp:ListItem>
            <asp:ListItem Value="Busqueda de mantenimientos">Busqueda de mantenimientos</asp:ListItem>
            <asp:ListItem>Ingresar cargos</asp:ListItem>
            <asp:ListItem>Ingresar Tripulantes</asp:ListItem>
            <asp:ListItem>Ingresar Encargados</asp:ListItem>
            <asp:ListItem>Ingresar Mantenimientos</asp:ListItem>
            <asp:ListItem>Ingresar Usuarios</asp:ListItem>
            <asp:ListItem>Registro Barco</asp:ListItem>
        </asp:CheckBoxList>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    </p>
    <p>
        <asp:Label ID="LabelError" runat="server" ForeColor="#FF3300"></asp:Label>
    </p>
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
