<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HistorialVentas.aspx.cs" Inherits="TPC_ComercioRudo_CandelaP.HistorialVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView
        ID="dgvVentas"
        runat="server"
        CssClass="table table-striped"
        AutoGenerateColumns="false"
        DataKeyNames="id"
        OnRowCommand="dgvVentas_RowCommand">

        <Columns>
            <asp:BoundField DataField="NroFactura" HeaderText="Factura" />
            <asp:BoundField DataField="Cliente.Apellido" HeaderText="Cliente" />
            <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="Total" HeaderText="Total" DataFormatString="$ {0:N2}" />

            <asp:ButtonField
                Text="Ver detalle"
                CommandName="VerDetalle"
                ButtonType="Button"
                ControlStyle-CssClass="btn btn-info btn-sm" />
        </Columns>
    </asp:GridView>

    <asp:Panel ID="pnlDetalleVenta" runat="server" Visible="false" CssClass="mt-4">

        <h5>Detalle de la venta</h5>

        <asp:GridView ID="dgvDetalleVenta" runat="server"
            AutoGenerateColumns="false"
            CssClass="table table-sm table-striped">

            <Columns>
                <asp:BoundField DataField="producto.nombre" HeaderText="Producto" />
                <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="precioUnitario" HeaderText="Precio" DataFormatString="{0:C}" />
                <asp:BoundField DataField="subtotal" HeaderText="Subtotal" DataFormatString="{0:C}" />
            </Columns>
        </asp:GridView>

    </asp:Panel>
    <div>
        <asp:Button
            ID="btnVolver"
            runat="server"
            Text="Volver"
            CssClass="btn btn-outline-secondary me-2"
            OnClick="btnVolver_Click" />
    </div>

</asp:Content>
