using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Data
{
    public class FarmDat
    {
        Orclpersistence objPersistence = new Orclpersistence();

        //Metodo para guardar una nueva Finca
        public bool saveFarm(string _nombre, string _ubicacion)
        {
            try
            {
                using (OracleConnection conn = objPersistence.openConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        throw new Exception("La conexión no se abrió.");

                    const string query = "procInsertFinca";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("v_nombre", OracleDbType.Varchar2).Value = _nombre;
                        cmd.Parameters.Add("v_ubicacion", OracleDbType.Varchar2).Value = _ubicacion;

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

        //Metodo para mostrar todas las Fincas
        public DataSet showFarm()
        {
            var farmData = new DataSet();

            try
            {
                using (OracleConnection conn = objPersistence.openConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        throw new Exception("La conexión no se abrió.");

                    const string query = "SELECT fin_id, fin_nombre, fin_ubicacion FROM tbl_finca";

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

        public DataSet showFarmDDL()
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

        //Metodo para actualizar una Finca
        public bool updateFarm(int _idFarm, string _nombre, string _ubicacion)
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

                        cmd.Parameters.Add("v_id", OracleDbType.Int32).Value = _idFarm;
                        cmd.Parameters.Add("v_nombre", OracleDbType.Varchar2).Value = _nombre;
                        cmd.Parameters.Add("v_ubicacion", OracleDbType.Varchar2).Value = _ubicacion;

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

        //Metodo para borrar una Finca
        public bool deleteFarm(int _idFarm)
        {
            try
            {
                using (OracleConnection conn = objPersistence.openConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        throw new Exception("La conexión no se abrió.");

                    const string query = "BEGIN procDeleteFinca(:v_id, :v_result); END;";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add("v_id", OracleDbType.Int32).Value = _idFarm;

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