<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IngresoTipoMantenimiento.aspx.cs" Inherits="Obligatorio_1_prog2.IngresoTipoMantenimiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    Codigo :
    <asp:TextBox ID="TxtCodigo" runat="server"></asp:TextBox>
</p>
<p>
    Precio base :
    <asp:TextBox ID="TxtPrecioBase" runat="server"></asp:TextBox>
</p>
<p>
    Descripción :
    <asp:TextBox ID="TxtDescripcion" runat="server"></asp:TextBox>
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
</p>
<p>
    &nbsp;</p>
<p>
    <asp:GridView ID="GridTiposMantenimiento" runat="server">
    </asp:GridView>
</p>
</asp:Content>
