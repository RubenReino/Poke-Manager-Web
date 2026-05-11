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

            // Lista para almacenar los Pokémon
            List<Pokemon> listaPoke = new List<Pokemon>();

            // Instancia de acceso a datos
            AccesoDatos lectura = new AccesoDatos();
            
            try
            {

                // Ejecutar stored procedure
                lectura.SetearProcedure("storedListar");
                lectura.EjecutarLectura();


                while (lectura.Lector.Read())
                {

                    // Crear objeto Pokémon
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
                    auxiliar.Activo = bool.Parse(lectura.Lector["Activo"].ToString());

                    // Agregar Pokémon cargado desde DB a la lista
                    listaPoke.Add(auxiliar);

                }

                // Retornar lista de Pokémon
                return listaPoke;
            }
            catch (Exception ex)
            {

                throw ex;

            }
            finally
            {

                // Cerrar conexión
                lectura.CerrarConexion();
            }

        }
        public void agregarPoke(Pokemon nuevoPoke)
        {

            // Instancia de acceso a datos
            AccesoDatos agregar = new AccesoDatos();
            
            try
            {
                // Ejecutar stored procedure de inserción
                agregar.SetearProcedure("storedAgregar");

                // Enviar parámetros
                agregar.SetearParametro("@numero",nuevoPoke.Numero);
                agregar.SetearParametro("@nombre",nuevoPoke.Nombre);
                agregar.SetearParametro("@descripcion",nuevoPoke.Descripcion);
                agregar.SetearParametro("@urlImagen",nuevoPoke.UrlImagen);
                agregar.SetearParametro("@tipoId",nuevoPoke.Tipo.Id);
                agregar.SetearParametro("@debilidadId",nuevoPoke.Debilidad.Id);

                // Ejecutar consulta
                agregar.AbrirConexion();
            }
            catch (Exception ex)
            {

                throw ex;

            }finally
            {

                // Cerrar conexión
                agregar.CerrarConexion();
            }

        }
        public void EditarPoke(Pokemon edicionPoke)
        {
            // Instancia de acceso a datos
            AccesoDatos editar = new AccesoDatos();
            
            try
            {

                // Ejecutar stored procedure de actualización
                editar.SetearProcedure("storedActualizar");

                // Enviar parámetros
                editar.SetearParametro("@id",edicionPoke.Id);
                editar.SetearParametro("@numero",edicionPoke.Numero);
                editar.SetearParametro("@nombre",edicionPoke.Nombre);
                editar.SetearParametro("@descripcion",edicionPoke.Descripcion);
                editar.SetearParametro("@urlImagen",edicionPoke.UrlImagen);
                editar.SetearParametro("@tipoId",edicionPoke.Tipo.Id);
                editar.SetearParametro("@debilidadId",edicionPoke.Debilidad.Id);

                // Ejecutar consulta
                editar.AbrirConexion();

            }
            catch (Exception ex)
            {

                throw ex;

            }finally
            {

                // Cerrar conexión
                editar.CerrarConexion();
            }

        }

        public void EliminarPokeSP(int id)
        {

            // Instancia de acceso a datos
            AccesoDatos eliminar = new AccesoDatos();
            try
            {

                // Ejecutar stored procedure de eliminación
                eliminar.SetearProcedure("storedEliminar");

                // Enviar id del Pokémon por parámetro
                eliminar.SetearParametro("@id",id);

                // Ejecutar consulta
                eliminar.AbrirConexion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                // Cerrar conexión
                eliminar.CerrarConexion();
            }
        }

        public void EliminarLogicoSP(int id, bool activo = false)
        {
            // Instancia de acceso a datos
            AccesoDatos eliminar = new AccesoDatos();
            try
            {

                // Ejecutar eliminación lógica
                eliminar.SetearProcedure("storedEliminarLogico");

                // Enviar estado activo, id pokemon por parametro
                eliminar.SetearParametro("@activo",activo);
                eliminar.SetearParametro("@id",id);

                // Ejecutar consulta
                eliminar.AbrirConexion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                // Ejecutar consulta
                eliminar.CerrarConexion();
            }
        }

    }
}
