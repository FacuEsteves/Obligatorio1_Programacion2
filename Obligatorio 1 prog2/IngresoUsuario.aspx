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
    <p>
        Ingresar Cargos:<asp:CheckBox ID="CheckBox2" runat="server" />
</p>
<p>
        Ingresar Tripulantes:<asp:CheckBox ID="CheckBox3" runat="server" />
</p>
<p>
        Ingresar Encargados:<asp:CheckBox ID="CheckBox4" runat="server" />
</p>
<p>
        Ingresar Mantenimiento:
        <asp:CheckBox ID="CheckBox5" runat="server" />
</p>
<p>
        Ingresar Tipo de Mantenimiento:<asp:CheckBox ID="CheckBox6" runat="server" />
</p>
<p>
        Ingreso Usuario:<asp:CheckBox ID="CheckBox7" runat="server" />
</p>
<p>
        Registro Barcos:<asp:CheckBox ID="CheckBox8" runat="server" />
</p>
<p>
        Historial Mantenimientos:<asp:CheckBox ID="CheckBox9" runat="server" />
</p>
<p>
        &nbsp;</p>
    <p>
        <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" />
    </p>
    <p>
        <asp:Label ID="LabelError" runat="server" ForeColor="#FF3300"></asp:Label>
    </p>
    <p>
        <asp:GridView ID="GridUsuario" runat="server" AutoGenerateColumns="False" Width="200px">
            <Columns>
                <asp:BoundField DataField="nombreUsuario" HeaderText="Usuario" />
            </Columns>
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
