using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class TipoNegocio
    {
        public List<Tipo> listarTipoSP()
        {
            List<Tipo> listaTipo = new List<Tipo>();
            AccesoDatos lectura = new AccesoDatos();

            try
            {
                lectura.SetearProcedure("SPlistaTipo");
                lectura.EjecutarLectura();


                while (lectura.Lector.Read())
                {
                    Tipo auxiliar = new Tipo();
                    auxiliar.Id = (int)lectura.Lector["Id"];
                    auxiliar.Descripcion = lectura.Lector["Descripcion"].ToString();
                    auxiliar.UrlImagen = lectura.Lector["UrlImagen"].ToString();
                    listaTipo.Add(auxiliar);
                }
                return listaTipo;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
