using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Data
{
    public class ProductsDat
    {
        Persistence objPer = new Persistence();
        // Método para mostrar los productos
        public DataSet showProducts()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procSelectProduct";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }
        //Metodo para mostrar unicamente el id y el nombre
        public DataSet showProductDDL()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procSelectProductDDL";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }


        //Metodo para guardar un nuevo producto
        public bool saveProducts(string _name, string _description, int _quantity, double _price, string _img, int _fkProvider, int _fkCategory)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procInsertProduct";
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            objSelectCmd.Parameters.Add("v_nombre", MySqlDbType.VarString).Value = _name;
            objSelectCmd.Parameters.Add("v_description", MySqlDbType.VarString).Value = _description;
            objSelectCmd.Parameters.Add("v_cantidad", MySqlDbType.Int32).Value = _quantity;
            objSelectCmd.Parameters.Add("v_precio", MySqlDbType.Double).Value = _price;
            objSelectCmd.Parameters.Add("v_img", MySqlDbType.Text).Value = _img;
            objSelectCmd.Parameters.Add("vfk_proveedor", MySqlDbType.Int32).Value = _fkProvider;
            objSelectCmd.Parameters.Add("vfk_categorias", MySqlDbType.Int32).Value = _fkCategory;

            try
            {
                row = objSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
            }
            objPer.closeConnection();

            return executed;
        }
        
        //Metodo para actulizar un producto
        public bool updateProducts(int _idProduct, string _name, string _description, int _quantity, double _price, string _img, int _fkProvider, int _fkCategory)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procUpdateProduct";
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            objSelectCmd.Parameters.Add("v_id", MySqlDbType.Int32).Value = _idProduct;
            objSelectCmd.Parameters.Add("v_nombre", MySqlDbType.VarString).Value = _name;
            objSelectCmd.Parameters.Add("v_descripcion", MySqlDbType.VarString).Value = _description;
            objSelectCmd.Parameters.Add("v_cantidad", MySqlDbType.Int32).Value = _quantity;
            objSelectCmd.Parameters.Add("v_precio", MySqlDbType.Double).Value = _price;
            objSelectCmd.Parameters.Add("v_img", MySqlDbType.Text).Value = _img;
            objSelectCmd.Parameters.Add("vfk_proveedor", MySqlDbType.Int32).Value = _fkProvider;
            objSelectCmd.Parameters.Add("vfk_categorias", MySqlDbType.Int32).Value = _fkCategory;

            try
            {
                row = objSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
            }
            objPer.closeConnection();
            return executed;
        }

        //Metodo para borrar una Categoria
        public bool deleteProducts(int _idProduct)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procDeleteProduct";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_id", MySqlDbType.Int32).Value = _idProduct;

            try
            {
                row = objSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
            }
            objPer.closeConnection();
            return executed;
        }
    }
}