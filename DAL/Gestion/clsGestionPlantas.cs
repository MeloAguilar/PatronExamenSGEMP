using DAL.Conexion;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Gestion
{
    public class clsGestionPlantas
    {
        clsMyConnection MiConexion = new clsMyConnection();



        /// <summary>
        /// <header> int EditarPrecioPlanta(clsPlanta p) </header>
        /// 
        /// Método que se encarga de establecer un nuevo precio a una planta de la base de datos FrayGuillermo
        /// <pre>p  debe ser una planta existente dentro de la base de datos FrayGuillermo</pre>
        /// 
        /// <post>siempre devolverá un entero correspondiente a las filas que han sido afectadas en la base de datos</post>
        /// </summary>
        /// <param name="p"></param>
        /// <returns>filasAfectadas: 1 si ha conseguido realizar la sentencia Update
        ///                            0 Si no ha conseguido realizar la sentencia update
        ///</returns>
        public int EditarPrecioPlanta(clsPlanta p)
        {
            var filasAfectadas = 0;

            SqlCommand cmd = new SqlCommand();

            SqlConnection cnn = null;

            cmd.Parameters.AddWithValue("@idPlanta", p.IdPlanta);
            cmd.Parameters.AddWithValue("@precio", p.Precio);
            cmd.CommandText = "Update plantas set precio = @precio Where idPlanta = @idPlanta";
            try
            {
                cnn = MiConexion.getConnection();

                cmd.Connection = cnn;

                filasAfectadas = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (cnn != null)
                    MiConexion.closeConnection(ref cnn);
            }
            return filasAfectadas;


        }
    }
}
