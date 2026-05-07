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
            finally
            {
                lectura.CerrarConexion();
            }

        }
        public void agregarPoke(Pokemon nuevoPoke)
        {

            AccesoDatos agregar = new AccesoDatos();
            
            try
            {

                agregar.SetearProcedure("storedAgregar");
                agregar.SetearParametro("@numero",nuevoPoke.Numero);
                agregar.SetearParametro("@nombre",nuevoPoke.Nombre);
                agregar.SetearParametro("@descripcion",nuevoPoke.Descripcion);
                agregar.SetearParametro("@urlImagen",nuevoPoke.UrlImagen);
                agregar.SetearParametro("@tipoId",nuevoPoke.Tipo.Id);
                agregar.SetearParametro("@debilidadId",nuevoPoke.Debilidad.Id);

                agregar.AbrirConexion();
            }
            catch (Exception ex)
            {

                throw ex;

            }finally
            {
                agregar.CerrarConexion();
            }

        }
        public void EditarPoke(Pokemon edicionPoke)
        {

            AccesoDatos editar = new AccesoDatos();
            
            try
            {

                editar.SetearProcedure("storedActualizar");
                editar.SetearParametro("@id",edicionPoke.Id);
                editar.SetearParametro("@numero",edicionPoke.Numero);
                editar.SetearParametro("@nombre",edicionPoke.Nombre);
                editar.SetearParametro("@descripcion",edicionPoke.Descripcion);
                editar.SetearParametro("@urlImagen",edicionPoke.UrlImagen);
                editar.SetearParametro("@tipoId",edicionPoke.Tipo.Id);
                editar.SetearParametro("@debilidadId",edicionPoke.Debilidad.Id);

                editar.AbrirConexion();

            }
            catch (Exception ex)
            {

                throw ex;

            }finally
            {
                editar.CerrarConexion();
            }

        }

        public void EliminarPokeSP(int id)
        {
            AccesoDatos eliminar = new AccesoDatos();
            try
            {
                eliminar.SetearProcedure("storedEliminar"); 
                eliminar.SetearParametro("@id",id);

                eliminar.AbrirConexion();
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                eliminar.CerrarConexion();
            }
        }

    }
}
