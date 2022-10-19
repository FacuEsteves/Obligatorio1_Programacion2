<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Asignar Tripulacion.aspx.cs" Inherits="Obligatorio_1_prog2.Asignar_Tripulacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
    </p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Nombre Barco"></asp:Label>
    </p>
    <p>
        <asp:DropDownList ID="DD_Barcos" runat="server">
        </asp:DropDownList>
    </p>
    <p>
        <asp:Label ID="LabelError" runat="server" ForeColor="Red"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
        <asp:GridView ID="GridAsignar" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridAsignar_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="cedula" HeaderText="Cedula" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Cargo" HeaderText="Cargo" />
            </Columns>
        </asp:GridView>
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
