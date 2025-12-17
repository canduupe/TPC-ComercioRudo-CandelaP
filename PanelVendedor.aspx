<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PanelVendedor.aspx.cs" Inherits="TPC_ComercioRudo_CandelaP.PanelVendedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4">

        <div class="card shadow">
            <div class="card-body">

                <h3 class="mb-1">Panel de Vendedor</h3>
                <p class="text-muted mb-4">Gestión de ventas y clientes</p>

                <div class="row g-3">

                    <div class="col-md-6 col-lg-4">
                        <div class="card h-100 shadow-sm text-center">
                            <div class="card-body">
                                <h5 class="card-title">Nueva Venta</h5>
                                <p class="card-text">Registrar una venta</p>
                                <asp:Button
                                    ID="btnVenta"
                                    runat="server"
                                    Text="Ir"
                                    CssClass="btn btn-primary"
                                    OnClick="btnVenta_Click" />
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6 col-lg-4">
                        <div class="card h-100 shadow-sm text-center">
                            <div class="card-body">
                                <h5 class="card-title">Nueva Compra</h5>
                                <p class="card-text">Registrar una compra</p>
                                <asp:Button
                                    ID="btnCompra"
                                    runat="server"
                                    Text="Ir"
                                    CssClass="btn btn-primary"
                                    OnClick="btnCompra_Click" />
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6 col-lg-4">
                        <div class="card h-100 shadow-sm text-center">
                            <div class="card-body">
                                <h5 class="card-title">Clientes</h5>
                                <p class="card-text">Ver y buscar clientes</p>
                                <asp:Button
                                    ID="btnClientes"
                                    runat="server"
                                    Text="Ir"
                                    CssClass="btn btn-success"
                                    OnClick="btnClientes_Click" />
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6 col-lg-4">
                        <div class="card h-100 shadow-sm text-center">
                            <div class="card-body">
                                <h5 class="card-title">Productos</h5>
                                <p class="card-text">Consultar stock</p>
                                <asp:Button
                                    ID="btnProductos"
                                    runat="server"
                                    Text="Ir"
                                    CssClass="btn btn-info"
                                    OnClick="btnProductos_Click" />
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6 col-lg-4">
                        <div class="card h-100 shadow-sm text-center">
                            <div class="card-body">
                                <h5 class="card-title">Mis Ventas</h5>
                                <p class="card-text">Historial de ventas</p>
                                <asp:Button
                                    ID="btnMisVentas"
                                    runat="server"
                                    Text="Ir"
                                    CssClass="btn btn-warning"
                                    OnClick="btnMisVentas_Click" />
                            </div>
                        </div>
                    </div>

                </div>

            </div>
        </div>

    </div>

</asp:Content>

