using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PokeManagerWeb
{
    public partial class AgregarPoke : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    // Carga inicial de los dropdowns desde la base de datos 
                    TipoNegocio listaTipo = new TipoNegocio();
                    List<Tipo> tiposPoke = listaTipo.listarTipoSP();

                    // Guardar lista en Session
                    Session["listaTipos"] = tiposPoke;

                    // Configuración de los dropdowns (clave/valor)
                    ddlTipo.DataSource = tiposPoke;
                    ddlDebilidad.DataSource = tiposPoke;
                    ddlDebilidad.DataValueField = "Id";
                    ddlDebilidad.DataTextField = "Descripcion";
                    ddlTipo.DataValueField = "Id";
                    ddlTipo.DataTextField = "Descripcion";
                    ddlDebilidad.DataBind();
                    ddlTipo.DataBind();

                    // Imagen por defecto (placeHolder)
                    imgUrlPoke.ImageUrl = "https://t3.ftcdn.net/jpg/02/48/42/64/360_F_248426448_NVKLywWqArG2ADUxDq6QprtIzsF82dMF.jpg";

                    // Verifica si viene un id para editar
                    string id = Request.QueryString["id"];
                    if (id != null)
                    {

                        // Buscar Pokémon seleccionado
                        PokemonNegocio pokeTemporal = new PokemonNegocio();
                        Pokemon pokeSelected = pokeTemporal.listarPokeSP().Find(x => x.Id == int.Parse(id));

                        // Guardar Pokémon en Session
                        Session.Add("pokeSeleccionado", pokeSelected);

                        // Cargar datos del Pokemon seleccionado
                        txtId.Text = pokeSelected.Id.ToString();
                        txtNumero.Text = pokeSelected.Numero.ToString();
                        txtNombre.Text = pokeSelected.Nombre;
                        txtDescripcion.Text = pokeSelected.Descripcion;
                        txtUrlImagen.Text = pokeSelected.UrlImagen;
                        imgUrlPoke.ImageUrl = txtUrlImagen.Text;
                        imgUrlTipo.ImageUrl = pokeSelected.Tipo.UrlImagen;
                        imgUrlDebilidad.ImageUrl = pokeSelected.Debilidad.UrlImagen;

                        // Otra manera de cargar los dropdowns
                        // ddlTipo.SelectedIndex = temporal.Tipo.Id -1;
                        // ddlDebilidad.SelectedIndex = temporal.Debilidad.Id -1;
                        ddlTipo.SelectedValue = pokeSelected.Tipo.Id.ToString();
                        ddlDebilidad.SelectedValue = pokeSelected.Debilidad.Id.ToString();

                        // Actualizar texto y mostrar botones de acción
                        if (!pokeSelected.Activo)
                        {
                            btnInactivar.Text = "Reactivar";
                        }
                        btnAgregar.Text = "Modificar";
                        btnInactivar.Visible = true;
                        btnEliminar.Visible = true;
                    }

                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            try
            {

                // Cambiar imagen según el URL ingresado
                if (txtUrlImagen.Text != "")
                {
                    imgUrlPoke.ImageUrl = txtUrlImagen.Text;

                }
                else
                {

                    // Mostrar imagen por defecto
                    imgUrlPoke.ImageUrl = "https://t3.ftcdn.net/jpg/02/48/42/64/360_F_248426448_NVKLywWqArG2ADUxDq6QprtIzsF82dMF.jpg";

                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                int idTipo = int.Parse(ddlTipo.SelectedValue);

                // Buscar el URL del tipo seleccionado
                // List<Tipo> tipoSeleccionado = (List<Tipo>)Session["listaTipos"];
                // Tipo tipoUrl = tipoSeleccionado.Find(x => x.Id == id);
                Tipo tipoUrl = ((List<Tipo>)Session["listaTipos"]).Find(x => x.Id == idTipo);

                //Mostrar imagen del tipo seleccionado
                imgUrlTipo.ImageUrl = tipoUrl.UrlImagen;

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }

        }

        protected void ddlDebilidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                int idDebilidad = int.Parse(ddlDebilidad.SelectedValue);

                // Buscar el URL de la debilidad seleccionada
                // List<Tipo> tipoSeleccionado = (List<Tipo>)Session["listaTipos"];
                // Tipo tipoUrl = tipoSeleccionado.Find(x => x.Id == id);
                Tipo debilidadUrl = ((List<Tipo>)Session["listaTipos"]).Find(x => x.Id == idDebilidad);

                // Mostrar imagen de la debilidad seleccionada
                imgUrlDebilidad.ImageUrl = debilidadUrl.UrlImagen;

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                // Crear objeto Pokémon
                Pokemon nuevoPoke = new Pokemon();
                PokemonNegocio datosPoke = new PokemonNegocio();

                // Asignar datos del formulario
                nuevoPoke.Numero = int.Parse(txtNumero.Text);
                nuevoPoke.Nombre = txtNombre.Text;
                nuevoPoke.Descripcion = txtDescripcion.Text;
                nuevoPoke.UrlImagen = txtUrlImagen.Text;
                nuevoPoke.Tipo = new Tipo();
                nuevoPoke.Tipo.Id = int.Parse(ddlTipo.SelectedValue);
                nuevoPoke.Debilidad = new Tipo();
                nuevoPoke.Debilidad.Id = int.Parse(ddlDebilidad.SelectedValue);

                // Verificar si es modificación o nuevo ingreso
                string id = Request.QueryString["id"];
                if (id != null)
                {

                    // Modificar Pokémon existente
                    nuevoPoke.Id = int.Parse(id);
                    datosPoke.EditarPoke(nuevoPoke);
                }
                else
                {

                    // Agregar nuevo Pokémon
                    datosPoke.agregarPoke(nuevoPoke);
                }

                // Redirigir a la lista
                Response.Redirect("PokemonLista.aspx", false);

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                // Mostrar confirmación de borrado
                btnConfirmarBorrar.Visible = true;
                chkEliminar.Visible = true;
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }

        protected void btnConfirmarBorrar_Click(object sender, EventArgs e)
        {
            try
            {

                // Verificar confirmación
                if (chkEliminar.Checked)
                {

                    // Eliminar Pokémon
                    PokemonNegocio eliminarPoke = new PokemonNegocio();
                    eliminarPoke.EliminarPokeSP(int.Parse(txtId.Text));

                    // Volver a la lista
                    Response.Redirect("PokemonLista.aspx", false);
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }

        protected void btnInactivar_Click(object sender, EventArgs e)
        {
            try
            {

                // Inactivar/Reactivar Pokémon seleccionado
                PokemonNegocio inactivar = new PokemonNegocio();
                Pokemon seleccionado = (Pokemon)Session["pokeSeleccionado"];

                // Si está inactivo se reactiva / Si está activo se inactiva
                inactivar.EliminarLogicoSP(int.Parse(txtId.Text), !seleccionado.Activo);

                // Volver a la lista
                Response.Redirect("PokemonLista.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }
    }
}