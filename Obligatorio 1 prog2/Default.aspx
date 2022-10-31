<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Obligatorio_1_prog2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" type="text/css" href="Diseño/InicioSesion.css" />

    <div class="Inicio">
        <h1>Bienvenido:</h1>
        <div class="campos">
            <p>
                <asp:Label ID="Label1" runat="server" Text="Usuario: "></asp:Label>
                <asp:TextBox ID="txtUsuario" runat="server" class="form-control"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label2" runat="server" Text="Contraseña: "></asp:Label>
                <asp:TextBox ID="txtContraseña" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
            </p>
         </div>
            <p class="error">
                <asp:Label ID="LabelError" runat="server" ForeColor="Red"></asp:Label>
            </p>
            <p class="boton">
                <asp:Button ID="btnIniciar" runat="server"  class="btn-primary" Text="Iniciar Sesion" OnClick="btnIniciar_Click" Height="40px" Width="150px" />
            </p>
    </div>

    <div class="row">
        <div class="col-md-4">
        </div>
    </div>

</asp:Content>
