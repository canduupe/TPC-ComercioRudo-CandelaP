<%@ Page Title="Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Productos.aspx.cs" Inherits="TPC_ComercioRudo_CandelaP.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4">

        <div class="card shadow-sm">
            <div class="card-body">

                <div class="d-flex justify-content-between align-items-center mb-3">

                    <div>
                        <h3 class="mb-0">Lista de productos</h3>
                        <asp:Label
                            ID="lblCliente"
                            runat="server"
                            CssClass="text-muted small">
                        </asp:Label>
                    </div>

                    <asp:Button
                        ID="btnNuevo"
                        runat="server"
                        Text="Nuevo producto"
                        CssClass="btn btn-success"
                        OnClick="btnNuevo_Click" />
                </div>

                <hr />

                <asp:GridView
                    ID="dgvProductos"
                    runat="server"
                    CssClass="table table-striped table-hover table-bordered align-middle"
                    HeaderStyle-CssClass="table-dark"
                    AutoGenerateColumns="false"
                    DataKeyNames="id"
                    OnRowCommand="dgvProductos_RowCommand">

                    <Columns>
                        <asp:BoundField DataField="nombre" HeaderText="Producto" />
                        <asp:BoundField DataField="descripcion" HeaderText="Descripción" />
                        <asp:BoundField
                            DataField="precio"
                            HeaderText="Precio"
                            DataFormatString="{0:C}" />
                        <asp:BoundField DataField="Proveedor.nombre" HeaderText="Proveedor" />
                        <asp:BoundField DataField="Marca.nombre" HeaderText="Marca" />
                        <asp:BoundField DataField="Categoria.nombre" HeaderText="Categoría" />
                        <asp:BoundField DataField="stockActual" HeaderText="Stock actual" />
                        <asp:BoundField DataField="stockMinimo" HeaderText="Stock mínimo" />
                        
                        <asp:ButtonField
                            Text="Editar"
                            CommandName="Editar"
                            ButtonType="Button"
                            ControlStyle-CssClass="btn btn-primary btn-sm" />

                        <asp:ButtonField
                            Text="Eliminar"
                            CommandName="Eliminar"
                            ButtonType="Button"
                            ControlStyle-CssClass="btn btn-danger btn-sm" />

                    </Columns>

                </asp:GridView>

                <asp:Panel ID="pnlFormulario" runat="server" Visible="false" CssClass="mt-4">

                    <h5>Producto</h5>
                    <asp:HiddenField ID="hfIdProducto" runat="server" />

                    <div class="row mb-2">
                        <div class="col-md-6">
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Placeholder="Nombre" />
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" Placeholder="Precio" />
                        </div>
                    </div>

                    <div class="row mb-2">
                        <div class="col-md-6">
                            <asp:TextBox ID="txtStockActual" runat="server" CssClass="form-control" Placeholder="Stock actual" />
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtStockMinimo" runat="server" CssClass="form-control" Placeholder="Stock mínimo" />
                        </div>
                    </div>
                    <div class="row mb-2">
                        <div class="col-md-6">
                            <asp:TextBox ID="txtDescripcion" runat="server"
                                CssClass="form-control" Placeholder="Descripción" />
                        </div>
                        <div class="col-md-3">
                            <asp:DropDownList
                                ID="ddlMarca"
                                runat="server"
                                CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-3">
                            <asp:DropDownList
                                ID="ddlCategoria"
                                runat="server"
                                CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-3">
                            <asp:DropDownList
                                ID="ddlProveedor"
                                runat="server"
                                CssClass="form-control">
                            </asp:DropDownList>
                        </div>                    
                    </div>


                    <div class="mt-3">
                        <asp:Button
                            ID="btnGuardar"
                            runat="server"
                            Text="Guardar"
                            CssClass="btn btn-primary"
                            OnClick="btnGuardar_Click" />

                        <asp:Button
                            ID="btnCancelar"
                            runat="server"
                            Text="Cancelar"
                            CssClass="btn btn-secondary ms-2"
                            OnClick="btnCancelar_Click" />
                    </div>

                </asp:Panel>
                <div>
                    <asp:Button
                        ID="btnVolver"
                        runat="server"
                        Text="Volver"
                        CssClass="btn btn-outline-secondary me-2"
                        OnClick="btnVolver_Click" />
                </div>
            </div>
        </div>

    </div>

</asp:Content>
