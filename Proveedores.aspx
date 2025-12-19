<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="TPC_ComercioRudo_CandelaP.Proveedores" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4">

        <div class="card shadow-sm">
            <div class="card-body">
                <div class="d-flex justify-content-between align-items-center mb-3">
                    <h3 class="mb-0">Proveedores</h3>

                    <asp:Button
                        ID="btnNuevo"
                        runat="server"
                        Text="Nuevo proveedor"
                        CssClass="btn btn-success"
                        OnClick="btnNuevo_Click" />
                </div>
                <hr />

                <asp:GridView
                    ID="dgvProveedores"
                    runat="server"
                    CssClass="table table-striped table-hover table-bordered align-middle"
                    HeaderStyle-CssClass="table-dark"
                    AutoGenerateColumns="false"
                    DataKeyNames="id"
                    OnRowCommand="dgvProveedores_RowCommand">

                    <Columns>

                        <asp:BoundField DataField="nombre" HeaderText="Proveedor" />
                        <asp:BoundField DataField="marca.nombre" HeaderText="Marca" />
                        <asp:BoundField DataField="categoria.nombre" HeaderText="Categoría" />

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

                <asp:Panel
                    ID="pnlFormulario"
                    runat="server"
                    Visible="false"
                    CssClass="mt-4">

                    <h5 class="mb-3">Proveedor</h5>

                    <asp:HiddenField ID="hfIdProveedor" runat="server" />

                    <div class="row mb-3">
                        <div class="col-md-6">
                            <asp:TextBox
                                ID="txtNombre"
                                runat="server"
                                CssClass="form-control"
                                Placeholder="Nombre del proveedor" />
                        </div>
                    </div>

                    <div class="row mb-3">
                        <div class="col-md-6">
                            <asp:Label runat="server" Text="Marca" CssClass="form-label" />
                            <asp:DropDownList
                                ID="ddlMarca"
                                runat="server"
                                CssClass="form-select">
                            </asp:DropDownList>
                        </div>

                        <div class="col-md-6">
                            <asp:Label runat="server" Text="Categoría" CssClass="form-label" />
                            <asp:DropDownList
                                ID="ddlCategoria"
                                runat="server"
                                CssClass="form-select">
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
            </div>
        </div>
        <div>
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
</asp:Content>
