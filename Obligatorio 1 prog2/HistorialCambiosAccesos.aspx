<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HistorialCambiosAccesos.aspx.cs" Inherits="Obligatorio_1_prog2.HistorialCambiosAccesos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Diseño/General.css" />
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        Fecha:
        <asp:TextBox ID="TxtFecha" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
&nbsp;Usuario:
        <asp:DropDownList ID="DD_Usuarios" class="form-select" runat="server" AppendDataBoundItems="True">
            <asp:ListItem>(Seleccionar)</asp:ListItem>
        </asp:DropDownList>
&nbsp;Cambio realizado:
        <asp:DropDownList ID="DD_Cambios" class="form-select" runat="server">
            <asp:ListItem>(Seleccionar)</asp:ListItem>
            <asp:ListItem>Asignar tripulación</asp:ListItem>
            <asp:ListItem>Ingresar cargo</asp:ListItem>
            <asp:ListItem>Ingreso tripulantes</asp:ListItem>
            <asp:ListItem>Ingreso encargados</asp:ListItem>
            <asp:ListItem>Ingreso mantenimientos</asp:ListItem>
            <asp:ListItem>Ingreso tipo mantenimiento</asp:ListItem>
            <asp:ListItem>Ingreso usuarios</asp:ListItem>
            <asp:ListItem>Registro barco</asp:ListItem>
            <asp:ListItem>Borrar asignado</asp:ListItem>
            <asp:ListItem>Borrar cargo</asp:ListItem>
            <asp:ListItem>Borrar tripulantes</asp:ListItem>
            <asp:ListItem>Borrar encargado</asp:ListItem>
            <asp:ListItem>Mantenimiento terminado</asp:ListItem>
            <asp:ListItem>Borrar tipo de mantenimiento</asp:ListItem>
            <asp:ListItem>Borrar usuario</asp:ListItem>
            <asp:ListItem>Borrar barco</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
    </p>
    <p>
        <asp:Button ID="BtnBuscar" class="btn-success" runat="server" OnClick="BtnBuscar_Click" Text="Buscar" />
        <asp:Button ID="BtnBorrar" class="btn-danger" runat="server" OnClick="BtnBorrar_Click" Text="Borrar filtros" />
    </p>
    <h3>
        Accesos</h3>
    <p>
        <asp:GridView ID="GridAccesos" class="table table-primary" runat="server" AutoGenerateColumns="False" Width="333px" >
            <Columns>
                <asp:BoundField DataField="usuarios" HeaderText="Usuario" />
                <asp:BoundField DataField="fechaAcceso" HeaderText="Fecha acceso" />
            </Columns>
        </asp:GridView>
    </p>
    <h3>
        Egresos</h3>
    <p>
        <asp:GridView ID="GridEgresos" class="table table-danger" runat="server" AutoGenerateColumns="False" Width="333px">
            <Columns>
                <asp:BoundField DataField="usuarios" HeaderText="Usuario" />
                <asp:BoundField DataField="fechaEgreso" HeaderText="Fecha egreso" />
            </Columns>
        </asp:GridView>
    </p>
    <h3>
        Cambios en el sistema</h3>
    <p>
        <asp:GridView ID="GridCambios" class="table table-success" runat="server" AutoGenerateColumns="False"  Width="500px">
            <Columns>
                <asp:BoundField DataField="usuarios" HeaderText="Usuario" />
                <asp:BoundField DataField="fechaCambio" HeaderText="Fecha cambio" />
                <asp:BoundField DataField="descripcion" HeaderText="Descripción" />
            </Columns>
        </asp:GridView>
    </p>
</asp:Content>
