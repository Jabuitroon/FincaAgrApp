using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
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
        private readonly Orclpersistence objPersistence = new Orclpersistence();

        //Metodo para guardar un nuevo producto
        public bool SaveProducts(string _name, string _description, int _quantity, int _content, double _price, string _img, int _fkFarm, int _fkCategory)
        {
            try
            {
                using (OracleConnection conn = objPersistence.openConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        throw new Exception("La conexión no se abrió.");

                    const string query = "procInsertProduct";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("v_nombre", OracleDbType.Varchar2).Value = _name;
                        cmd.Parameters.Add("v_ubicacion", OracleDbType.Varchar2).Value = _description;
                        cmd.Parameters.Add("v_cantidad_inventario", OracleDbType.Int32).Value = _quantity;
                        cmd.Parameters.Add("v_contenido", OracleDbType.Int32).Value = _content;
                        cmd.Parameters.Add("v_precio", OracleDbType.Double).Value = _price;
                        cmd.Parameters.Add("v_img", OracleDbType.Varchar2).Value = _img;
                        cmd.Parameters.Add("vfk_finca", OracleDbType.Int32).Value = _fkFarm;
                        cmd.Parameters.Add("vfk_categorias", OracleDbType.Int32).Value = _fkCategory;

                        var outputParam = cmd.Parameters.Add("v_result", OracleDbType.Int32);
                        outputParam.Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en saveProducts: " + ex.Message, ex);
            }
        }

        // Método para mostrar los productos
        public DataSet ShowProducts()
        {
            var farmData = new DataSet();
            try
            {
                using (OracleConnection conn = objPersistence.openConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        throw new Exception("La conexión no se abrió.");

                    const string query = "select * from vw_products";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        adapter.Fill(farmData);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en showFarm: " + ex.Message, ex);
            }

            return farmData;
        }
        //Metodo para mostrar unicamente el id y el nombre
        public DataSet ShowProductDDL()
        {
            var farmData = new DataSet();

            try
            {
                using (OracleConnection conn = objPersistence.openConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        throw new Exception("La conexión no se abrió.");

                    using (OracleCommand cmd = new OracleCommand("SELECT pro_id, pro_nombre FROM tbl_producto", conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                        using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                        {
                            adapter.Fill(farmData);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("🔴Error en showCropsDDL: " + ex.Message, ex);
            }
            return farmData;
        }
        
        //Metodo para actulizar un producto
        public bool updateProducts(int _idProduct, string _name, string _description, int _quantity, int _content, double _price, string _img, int _fkFarm, int _fkCategory)
        {
            try
            {
                using (OracleConnection conn = objPersistence.openConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        throw new Exception("La conexión no se abrió.");

                    const string query = "procUpdateFinca";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("v_id", OracleDbType.Int32).Value = _idProduct;
                        cmd.Parameters.Add("v_nombre", OracleDbType.Varchar2).Value = _name;
                        cmd.Parameters.Add("v_ubicacion", OracleDbType.Varchar2).Value = _description;
                        cmd.Parameters.Add("v_cantidad_inventario", OracleDbType.Int32).Value = _quantity;
                        cmd.Parameters.Add("v_contenido", OracleDbType.Int32).Value = _content;
                        cmd.Parameters.Add("v_precio", OracleDbType.Double).Value = _price;
                        cmd.Parameters.Add("v_img", OracleDbType.Varchar2).Value = _img;
                        cmd.Parameters.Add("vfk_finca", OracleDbType.Int32).Value = _fkFarm;
                        cmd.Parameters.Add("vfk_categorias", OracleDbType.Int32).Value = _fkCategory;

                        var outputParam = cmd.Parameters.Add("v_result", OracleDbType.Int32);
                        outputParam.Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        var rowsAffected = ((Oracle.ManagedDataAccess.Types.OracleDecimal)outputParam.Value).ToInt32();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en updateFarm: " + ex.Message, ex);
            }
        }

        //Metodo para borrar una Categoria
        public bool DeleteProducts(int _idProduct)
        {
            try
            {
                using (OracleConnection conn = objPersistence.openConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        throw new Exception("La conexión no se abrió.");

                    const string query = "BEGIN procDeleteProduct(:v_id, :v_result); END;";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add("v_id", OracleDbType.Int32).Value = _idProduct;

                        var outputParam = cmd.Parameters.Add("v_result", OracleDbType.Decimal);
                        outputParam.Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        var rowsAffected = ((Oracle.ManagedDataAccess.Types.OracleDecimal)outputParam.Value).ToInt32();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en deleteFarm: " + ex.Message, ex);
            }
        }
    }
}