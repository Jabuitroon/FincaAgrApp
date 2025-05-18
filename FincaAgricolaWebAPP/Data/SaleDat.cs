using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Data
{
    public class SaleDat
    {
        private readonly Orclpersistence objPersistence = new Orclpersistence();

        public bool SaveSale(DateTime _fecha, int _fkProId, int _fkCliId, int _total)
        {
            try
            {
                using (OracleConnection conn = objPersistence.openConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        throw new Exception("La conexión no se abrió.");

                    const string query = "spInsertSale ";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("v_fecha", OracleDbType.Date).Value = _fecha;
                        cmd.Parameters.Add("vfk_pro_id", OracleDbType.Int32).Value = _fkProId;
                        cmd.Parameters.Add("vfk_cliente", OracleDbType.Int32).Value = _fkCliId;
                        cmd.Parameters.Add("v_total", OracleDbType.Int32).Value = _total;

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
                throw new Exception("Error en saveParcel: " + ex.Message, ex);
            }
        }

        public DataSet ShowSale()
        {
            var farmData = new DataSet();

            try
            {
                using (OracleConnection conn = objPersistence.openConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        throw new Exception("La conexión no se abrió.");
                    const string query = "SELECT * FROM vw_ventas";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        adapter.Fill(farmData);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en ShowSale: " + ex.Message, ex);
            }
            return farmData;
        }
        
        public bool UpdateSale(int idSale, DateTime _fecha, int _total, int _fkProdId, int _fkProId, int _fkCatId, int _fkCliId)
        {
            try
            {
                using (OracleConnection conn = objPersistence.openConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        throw new Exception("La conexión no se abrió.");

                    const string query = "procUpdateSale";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("v_id", OracleDbType.Int32).Value = idSale;
                        cmd.Parameters.Add("v_fecha", OracleDbType.Date).Value = _fecha;
                        cmd.Parameters.Add("vfk_pro_id", OracleDbType.Int32).Value = _fkProId;
                        cmd.Parameters.Add("vfk_cliente", OracleDbType.Int32).Value = _fkCliId;
                        cmd.Parameters.Add("v_total", OracleDbType.Int32).Value = _total;

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
                throw new Exception("Error en UpdateSale: " + ex.Message, ex);
            }
        }
        
        public bool DeleteSale(int idSale)
        {
            try
            {
                using (OracleConnection conn = objPersistence.openConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        throw new Exception("La conexión no se abrió.");

                    const string query = "BEGIN procDeleteSale(:v_id, :v_result); END;";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add("v_id", OracleDbType.Int32).Value = idSale;

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
                throw new Exception("Error en DeleteSale: " + ex.Message, ex);
            }
        }
    }
}