<%@ Page Title="" Language="C#" MasterPageFile="~/PokeMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PokeManagerWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Bienvenidos</h1>

    <div class="row row-cols-1 row-cols-md-3 g-4">


        <asp:Repeater ID="repPokemon" runat="server">
            <ItemTemplate>

        <div class="col">

            <div class="card">
                <img src="<%#Eval("UrlImagen")%>" class="card-img-top" alt="Loading...">
                <div class="card-body">
                    <h5 class="card-title"><%#Eval("Nombre")%></h5>
                    <a href="Detalles.aspx" class="btn btn-primary">Detalles</a>
                    <asp:Button ID="btnDetalles" Text="Ejemplo" CommandArgument='<%#Eval("Id") %>' CommandName="PokeId" OnClick="btnDetalles_Click" runat="server" />
                </div>
            </div>
        </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
