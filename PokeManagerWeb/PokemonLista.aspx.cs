using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace PokeManagerWeb
{
    public partial class PokemonLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PokemonNegocio listaPoke = new PokemonNegocio();
            dgvListaPoke.DataSource = listaPoke.listarPokeSP();
            dgvListaPoke.DataBind();
        }
    }
}