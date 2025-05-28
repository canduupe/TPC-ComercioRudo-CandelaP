<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="TPC_ComercioRudo_CandelaP.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
         <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
    </div>
    <div>
        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblContraseña" runat="server" Text="Contraseña"></asp:Label>
    </div>
    <div>
        <asp:TextBox ID="txtContraseña" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Button ID="btnInicar" runat="server" Text="Iniciar" OnClick="btnInicar_Click"/>
    </div>
</asp:Content>
