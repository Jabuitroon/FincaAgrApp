using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;

namespace Data
{
    public class ParcelDat
    {
        Persistence objPer = new Persistence();
        //Metodo para mostrar todas las Parcelas
        public DataSet showParcel()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procSelectParcela";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        //Metodo para mostrar unicamente el id y la ubiacion 
        public DataSet showParcelDDL()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procSelectParcelaDDL";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }
        //Metodo para guardar una nueva Parcela
        public bool saveParcel(int _dimensiones, string _ubicacion, int _fkfinca, int _fkclima)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procInsertParcela";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_dimensiones", MySqlDbType.Int32).Value = _dimensiones;
            objSelectCmd.Parameters.Add("v_ubicacion", MySqlDbType.VarString).Value = _ubicacion;
            objSelectCmd.Parameters.Add("vfk_finca", MySqlDbType.Int32).Value = _fkfinca;
            objSelectCmd.Parameters.Add("vfk_clima", MySqlDbType.Int32).Value = _fkclima;

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

        //Metodo para actualizar una Parcela
        public bool updateParcel(int _idParcela, int _dimensiones, string _ubicacion, int _fkfinca, int _fkclima)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procUpdateParcela"; 
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_id", MySqlDbType.Int32).Value = _idParcela;
            objSelectCmd.Parameters.Add("v_dimensiones", MySqlDbType.Int32).Value = _dimensiones;
            objSelectCmd.Parameters.Add("v_ubicacion", MySqlDbType.VarString).Value = _ubicacion;
            objSelectCmd.Parameters.Add("vfk_finca", MySqlDbType.Int32).Value = _fkfinca;
            objSelectCmd.Parameters.Add("vfk_clima", MySqlDbType.Int32).Value = _fkclima;

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

        //Metodo para borrar una Parcela
        public bool deleteParcel(int _idParcela)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procDeleteParcela"; 
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_id", MySqlDbType.Int32).Value = _idParcela;

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