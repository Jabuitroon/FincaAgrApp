using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Data
{
    public class IrrigationDat
    {
        Persistence objPer = new Persistence();

        public DataSet showIrrigation()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procSelecIrrigation";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);  
            objPer.closeConnection();
            return objData;
        }

        public DataSet showIrrigationDDL()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procSelectWeatherDLL";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        public bool saveIrrigation(string _tipo, string _cantidad, string _frecuencia, int _fkCultivoId, int _fkParId)
        {            
            bool executed = false;
            int row;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procInsertIrrigation"; 
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_tipo", MySqlDbType.VarString).Value = _tipo;
            objSelectCmd.Parameters.Add("v_cantidad_agua", MySqlDbType.VarString).Value = _cantidad;
            objSelectCmd.Parameters.Add("v_frecuencia", MySqlDbType.VarString).Value = _frecuencia;
            objSelectCmd.Parameters.Add("vfk_cultivo_id", MySqlDbType.Int32).Value = _fkCultivoId;
            objSelectCmd.Parameters.Add("vfk_tbl_par_id", MySqlDbType.Int32).Value = _fkParId;
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
        public bool updateIrrigation(int _idRiego, string _tipo, string _cantidad, string _frecuencia, int _fkCultivoId, int _fkParId)
        {
            bool executed = false;
            int row;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procUpdateIrrigation"; 
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_id", MySqlDbType.Int32).Value = _idRiego;
            objSelectCmd.Parameters.Add("v_tipo", MySqlDbType.VarString).Value = _tipo;
            objSelectCmd.Parameters.Add("v_cantidad_agua", MySqlDbType.VarString).Value = _cantidad;
            objSelectCmd.Parameters.Add("v_frecuencia", MySqlDbType.VarString).Value = _frecuencia;
            objSelectCmd.Parameters.Add("vfk_cultivo_id", MySqlDbType.Int32).Value = _fkCultivoId;
            objSelectCmd.Parameters.Add("vfk_tbl_par_id", MySqlDbType.Int32).Value = _fkParId;
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
        public bool deleteIrrigation(int _idRiego)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procDeleteIrrigation";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_id", MySqlDbType.Int32).Value = _idRiego;
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