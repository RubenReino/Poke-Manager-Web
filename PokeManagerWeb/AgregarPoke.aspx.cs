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
                        txtUrlImagen.Text = pokeTemporal.UrlImagen;
                        imgUrlPoke.ImageUrl = txtUrlImagen.Text;
                        if (imgUrlPoke.ImageUrl == "")
                        {
                            imgUrlPoke.ImageUrl = "https://t3.ftcdn.net/jpg/02/48/42/64/360_F_248426448_NVKLywWqArG2ADUxDq6QprtIzsF82dMF.jpg";

                        }
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
    }
}