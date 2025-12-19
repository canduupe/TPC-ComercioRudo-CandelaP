<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PanelAdmin.aspx.cs" Inherits="TPC_ComercioRudo_CandelaP.PanelAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4">

        <div class="card shadow-sm">
            <div class="card-body">

                <h3 class="mb-3">Panel de Administración</h3>
                <p class="text-muted">Gestión general del sistema</p>

                <hr />

                <div class="row g-3">

                    <div class="col-md-4">
                        <div class="card h-100 shadow-sm">
                            <div class="card-body text-center">
                                <h5 class="card-title">Clientes</h5>
                                <p class="card-text">Administrar clientes</p>
                                <asp:Button runat="server" Text="Gestionar"
                                    CssClass="btn btn-primary"
                                    PostBackUrl="~/Clientes.aspx" />
                            </div>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="card h-100 shadow-sm">
                            <div class="card-body text-center">
                                <h5 class="card-title">Proveedores</h5>
                                <p class="card-text">Administrar proveedores</p>
                                <asp:Button runat="server" Text="Gestionar"
                                    CssClass="btn btn-primary"
                                    PostBackUrl="~/Proveedores.aspx" />
                            </div>
                        </div>
                    </div>  

                    <div class="col-md-4">
                        <div class="card h-100 shadow-sm">
                            <div class="card-body text-center">
                                <h5 class="card-title">Productos</h5>
                                <p class="card-text">Administrar productos</p>
                                <asp:Button runat="server" Text="Gestionar"
                                    CssClass="btn btn-primary"
                                    PostBackUrl="~/Productos.aspx" />
                            </div>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="card h-100 shadow-sm">
                            <div class="card-body text-center">
                                <h5 class="card-title">Marcas</h5>
                                <p class="card-text">Administrar marcas</p>
                                <asp:Button runat="server" Text="Gestionar"
                                    CssClass="btn btn-primary"
                                    PostBackUrl="~/Marcas.aspx" />
                            </div>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="card h-100 shadow-sm">
                            <div class="card-body text-center">
                                <h5 class="card-title">Categorías</h5>
                                <p class="card-text">Administrar categorías</p>
                                <asp:Button runat="server" Text="Gestionar"
                                    CssClass="btn btn-primary"
                                    PostBackUrl="~/Categorias.aspx" />
                            </div>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="card h-100 shadow-sm">
                            <div class="card-body text-center">
                                <h5 class="card-title">Ventas</h5>
                                <p class="card-text">Ver ventas realizadas</p>
                                <asp:Button runat="server" Text="Ver"
                                    CssClass="btn btn-success"
                                    PostBackUrl="~/HistorialVentas.aspx" />
                            </div>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="card h-100 shadow-sm">
                            <div class="card-body text-center">
                                <h5 class="card-title">Compras</h5>
                                <p class="card-text">Ver compras realizadas</p>
                                <asp:Button runat="server" Text="Ver"
                                    CssClass="btn btn-success"
                                    PostBackUrl="~/HistorialCompras.aspx" />
                            </div>
                        </div>
                    </div>

                </div>

            </div>
        </div>

    </div>

</asp:Content>
