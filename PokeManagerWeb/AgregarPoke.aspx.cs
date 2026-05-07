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

                    TipoNegocio listaTipo = new TipoNegocio();
                    List<Tipo> tiposPoke = listaTipo.listarTipoSP();
                    Session["listaTipos"] = tiposPoke;
                    ddlTipo.DataSource = tiposPoke;
                    ddlDebilidad.DataSource = tiposPoke;
                    ddlDebilidad.DataValueField = "Id";
                    ddlDebilidad.DataTextField = "Descripcion";
                    ddlTipo.DataValueField = "Id";
                    ddlTipo.DataTextField = "Descripcion";
                    ddlDebilidad.DataBind();
                    ddlTipo.DataBind();

                    imgUrlPoke.ImageUrl = "https://t3.ftcdn.net/jpg/02/48/42/64/360_F_248426448_NVKLywWqArG2ADUxDq6QprtIzsF82dMF.jpg";

                    if (Request.QueryString["id"] != null)
                    {
                        int id = int.Parse(Request.QueryString["id"].ToString());
                        PokemonNegocio pokemonSelect = new PokemonNegocio();
                        Pokemon pokeTemporal = pokemonSelect.listarPokeSP().Find(x => x.Id == id);
                        txtNumero.Text = pokeTemporal.Numero.ToString();
                        txtNombre.Text = pokeTemporal.Nombre;
                        txtDescripcion.Text = pokeTemporal.Descripcion;
                        txtUrlImagen.Text = pokeTemporal.UrlImagen;
                        imgUrlPoke.ImageUrl = txtUrlImagen.Text;
                        imgUrlTipo.ImageUrl = pokeTemporal.Tipo.UrlImagen;
                        imgUrlDebilidad.ImageUrl = pokeTemporal.Debilidad.UrlImagen;
                        //ddlTipo.SelectedIndex = temporal.Tipo.Id -1;
                        //ddlDebilidad.SelectedIndex = temporal.Debilidad.Id -1;
                        ddlTipo.SelectedValue = pokeTemporal.Tipo.Id.ToString();
                        ddlDebilidad.SelectedValue = pokeTemporal.Debilidad.Id.ToString();

                        btnAgregar.Visible = false;
                        btnModificar.Visible = true;
                        btnEliminar.Visible = true;
                    }

                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            try
            {

                imgUrlPoke.ImageUrl = txtUrlImagen.Text;
                if (imgUrlPoke.ImageUrl == "")
                {
                    imgUrlPoke.ImageUrl = "https://t3.ftcdn.net/jpg/02/48/42/64/360_F_248426448_NVKLywWqArG2ADUxDq6QprtIzsF82dMF.jpg";

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                int idTipo = int.Parse(ddlTipo.SelectedValue);

                //List<Tipo> tipoSeleccionado = (List<Tipo>)Session["listaTipos"];
                //Tipo tipoUrl = tipoSeleccionado.Find(x => x.Id == id);
                Tipo tipoUrl = ((List<Tipo>)Session["listaTipos"]).Find(x => x.Id == idTipo);

                imgUrlTipo.ImageUrl = tipoUrl.UrlImagen;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        protected void ddlDebilidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                int idDebilidad = int.Parse(ddlDebilidad.SelectedValue);

                //List<Tipo> tipoSeleccionado = (List<Tipo>)Session["listaTipos"];
                //Tipo tipoUrl = tipoSeleccionado.Find(x => x.Id == id);
                Tipo debilidadUrl = ((List<Tipo>)Session["listaTipos"]).Find(x => x.Id == idDebilidad);

                imgUrlDebilidad.ImageUrl = debilidadUrl.UrlImagen;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
            Pokemon nuevoPoke = new Pokemon();
            PokemonNegocio datosPoke = new PokemonNegocio();

                nuevoPoke.Numero = int.Parse(txtNumero.Text);
                nuevoPoke.Nombre = txtNombre.Text;
                nuevoPoke.Descripcion = txtDescripcion.Text;
                nuevoPoke.UrlImagen = txtUrlImagen.Text;
                nuevoPoke.Tipo = new Tipo();
                nuevoPoke.Tipo.Id = int.Parse(ddlTipo.SelectedValue);
                nuevoPoke.Debilidad = new Tipo();
                nuevoPoke.Debilidad.Id = int.Parse(ddlDebilidad.SelectedValue);

                datosPoke.agregarPoke(nuevoPoke);

                Response.Redirect("PokemonLista.aspx");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request.QueryString["id"]);
                Pokemon editarPoke = new Pokemon();
                PokemonNegocio datosPoke = new PokemonNegocio();

                editarPoke = datosPoke.listarPokeSP().Find(x => x.Id == id);

                editarPoke.Numero = int.Parse(txtNumero.Text);
                editarPoke.Nombre = txtNombre.Text;
                editarPoke.Descripcion = txtDescripcion.Text;
                editarPoke.UrlImagen = txtUrlImagen.Text;
                editarPoke.Tipo = new Tipo();
                editarPoke.Tipo.Id = int.Parse(ddlTipo.SelectedValue);
                editarPoke.Debilidad = new Tipo();
                editarPoke.Debilidad.Id = int.Parse(ddlDebilidad.SelectedValue);

                datosPoke.EditarPoke(editarPoke);

                Response.Redirect("PokemonLista.aspx");

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request.QueryString["id"]);
                PokemonNegocio eliminarPoke = new PokemonNegocio();

                eliminarPoke.EliminarPokeSP(id);

                Response.Redirect("PokemonLista.aspx");

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}