<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarVenta.aspx.cs" Inherits="TPC_ComercioRudo_CandelaP.AgregarVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4">

        <div class="card shadow-sm">
            <div class="card-body">

                <asp:Label
                    ID="lblMensaje"
                    runat="server"
                    Visible="false"
                    CssClass="alert"
                    EnableViewState="false" />

                <div class="d-flex justify-content-between align-items-center mb-3">
                    <div>
                        <h3 class="mb-0">Ventas</h3>
                        <p class="text-muted small">Registro de ventas</p>
                    </div>
                    <asp:Button
                        ID="btnNuevaVenta"
                        runat="server"
                        Text="Nueva venta"
                        CssClass="btn btn-success"
                        OnClick="btnNuevaVenta_Click" />
                </div>

                <hr />

                <asp:GridView
                    ID="dgvVentas"
                    runat="server"
                    CssClass="table table-striped table-hover table-bordered align-middle"
                    HeaderStyle-CssClass="table-dark"
                    AutoGenerateColumns="false"
                    DataKeyNames="id"
                    OnRowCommand="dgvVentas_RowCommand">

                    <Columns>
                        <asp:BoundField DataField="nroFactura" HeaderText="Factura" />
                         <asp:BoundField DataField="Cliente.Apellido" HeaderText="Cliente" />
                        <asp:BoundField DataField="fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="total" HeaderText="Total" DataFormatString="$ {0:N2}" />

                        <asp:ButtonField
                            Text="Ver detalle"
                            CommandName="VerDetalle"
                            ButtonType="Button"
                            ControlStyle-CssClass="btn btn-info btn-sm" />
                    </Columns>
                </asp:GridView>

                <asp:Panel ID="pnlVenta" runat="server" Visible="false" CssClass="mt-4">

                    <h5 class="mb-3">Nueva venta</h5>

                    <div class="row mb-3">
                        <div class="col-md-6">
                            <label class="form-label">Cliente</label>
                            <asp:DropDownList ID="ddlClientes" runat="server" CssClass="form-select" />
                        </div>
                    </div>

                    <div class="row mb-2">
                        <div class="col-md-5">
                            <label class="form-label">Producto</label>
                            <asp:DropDownList ID="ddlProductos" runat="server" CssClass="form-select" />
                        </div>

                        <div class="col-md-3">
                            <label class="form-label">Cantidad</label>
                            <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" />
                        </div>

                        <div class="col-md-4 d-flex align-items-end">
                            <asp:Button
                                ID="btnAgregarProducto"
                                runat="server"
                                Text="Agregar producto"
                                CssClass="btn btn-primary w-100"
                                OnClick="btnAgregarProducto_Click" />
                        </div>
                    </div>

                    <asp:GridView
                        ID="dgvDetalle"
                        runat="server"
                        CssClass="table table-bordered table-hover mt-3"
                        AutoGenerateColumns="false"
                        EnableViewState="false">

                        <Columns>
                            <asp:BoundField DataField="producto.nombre" HeaderText="Producto" />
                            <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                            <asp:BoundField DataField="precioUnitario" HeaderText="Precio" DataFormatString="$ {0:N2}" />
                            <asp:BoundField DataField="subtotal" HeaderText="Subtotal" DataFormatString="$ {0:N2}" />
                        </Columns>
                    </asp:GridView>

                    <div class="mt-3 d-flex justify-content-end">
                        <asp:Button
                            ID="btnConfirmar"
                            runat="server"
                            Text="Confirmar venta"
                            CssClass="btn btn-success me-2"
                            OnClick="btnConfirmar_Click" />
                        <asp:Button
                            ID="btnCancelar"
                            runat="server"
                            Text="Cancelar"
                            CssClass="btn btn-secondary"
                            OnClick="btnCancelar_Click" />
                    </div>

                </asp:Panel>

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

                <div class="mt-3">
                    <asp:Button
                        ID="btnVolver"
                        runat="server"
                        Text="Volver"
                        CssClass="btn btn-outline-secondary"
                        OnClick="btnVolver_Click" />
                </div>

            </div>
        </div>

    </div>

</asp:Content>