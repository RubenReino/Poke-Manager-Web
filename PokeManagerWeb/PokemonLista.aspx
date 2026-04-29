<%@ Page Title="" Language="C#" MasterPageFile="~/PokeMaster.Master" AutoEventWireup="true" CodeBehind="PokemonLista.aspx.cs" Inherits="PokeManagerWeb.PokemonLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h2>aqui los pokemons</h2>
    <asp:GridView ID="dgvListaPoke" CssClass="table table-dark" AutoGenerateColumns="false" runat="server">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Imagen" DataField="UrlImagen" />
            <asp:BoundField HeaderText="Tipo" DataField="Tipo.Descripcion" />
            <asp:BoundField HeaderText="Tipo" DataField="Debilidad.Descripcion" />
        </Columns>
    </asp:GridView>
</asp:Content>
