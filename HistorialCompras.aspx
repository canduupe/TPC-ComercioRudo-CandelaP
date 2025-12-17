<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HistorialCompras.aspx.cs" Inherits="TPC_ComercioRudo_CandelaP.HistorialCompras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView
    ID="dgvCompras"
    runat="server"
    CssClass="table table-striped"
    AutoGenerateColumns="false">

    <Columns>
        <asp:BoundField DataField="proveedor.nombre" HeaderText="Proveedor" />
        <asp:BoundField DataField="producto.nombre" HeaderText="Producto" />
        <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
        <asp:BoundField DataField="precio" HeaderText="Precio Compra" />
        <asp:BoundField DataField="ganancia" HeaderText="Ganancia" />
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
