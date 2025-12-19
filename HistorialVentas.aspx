<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HistorialVentas.aspx.cs" Inherits="TPC_ComercioRudo_CandelaP.HistorialVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView
        ID="dgvVentas"
        runat="server"
        CssClass="table table-striped"
        AutoGenerateColumns="false">

        <Columns>
            <asp:BoundField DataField="NroFactura" HeaderText="Factura" />
            <asp:BoundField DataField="Cliente.Apellido" HeaderText="Cliente" />
            <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="Total" HeaderText="Total" DataFormatString="$ {0:N2}" />
        </Columns>
    </asp:GridView>

    <div>
        <asp:Button
            ID="btnVolver"
            runat="server"
            Text="Volver"
            CssClass="btn btn-outline-secondary me-2"
            OnClick="btnVolver_Click" />
    </div>

</asp:Content>
