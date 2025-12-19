<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="TPC_ComercioRudo_CandelaP.Categorias" %>
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
                    <h3 class="mb-0">Categorias</h3>

                    <asp:Button
                        ID="btnNuevo"
                        runat="server"
                        Text="Nueva categoria"
                        CssClass="btn btn-success"
                        OnClick="btnNuevo_Click" />
                </div>

                <hr />

                <asp:GridView
                    ID="dgvCategoria"
                    runat="server"
                    CssClass="table table-striped table-hover table-bordered"
                    HeaderStyle-CssClass="table-dark"
                    AutoGenerateColumns="false"
                    DataKeyNames="id"
                    OnRowCommand="dgvCategoria_RowCommand">

                    <Columns>
                        <asp:BoundField DataField="nombre" HeaderText="Categoria" />

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

                    <h5>Categoria</h5>
                    <asp:HiddenField ID="hfIdCategoria" runat="server" />

                    <div class="mb-3">
                        <asp:TextBox
                            ID="txtNombre"
                            runat="server"
                            CssClass="form-control"
                            Placeholder="Nombre de la categoria" />
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