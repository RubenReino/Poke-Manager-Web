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
            if (Request.QueryString["id"] != null)
            {
                int id = int.Parse(Request.QueryString["id"].ToString());
                PokemonNegocio pokemonSelect = new PokemonNegocio();
                Pokemon temporal = new Pokemon();
                temporal = pokemonSelect.listarPokeSP().Find(x => x.Id == id);
                txtNumero.Text = temporal.Numero.ToString();
                txtNombre.Text = temporal.Nombre;
                txtUrlImagen.Text = temporal.UrlImagen;


                btnAgregar.Visible = false;
                btnModificar.Visible = true;
                 btnEliminar.Visible = true;
            }

        }
    }
}