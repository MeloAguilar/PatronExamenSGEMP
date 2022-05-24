using DAL.Conexion;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Listas
{
   public class clsListasPlantas
    {
        clsMyConnection miConexion = new clsMyConnection();


        private clsPlanta GenerarPlanta(SqlDataReader reader)
        {
            clsPlanta p = null;
            if (reader.HasRows)
            {
                p = new clsPlanta((int)reader["IdPlanta"], (string)reader["NombrePlanta"], (string)reader["Descripcion"], (int)reader["IdCategoria"]);
                if(reader["precio"] != DBNull.Value)
                {
                    p.Precio = (double)reader["precio"];
                }

            }
            return p;
        }




        /// <summary>
        /// <header> List<clsPlanta> RecogerListadoCompletoPlantas() </header>
        ///     Método que se encarga de rescatar una lista de objetos clsPlanta de la base de datos FrayGuillermo
        ///     
        /// <pre>La base de datos debe ser accesible</pre>
        /// 
        /// <post>Siempre devolverá un listado con todas las plantas de la base de datos </post>
        /// </summary>
        /// <returns>pts: Lista de plantas proviniente de la base de datos</returns>
        public List<clsPlanta> RecogerListadoCompletoPlantas()
        {
            List<clsPlanta> pts = new List<clsPlanta>();
            
            SqlCommand cmd = new SqlCommand();

            SqlConnection cnn = null;

            SqlDataReader reader = null;

            cmd.CommandText = "Select * From plantas";

            try
            {
                cnn = miConexion.getConnection();

                cmd.Connection = cnn;

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    pts.Add(GenerarPlanta(reader));
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (reader != null) 
                    reader.Close();
                if (cnn != null)
                    miConexion.closeConnection(ref cnn);
            }
            return pts;


        }
    }
}
