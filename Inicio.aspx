<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="TPC_ComercioRudo_CandelaP.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<form>
    <div class="mb-3">
         <asp:Label ID="lblUsuario" class="form-label" runat="server" Text="Usuario"></asp:Label>
    </div>
    <div class="mb-3">
        <asp:TextBox ID="txtUsuario" class="form-control" runat="server"></asp:TextBox>
    </div>
    <div class="mb-3">
        <asp:Label ID="lblContraseña" class="form-label" runat="server" Text="Contraseña"></asp:Label>
    </div>
    <div class="mb-3">
        <asp:TextBox type="password" ID="txtContraseña" class="form-control" runat="server"></asp:TextBox>
    <div id="passwordHelpBlock" class="form-text">
    La contraseña debe tener entre 8-15 caracteres
    </div>
    </div>
    <div>
        <asp:Button ID="btnInicar" runat="server" class="btn btn-dark" Text="Iniciar" OnClick="btnInicar_Click"/>
    </div>
</form>
</asp:Content>
