<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IngresoMantenimiento.aspx.cs" Inherits="Obligatorio_1_prog2.IngresoMantenimiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        Fecha de mantenimeinto :&nbsp;
        <asp:Calendar ID="CalendarDate" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
            <NextPrevStyle VerticalAlign="Bottom" />
            <OtherMonthDayStyle ForeColor="#808080" />
            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
            <SelectorStyle BackColor="#CCCCCC" />
            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
            <WeekendDayStyle BackColor="#FFFFCC" />
        </asp:Calendar>
    </p>
    <p>
        Descripción : <asp:TextBox ID="TxtDescripcion" runat="server"></asp:TextBox>
    </p>
    <p>
        Barco :
        <asp:DropDownList ID="DD_Barco" runat="server">
        </asp:DropDownList>
    </p>
    <p>
        Tipo de mantenimiento :
        <asp:DropDownList ID="DD_TipoM" runat="server">
        </asp:DropDownList>
    </p>
    <p>
        Encargado responsable :
        <asp:DropDownList ID="DD_Encargado" runat="server">
        </asp:DropDownList>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="LabelError" runat="server" ForeColor="Red"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" OnClick="BtnGuardar_Click" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:GridView ID="GridMantenimientos" runat="server">
        </asp:GridView>
    </p>
</asp:Content>
