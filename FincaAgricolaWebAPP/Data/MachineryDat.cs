using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Data
{
    public class MachineryDat
    {
        Orclpersistence objPersistence = new Orclpersistence();
        Persistence objPer = new Persistence();

        // Método para guardar una Maquinaria
        public bool saveMachinery(string _nombre, string _descripcion, string _clasificacion, int _fkCultivo, int _fkParcela)
        {
            try
            {
                using (OracleConnection conn = objPersistence.openConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        throw new Exception("La conexión no se abrió.");

                    const string query = "procInsertMaquinaria";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("v_nombre", OracleDbType.Varchar2).Value = _nombre;
                        cmd.Parameters.Add("v_ubicacion", OracleDbType.Varchar2).Value = _descripcion;
                        cmd.Parameters.Add("v_ubicacion", OracleDbType.Varchar2).Value = _clasificacion;
                        cmd.Parameters.Add("vfk_cultivoId", OracleDbType.Int32).Value = _fkCultivo;
                        cmd.Parameters.Add("vfk_parcelaId", OracleDbType.Int32).Value = _fkParcela;

                        var outputParam = cmd.Parameters.Add("v_result", OracleDbType.Int32);
                        outputParam.Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en showFarm: " + ex.Message, ex);
            }
        }

        // Método para mostrar Maquinarias
        public DataSet showMachinery()
        {
            var farmData = new DataSet();

            try
            {
                using (OracleConnection conn = objPersistence.openConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        throw new Exception("La conexión no se abrió.");

                    using (OracleCommand cmd = new OracleCommand("procSelectFincaDDL", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Parámetro de salida: cursor
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
                throw new Exception("Error en showFarmDDL: " + ex.Message, ex);
            }
            return farmData;
        }

        public DataSet showMaquinariaDDL()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procSelectMaquinariaDDL";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        //Método para actualizar una Maquinaria
        public bool updateMachinery(int _idMachinery, string _nombre, string _descripcion, string _clasificacion, int _fkCultivo, int _fkParcela)
        {
            bool executed = false;
            int row;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procUpdateMaquinaria";
            objSelectCmd.Parameters.Add("v_id", MySqlDbType.Int32).Value = _idMachinery;
            objSelectCmd.Parameters.Add("v_nombre", MySqlDbType.VarString).Value = _nombre;
            objSelectCmd.Parameters.Add("v_descripcion", MySqlDbType.VarString).Value = _descripcion;
            objSelectCmd.Parameters.Add("v_clasificacion", MySqlDbType.VarString).Value = _clasificacion;
            objSelectCmd.Parameters.Add("vfk_cultivoId", MySqlDbType.Int32).Value = _fkCultivo;
            objSelectCmd.Parameters.Add("vfk_parcelaId", MySqlDbType.Int32).Value = _fkParcela;
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

        //Método para eliminar una Maquinaria
        public bool deleteMachinery(int _idMachinery)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procDeleteMaquinaria";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_maquinaria_id", MySqlDbType.Int32).Value = _idMachinery;
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