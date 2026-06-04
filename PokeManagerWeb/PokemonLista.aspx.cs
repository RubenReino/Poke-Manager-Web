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
        public bool FiltroA { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            PokemonNegocio listaPoke = new PokemonNegocio();
            Session.Add("listaPokemon", listaPoke.listarPokeSP());
            dgvListaPoke.DataSource = Session["listaPokemon"];
            lblNoDisponible.Visible = false;
            dgvListaPoke.DataBind();
        }

        protected void dgvListaPoke_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvListaPoke.SelectedDataKey.Value.ToString();

            Response.Redirect("AgregarPoke.aspx?id=" + id);
        }

        protected void dgvListaPoke_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvListaPoke.PageIndex = e.NewPageIndex;
            dgvListaPoke.DataBind();
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                List<Pokemon> lista = (List<Pokemon>)Session["listaPokemon"];
                List<Pokemon> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
                dgvListaPoke.DataSource = listaFiltrada;
                if (listaFiltrada.Count == 0)
                {
                    lblNoDisponible.Visible = true;
                }
                else
                {
                    lblNoDisponible.Visible = false;
                }
                dgvListaPoke.DataBind();
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);
            }
        }

        protected void chkFiltroA_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                FiltroA = chkFiltroA.Checked;
                if (FiltroA)
                {
                    txtFiltro.Enabled = false;
                }
                else
                {
                    txtFiltro.Enabled = true;
                }
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);
            }
        }
    }
}