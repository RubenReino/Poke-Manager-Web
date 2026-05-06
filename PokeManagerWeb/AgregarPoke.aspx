<%@ Page Title="" Language="C#" MasterPageFile="~/PokeMaster.Master" AutoEventWireup="true" CodeBehind="AgregarPoke.aspx.cs" Inherits="PokeManagerWeb.AgregarPoke" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<!-- Contenedor principal de la vista para registrar o editar un Pokémon -->
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>POKEMON</h2>

    <!-- Inicio del layout en filas usando Bootstrap -->
    <div class="row">

        <!-- Columna izquierda: datos básicos del Pokémon -->
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
                <asp:Label AssociatedControlID="txtDescripcion" class="form-label" runat="server">Descripción</asp:Label>
                <asp:TextBox ID="txtDescripcion" TextMode="MultiLine" CssClass="form-control" runat="server" />
            </div>

            <!-- Dropdown de tipo: dispara postback para actualizar imagen de tipo -->
            <div class="mb-3">
                <asp:Label AssociatedControlID="ddlTipo" class="form-label" runat="server">Tipo:</asp:Label><br />
                <asp:DropDownList ID="ddlTipo" AutoPostBack="true" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged" CssClass="btn btn-secondary" runat="server"></asp:DropDownList>
            </div>

            <!-- Dropdown de debilidad: dispara postback para actualizar imagen de debilidad -->
            <div class="mb-3">
                <asp:Label AssociatedControlID="ddlDebilidad" class="form-label" runat="server">Debilidad:</asp:Label><br />
                <asp:DropDownList ID="ddlDebilidad" AutoPostBack="true" OnSelectedIndexChanged="ddlDebilidad_SelectedIndexChanged" CssClass="btn btn-secondary" runat="server"></asp:DropDownList>
            </div>
        </div>

        <!-- Separador visual entre columnas -->
        <div class="col-1"></div>

        <!-- Columna derecha: vista previa de imágenes -->
        <div class="col-4">

            <!-- UpdatePanel para actualizar solo la imagen principal sin recargar toda la página -->
            <asp:UpdatePanel runat="server">
                <ContentTemplate>

                    <div class="mb-3">
                        <asp:Label AssociatedControlID="txtUrlImagen" class="form-label" runat="server">Imagen(URL)</asp:Label>
                        <asp:TextBox ID="txtUrlImagen" AutoPostBack="true" OnTextChanged="txtUrlImagen_TextChanged" CssClass="form-control" runat="server" />
                    </div>
                    <div>
                        <asp:Image ID="imgUrlPoke" runat="server" Width="270px" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <!-- UpdatePanel para imágenes de tipo y debilidad (actualización parcial mediante triggers) -->
            <asp:UpdatePanel runat="server">
                <ContentTemplate>

                    <!-- Imagen representativa del tipo seleccionado -->
                    <asp:Label AssociatedControlID="imgUrlTipo" class="form-label" runat="server">Tipo:</asp:Label>
                    <asp:Image ID="imgUrlTipo" runat="server" Width="100px" />

                    <!-- Imagen representativa de la debilidad seleccionada -->
                    <asp:Label AssociatedControlID="imgUrlDebilidad" class="form-label" runat="server">Debilidad:</asp:Label>
                    <asp:Image ID="imgUrlDebilidad" runat="server" Width="100px" />

                </ContentTemplate>

                <!-- Triggers que conectan los dropdowns con este panel para actualización parcial -->
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddlTipo" EventName="SelectedIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="ddlDebilidad" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>

        </div>
    </div>

    <!-- Botones de acción: guardar, modificar o eliminar Pokémon -->
    <asp:Button ID="btnAgregar" Text="Guardar" CssClass="btn btn-secondary" runat="server" />
    <asp:Button ID="btnModificar" Text="Modificar" Visible="false" CssClass="btn btn-secondary" runat="server" />
    <asp:Button ID="btnEliminar" Text="Eliminar" Visible="false" CssClass="btn btn-secondary" runat="server" />

    <a href="PokemonLista.aspx" class="btn btn-secondary">Cancelar</a>
</asp:Content>
