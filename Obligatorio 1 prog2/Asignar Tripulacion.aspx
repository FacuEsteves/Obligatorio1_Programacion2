<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Asignar Tripulacion.aspx.cs" Inherits="Obligatorio_1_prog2.Asignar_Tripulacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
    </p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Nombre Barco"></asp:Label>
    </p>
    <p>
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
    </p>
    <p>
        <asp:Label ID="LabelError" runat="server"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:GridView ID="GridAsignar" runat="server" AutoGenerateColumns="False" OnRowCommand="GridAsignar_RowCommand">
            <Columns>
                <asp:BoundField DataField="cedula" HeaderText="Cedula" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Cargo" HeaderText="Cargo" />
                <asp:ButtonField ButtonType="Button" CommandName="Asignar" Text="Botón" />
            </Columns>
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
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
    </p>
</asp:Content>
