<%@ Page Title="" Language="C#" MasterPageFile="~/PokeMaster.Master" AutoEventWireup="true" CodeBehind="PokemonLista.aspx.cs" Inherits="PokeManagerWeb.PokemonLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h2>aqui los pokemons</h2>
    <asp:GridView ID="dgvListaPoke" 
        DataKeyNames="Id" OnSelectedIndexChanged="dgvListaPoke_SelectedIndexChanged" 
        CssClass="table table-dark" AutoGenerateColumns="false"  
        OnPageIndexChanging="dgvListaPoke_PageIndexChanging"
        AllowPaging="true" PageSize="5" runat="server">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Imagen" DataField="UrlImagen" />
            <asp:BoundField HeaderText="Tipo" DataField="Tipo.Descripcion" />
            <asp:BoundField HeaderText="Tipo" DataField="Debilidad.Descripcion" />
            <asp:CommandField headerText="Acción" ShowSelectButton="true" SelectText="✏️" ControlStyle-CssClass="no-decoration"/>
        </Columns>
    </asp:GridView>
    <a href="AgregarPoke.aspx" class="btn btn-primary">Agregar</a>
</asp:Content>
