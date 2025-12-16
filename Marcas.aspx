<%@ Page Title="Marcas" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Marcas.aspx.cs"
    Inherits="TPC_ComercioRudo_CandelaP.Marcas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4">

        <div class="card shadow-sm">
            <div class="card-body">

                <div class="d-flex justify-content-between align-items-center mb-3">
                    <h3 class="mb-0">Marcas</h3>

                    <asp:Button
                        ID="btnNuevo"
                        runat="server"
                        Text="Nueva marca"
                        CssClass="btn btn-success"
                        OnClick="btnNuevo_Click" />
                </div>

                <hr />

                <asp:GridView
                    ID="dgvMarcas"
                    runat="server"
                    CssClass="table table-striped table-hover table-bordered"
                    HeaderStyle-CssClass="table-dark"
                    AutoGenerateColumns="false"
                    DataKeyNames="id"
                    OnRowCommand="dgvMarcas_RowCommand">

                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="ID" />
                        <asp:BoundField DataField="nombre" HeaderText="Marca" />

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

                    <h5>Marca</h5>
                    <asp:HiddenField ID="hfIdMarca" runat="server" />

                    <div class="mb-3">
                        <asp:TextBox
                            ID="txtNombre"
                            runat="server"
                            CssClass="form-control"
                            Placeholder="Nombre de la marca" />
                    </div>

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

