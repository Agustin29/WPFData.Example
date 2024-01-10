using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAppDataExample
{
    public class StoreDB
    {
        //CREAMOS NUESTRA CADENA DE CONEXION
        private string connectionString = Settings.Default.StoreDatabase;
        //METHOD GET PARA OBTENER EL PRODUCT CON EL ID
        public Product GetProduct(int ID)
        {
            //NOS CONECTAMOS A LA BASE DE DATOS PASANDOLE LA CONECTIONSTRING
            SqlConnection con = new SqlConnection(connectionString);
            //INDICAMOS QUE VAMOS HACER USO DE UN PROCEDURE-STORE Y LE PASAMOS LA CONEXION
            SqlCommand cmd = new SqlCommand("GetProductByID", con);
            //LE INDICAMOS AL COMANDO DE QUE TIPO VA SER NUESTRA T-SQL
            cmd.CommandType = CommandType.StoredProcedure;
            //LE PASAMOS EL PARAMETRO ID PARA QUE NOS DEVUELVA LOS DATOS CORRESPONDIENTES
            cmd.Parameters.AddWithValue("@ProductID", ID);
            try
            {
                //ABRIMOS LA CONEXION
                con.Open();
                //EJECUTAMOS EL COMANDO READER PARA LEER
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    // Create a Product object that wraps the
                    // current record.
                    Product product = new Product(
                    (int)reader["ProductID"],
                    (string)reader["ModelNumber"],
                    (string)reader["ModelName"],
                    (decimal)reader["UnitCost"],
                    (string)reader["Description"]);
                    return (product);
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                con.Close();
            }
        }

        internal void UpdateProduct(Product product)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("UpdateProduct", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductID", product.ProductID);
            cmd.Parameters.AddWithValue("@ModelNumber", product.ModelNumber);
            cmd.Parameters.AddWithValue("@ModelName", product.ModelName);
            cmd.Parameters.AddWithValue("@UnitCost", product.UnitCost);
            cmd.Parameters.AddWithValue("@Description", product.Description);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }
    }
}
