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
    public partial class Default : System.Web.UI.Page
    {
        public List<Pokemon> listaPoke { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            PokemonNegocio pokemons = new PokemonNegocio();
            listaPoke = pokemons.listarPokeSP();
            
        }
    }
}