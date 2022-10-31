﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Asignar Tripulacion.aspx.cs" Inherits="Obligatorio_1_prog2.Asignar_Tripulacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Diseño/General.css" />
    <p>
        <br />
    </p>
    <p>
        &nbsp;</p>
        <h3><asp:Label ID="Label1" runat="server" Text="Nombre Barco"></asp:Label></h3>
    <p>
        <asp:DropDownList ID="DD_Barcos" class="form-select" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DD_Barcos_SelectedIndexChanged" AppendDataBoundItems="True">
            <asp:ListItem>(Seleccionar)</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        <asp:Label ID="LabelError" runat="server" ForeColor="Red"></asp:Label>
    </p>
        <h3>Tripulantes sin asignar</h3>
        <div class="orden">
            <asp:GridView ID="GridAsignar" class="table table-striped table-hover" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridAsignar_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="cedula" HeaderText="Cedula" />
                    <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Cargo" HeaderText="Cargo" />
                </Columns>
            </asp:GridView>
        </div>
        <p>
        &nbsp;</p>
        <h3>Tripulantes asignados a el barco seleccionado</h3>
    <div class="oreden">
        <asp:GridView ID="GridAsignados" class="table table-striped table-success table-hover" runat="server" AutoGenerateDeleteButton="True"  OnRowDeleting="GridAsignados_RowDeleting">
        </asp:GridView>
    </div>
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
