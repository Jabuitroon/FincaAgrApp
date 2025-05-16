using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
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
        Orclpersistence objPersistence = new Orclpersistence();

        //Metodo para guardar una nueva Parcela
        public bool saveParcel(int _dimensiones, string _ubicacion, double _Temperatura, double _Humedad, int _fkfinca)
        {
            try
            {
                using (OracleConnection conn = objPersistence.openConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        throw new Exception("La conexión no se abrió.");

                    const string query = "procInsertParcela";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("v_dimensiones", OracleDbType.Int32).Value = _dimensiones;
                        cmd.Parameters.Add("v_ubicacion", OracleDbType.Varchar2).Value = _ubicacion;
                        cmd.Parameters.Add("v_temperatura", OracleDbType.Double).Value = _Temperatura;
                        cmd.Parameters.Add("v_humedad", OracleDbType.Double).Value = _Humedad;
                        cmd.Parameters.Add("vfk_finca", OracleDbType.Int32).Value = _fkfinca;

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

        //Metodo para mostrar todas las Parcelas
        public DataSet showParcel()
        {
            var farmData = new DataSet();

            try
            {
                using (OracleConnection conn = objPersistence.openConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        throw new Exception("La conexión no se abrió.");
                    const string query = "SELECT      p.par_id AS parcela_id,\r\n            p.par_dimensiones,\r\n            p.par_ubicacion,\r\n            p.par_temperatura,\r\n            p.par_humedad,\r\n            p.tbl_finca_fin_id,\r\n            f.fin_nombre AS finca_nombre\r\n        FROM tbl_parcela p\r\n        INNER JOIN tbl_finca f ON p.tbl_finca_fin_id = f.fin_id";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        adapter.Fill(farmData);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en showParcel: " + ex.Message, ex);
            }
            return farmData;
        }

        //Metodo para mostrar unicamente el id y la ubiacion 
        public DataSet showParcelDDL()
        {
            var farmData = new DataSet();

            try
            {
                using (OracleConnection conn = objPersistence.openConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        throw new Exception("La conexión no se abrió.");

                    using (OracleCommand cmd = new OracleCommand("procSelectParcelaDDL", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
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
                throw new Exception("🔴 Error en showCategoryDDL: " + ex.Message, ex);
            }
            return farmData;
        }

        //Metodo para actualizar una Parcela
        public bool updateParcel(int _idParcela, int _dimensiones, string _ubicacion, double _Temperatura, double _Humedad, int _fkfinca)
        {
            try
            {
                using (OracleConnection conn = objPersistence.openConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        throw new Exception("La conexión no se abrió.");

                    const string query = "procUpdateParcela";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("v_id", OracleDbType.Int32).Value = _idParcela;
                        cmd.Parameters.Add("v_dimensiones", OracleDbType.Int32).Value = _dimensiones;
                        cmd.Parameters.Add("v_ubicacion", OracleDbType.Varchar2).Value = _ubicacion;
                        cmd.Parameters.Add("v_temperatura", OracleDbType.Double).Value = _Temperatura;
                        cmd.Parameters.Add("v_humedad", OracleDbType.Double).Value = _Humedad;
                        cmd.Parameters.Add("vfk_finca", OracleDbType.Int32).Value = _fkfinca;

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
                throw new Exception("Error en updateParcel: " + ex.Message, ex);
            }
        }

        //Metodo para borrar una Parcela
        public bool deleteParcel(int _idParcela)
        {
            try
            {
                using (OracleConnection conn = objPersistence.openConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        throw new Exception("La conexión no se abrió.");

                    const string query = "BEGIN procDeleteParcela(:v_id, :v_result); END;";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add("v_id", OracleDbType.Int32).Value = _idParcela;

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
                throw new Exception("🔴 Error en deleteParcel: " + ex.Message, ex);
            }
        }
    }
}