using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public AccesoDatos()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true");
            comando = new SqlCommand();
        }

        public SqlDataReader Lector { get { return lector; } }

        public void EjecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void SetearProcedure(string consulta)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = consulta;
        }

        public void SetearParametro(string parametro, object valor)
        {
            comando.Parameters.AddWithValue(parametro, valor);
        }

        public void AbrirConexion()
        {
            comando.Connection = conexion;

            try
            {

                conexion.Open();
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public void CerrarConexion()
        {

            try
            {
                if (lector != null)
                {
                    lector.Close();
                }

                if (conexion != null)
                {
                    conexion.Close();
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
