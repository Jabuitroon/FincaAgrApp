using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Data
{
    public class SaleDat
    {
        Persistence objPer = new Persistence();
        public DataSet showSale()
        {          
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procSelectSale";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        public bool saveSale(DateTime _fecha, int _fkProId, int _fkCliId, int _total)
        {
        bool executed = false;
            int row;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spInsertSale"; 
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_fecha", MySqlDbType.Date).Value = _fecha;
            objSelectCmd.Parameters.Add("vfk_pro_id", MySqlDbType.Int32).Value = _fkProId;
            objSelectCmd.Parameters.Add("vfk_cliente", MySqlDbType.Int32).Value = _fkCliId;
            objSelectCmd.Parameters.Add("v_total", MySqlDbType.Int32).Value = _total;

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
        public bool updateSale(int idSale, DateTime _fecha, int _total, int _fkProdId, int _fkProId, int _fkCatId, int _fkCliId)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procUpdateSale";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("ven_id", MySqlDbType.Int32).Value = idSale;
            objSelectCmd.Parameters.Add("ven_fecha", MySqlDbType.Date).Value = _fecha;
            objSelectCmd.Parameters.Add("ven_total", MySqlDbType.Int32).Value = _total;
            objSelectCmd.Parameters.Add("tbl_productos_pro_id", MySqlDbType.Int32).Value = _fkProdId;
            objSelectCmd.Parameters.Add("tbl_productos_tbl_proveedor_pro_id", MySqlDbType.Int32).Value = _fkProId;
            objSelectCmd.Parameters.Add("tbl_productos_tbl_categoria_cat_id", MySqlDbType.Int32).Value = _fkCatId;
            objSelectCmd.Parameters.Add("tbl_cliente_cli_id", MySqlDbType.Int32).Value = _fkCliId;

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
        
        public bool deleteSale(int idSale)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procDeleteSale"; 
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("V_id", MySqlDbType.Int32).Value = idSale;
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