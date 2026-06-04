<%@ Page Title="" Language="C#" MasterPageFile="~/PokeMaster.Master" AutoEventWireup="true" CodeBehind="PokemonLista.aspx.cs" Inherits="PokeManagerWeb.PokemonLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>aqui los pokemons</h2>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>

            <div class="row">
                <div class="col-4">
                    <div class="mb-3">
                        <asp:Label ID="lblFiltro" AssociatedControlID="txtFiltro" Text="Filtro" CssClass="form-label" runat="server" />
                        <asp:TextBox ID="txtFiltro" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" CssClass="form-control" runat="server" />
                        <asp:CheckBox ID="chkFiltroA" Text="Filtro Avanzado" OnCheckedChanged="chkFiltroA_CheckedChanged" AutoPostBack="true" runat="server" />
                        <asp:Label ID="lblNoDisponible" Text="Pokemon no disponible..." runat="server" />
                    </div>
                </div>
            </div>
            <%if (FiltroA)
                {%>
            <div class="row">

                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label ID="lblCampo" AssociatedControlID="ddlCampo" Text="Campo" CssClass="form-label" runat="server" />
                        <asp:DropDownList ID="ddlCampo" CssClass="form-control" runat="server">
                            <asp:ListItem Text="Nombre" />
                            <asp:ListItem Text="Tipo" />
                            <asp:ListItem Text="Número" />
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label ID="lblCriterio" AssociatedControlID="ddlCriterio" Text="Criterio" CssClass="form-label" runat="server" />
                        <asp:DropDownList ID="ddlCriterio" CssClass="form-control" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label ID="lblFiltroA" AssociatedControlID="txtFiltroA" Text="Filtro" CssClass="form-label" runat="server" />
                        <asp:TextBox ID="txtFiltroA" CssClass="form-control" runat="server" />
                    </div>
                </div>

                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label ID="lblEstado" AssociatedControlID="ddlEstado" Text="Estado" CssClass="form-label" runat="server" />
                        <asp:DropDownList ID="ddlEstado" CssClass="form-control" runat="server">
                            <asp:ListItem Text="Todos" />
                            <asp:ListItem Text="Activo" />
                            <asp:ListItem Text="Inactivo" />
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <%} %>
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
                    <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
                    <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="✏️" ControlStyle-CssClass="no-decoration" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <a href="AgregarPoke.aspx" class="btn btn-primary">Agregar</a>
</asp:Content>
