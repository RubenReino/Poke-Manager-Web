using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;


namespace negocio
{
    public class PokemonNegocio
    {
        public List<Pokemon> listarPokeSP()
        {
            List<Pokemon> listaPoke = new List<Pokemon>();
            AccesoDatos lectura = new AccesoDatos();
            
            try
            {
                lectura.SetearProcedure("storedListar");
                lectura.EjecutarLectura();


                while (lectura.Lector.Read())
                {
                    Pokemon auxiliar = new Pokemon();
                    auxiliar.Id = (int)lectura.Lector["id"];
                    auxiliar.Numero = (int)lectura.Lector["Numero"];
                    auxiliar.Nombre = lectura.Lector["Nombre"].ToString();
                    auxiliar.Descripcion = lectura.Lector["Descripcion"].ToString();
                    auxiliar.UrlImagen = lectura.Lector["UrlImagen"].ToString();
                    auxiliar.Tipo = new Tipo();
                    auxiliar.Tipo.Id = (int)lectura.Lector["idTipo"];
                    auxiliar.Tipo.Descripcion = lectura.Lector["Tipo"].ToString();
                    auxiliar.Tipo.UrlImagen = lectura.Lector["TipoI"].ToString();
                    auxiliar.Debilidad = new Tipo();
                    auxiliar.Debilidad.Id = (int)lectura.Lector["idDebilidad"];
                    auxiliar.Debilidad.Descripcion = lectura.Lector["Debilidad"].ToString();
                    auxiliar.Debilidad.UrlImagen = lectura.Lector["DebilidadI"].ToString();

                    listaPoke.Add(auxiliar);
                }
                return listaPoke;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
