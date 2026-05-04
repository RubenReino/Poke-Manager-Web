<%@ Page Title="" Language="C#" MasterPageFile="~/PokeMaster.Master" AutoEventWireup="true" CodeBehind="AgregarPoke.aspx.cs" Inherits="PokeManagerWeb.AgregarPoke" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>POKEMON</h2>
    <div class="row">

        <div class="col-4">


            <div class="mb-3">
                <asp:Label AssociatedControlID="txtNumero" class="form-label" runat="server">Numero</asp:Label>
                <asp:TextBox ID="txtNumero" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label AssociatedControlID="txtNombre" class="form-label" runat="server">Nombre</asp:Label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label AssociatedControlID="txtUrlImagen" class="form-label" runat="server">Imagen(URL)</asp:Label>
                <asp:TextBox ID="txtUrlImagen" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label AssociatedControlID="ddlTipo" class="form-label" runat="server">Tipo:</asp:Label><br />
                <asp:DropDownList ID="ddlTipo" CssClass="btn btn-secondary" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Label AssociatedControlID="ddlDebilidad" class="form-label" runat="server">Debilidad:</asp:Label><br />
                <asp:DropDownList ID="ddlDebilidad" CssClass="btn btn-secondary" runat="server"></asp:DropDownList>
            </div>
            <div class="col-4"></div>
            <div class="col-4"></div>
        </div>

    </div>
    <asp:Button ID="btnAgregar" Text="Guardar" CssClass="btn btn-secondary" runat="server" />
    <asp:Button ID="btnModificar" Text="Modificar" Visible="false" CssClass="btn btn-secondary" runat="server" />
    <asp:Button ID="btnEliminar" Text="Eliminar" Visible="false" CssClass="btn btn-secondary" runat="server" />
    <a href="PokemonLista.aspx" class="btn btn-secondary">Cancelar</a>
</asp:Content>
