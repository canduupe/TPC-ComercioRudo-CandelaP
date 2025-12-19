<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="TPC_ComercioRudo_CandelaP.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4">

        <div class="card shadow-sm">
            <div class="card-body">

                <div class="d-flex justify-content-between align-items-center mb-3">
                    <div>
                        <h3 class="mb-0">Clientes</h3>
                    </div>

                    <div>
                        <asp:Button
                            ID="btnNuevo"
                            runat="server"
                            Text="Nuevo cliente"
                            CssClass="btn btn-success"
                            OnClick="btnNuevo_Click" />
                    </div>
                </div>

                <hr />

                <asp:GridView
                    ID="dgvClientes"
                    runat="server"
                    CssClass="table table-striped table-hover table-bordered align-middle"
                    HeaderStyle-CssClass="table-dark"
                    AutoGenerateColumns="false"
                    DataKeyNames="id"
                    OnRowCommand="dgvClientes_RowCommand">

                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="DNI" HeaderText="DNI" />
                        <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="Direccion" HeaderText="Direccion" />

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

                    <h5 class="mb-3">Cliente</h5>

                    <asp:HiddenField ID="hfIdCliente" runat="server" />

                    <div class="row mb-2">
                        <div class="col-md-6">
                            <asp:TextBox
                                ID="txtNombre"
                                runat="server"
                                CssClass="form-control"
                                Placeholder="Nombre" />
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox
                                ID="txtApellido"
                                runat="server"
                                CssClass="form-control"
                                Placeholder="Apellido" />
                        </div>
                    </div>

                    <div class="row mb-2">
                        <div class="col-md-6">
                            <asp:TextBox
                                ID="txtDNI"
                                runat="server"
                                CssClass="form-control"
                                Placeholder="DNI" />
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox
                                ID="txtTelefono"
                                runat="server"
                                CssClass="form-control"
                                Placeholder="Teléfono" />
                        </div>
                    </div>

                    <div class="row mb-2">
                        <div class="col-md-6">
                            <asp:TextBox
                                ID="txtEmail"
                                runat="server"
                                CssClass="form-control"
                                Placeholder="Email" />
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox
                                ID="txtDireccion"
                                runat="server"
                                CssClass="form-control"
                                Placeholder="Dirección" />
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

