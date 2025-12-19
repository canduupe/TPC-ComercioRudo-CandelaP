<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Vendedores.aspx.cs" Inherits="TPC_ComercioRudo_CandelaP.Vendedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div class="container mt-4">

    <asp:Panel ID="pnlListado" runat="server">
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
                        <h3 class="mb-0">Vendedores</h3>
                        <p class="text-muted small">Administración de vendedores</p>
                    </div>
                    <asp:Button ID="btnNuevo" runat="server"
                        Text="Nuevo vendedor"
                        CssClass="btn btn-success"
                        OnClick="btnNuevo_Click" />
                </div>

                <asp:GridView ID="dgvVendedores" runat="server"
                    CssClass="table table-striped table-hover table-bordered align-middle"
                    HeaderStyle-CssClass="table-dark"
                    AutoGenerateColumns="false"
                    DataKeyNames="id"
                    OnRowCommand="dgvVendedores_RowCommand">

                    <Columns>
                        <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="usuario.usuario" HeaderText="Usuario" />
                        <asp:BoundField DataField="usuario.contraseña" HeaderText="Contraseña" />

                        <asp:ButtonField CommandName="Editar" Text="Editar"
                            ButtonType="Button"
                            ControlStyle-CssClass="btn btn-primary btn-sm" />

                        <asp:ButtonField CommandName="Eliminar" Text="Eliminar"
                            ButtonType="Button"
                            ControlStyle-CssClass="btn btn-danger btn-sm" />
                    </Columns>

                </asp:GridView>

            </div>
        </div>
    </asp:Panel>

    <asp:Panel ID="pnlVendedor" runat="server" Visible="false" CssClass="mt-4">
        <div class="card shadow-sm">
            <div class="card-body">

                <h4 class="mb-3">Vendedor</h4>

                <asp:HiddenField ID="hfIdVendedor" runat="server" />
                <asp:HiddenField ID="hfIdUsuario" runat="server" />

                <div class="row">
                    <div class="col-md-6 mb-3">
                        <label>Nombre</label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                    </div>

                    <div class="col-md-6 mb-3">
                        <label>Apellido</label>
                        <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" />
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-6 mb-3">
                        <label>Usuario</label>
                        <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" />
                    </div>

                    <div class="col-md-6 mb-3">
                        <label>Contraseña</label>
                        <asp:TextBox ID="txtContraseña" runat="server"
                            CssClass="form-control"
                            TextMode="Password" />
                    </div>
                </div>

                <div class="mt-3">
                    <asp:Button ID="btnGuardar" runat="server"
                        Text="Guardar"
                        CssClass="btn btn-primary"
                        OnClick="btnGuardar_Click" />

                    <asp:Button ID="btnCancelar" runat="server"
                        Text="Cancelar"
                        CssClass="btn btn-secondary ms-2"
                        OnClick="btnCancelar_Click" />

                    <asp:Button ID="btnVolver" runat="server"
                        Text="Volver"
                        CssClass="btn btn-outline-dark ms-2"
                        OnClick="btnVolver_Click" />
                </div>

            </div>
        </div>
    </asp:Panel>
    <div class="mt-3">
        <asp:Button
            ID="Volver"
            runat="server"
            Text="Volver"
            CssClass="btn btn-outline-secondary"
            OnClick="Volver_Click" />
    </div>
    </div>

</asp:Content>