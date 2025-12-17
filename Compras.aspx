<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="TPC_ComercioRudo_CandelaP.Compras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4">
        <div class="card shadow p-4">
            <h4 class="mb-3">Registrar Compra</h4>

            <label>Proveedor</label>
            <asp:DropDownList
                ID="ddlProveedor"
                runat="server"
                CssClass="form-control mb-2"
                AutoPostBack="true"
                OnSelectedIndexChanged="ddlProveedor_SelectedIndexChanged">
            </asp:DropDownList>

            <label>Producto</label>
            <asp:DropDownList
                ID="ddlProducto"
                runat="server"
                CssClass="form-control mb-2">
            </asp:DropDownList>


            <label>Cantidad comprada</label>
            <asp:TextBox
                ID="txtCantidad"
                runat="server"
                CssClass="form-control mb-2" />

            <label>Precio de compra</label>
            <asp:TextBox
                ID="txtPrecio"
                runat="server"
                CssClass="form-control mb-3" />

            <label>Porcentaje de ganancia</label>
            <asp:TextBox
                ID="txtGanancia"
                runat="server"
                CssClass="form-control mb-3" />

            <asp:Button
                ID="btnGuardar"
                runat="server"
                Text="Registrar compra"
                CssClass="btn btn-success"
                OnClick="btnGuardar_Click" />
        </div>
    </div>
       <div>
       <asp:Button
           ID="btnVolver"
           runat="server"
           Text="Volver"
           CssClass="btn btn-outline-secondary me-2"
           OnClick="btnVolver_Click" />
   </div>
</asp:Content>

