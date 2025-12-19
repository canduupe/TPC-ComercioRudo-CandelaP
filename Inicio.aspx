 <%@ Page Title="Inicio de sesión" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Inicio.aspx.cs"
    Inherits="TPC_ComercioRudo_CandelaP.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container vh-100 d-flex justify-content-center align-items-center">

        <div class="card shadow p-4" style="min-width: 350px;">

            <h4 class="text-center mb-4">Iniciar sesión</h4>

            <div class="mb-3">
                <asp:Label
                    ID="lblUsuario"
                    runat="server"
                    Text="Usuario"
                    CssClass="form-label">
                </asp:Label>

                <asp:TextBox 
                    ID="txtUsuario" 
                    runat="server"
                    CssClass="form-control"
                    Placeholder="Ingrese su usuario">
                </asp:TextBox>
            </div>

            <div class="mb-3">
                <asp:Label 
                    ID="lblContrasena" 
                    runat="server" 
                    Text="Contraseña"
                    CssClass="form-label">
                </asp:Label>

                <asp:TextBox
                    ID="txtContrasena"
                    runat="server"
                    TextMode="Password"
                    CssClass="form-control"
                    Placeholder="Ingrese su contraseña">
                </asp:TextBox>

            </div>

            <div class="d-grid mt-4">
                <asp:Button
                    ID="btnIniciar"
                    runat="server"
                    Text="Iniciar sesión"
                    CssClass="btn btn-dark"
                    OnClick="btnIniciar_Click" />

            </div>

        </div>

    </div>

</asp:Content>

