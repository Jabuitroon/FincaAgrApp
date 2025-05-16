using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Data
{
    public class InputsDatcs
    {
        Persistence objPer = new Persistence();
        Orclpersistence objPersistence = new Orclpersistence();


        //Metodo para guardar un Insumo
        public bool saveInputs(string _nombre, string _tipo, string _cantidad, int _fkCultivoId, int _fkParcelaId)
        {
            try
            {
                using (OracleConnection conn = objPersistence.openConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        throw new Exception("La conexión no se abrió.");

                    const string query = "procInsertInput";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("v_nombre", OracleDbType.Varchar2).Value = _nombre;
                        cmd.Parameters.Add("v_tipo", OracleDbType.Varchar2).Value = _tipo;
                        cmd.Parameters.Add("v_cantidad", OracleDbType.Varchar2).Value = _cantidad;
                        cmd.Parameters.Add("vfk_cultivo", OracleDbType.Int32).Value = _fkCultivoId;
                        cmd.Parameters.Add("vfk_parcela", OracleDbType.Int32).Value = _fkParcelaId;

                        var outputParam = cmd.Parameters.Add("v_result", OracleDbType.Int32);
                        outputParam.Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en saveInputs: " + ex.Message, ex);
            }
        }

        //Metodo para mostrar Insumos
        public DataSet showInputs()
        {
            var farmData = new DataSet();

            try
            {
                using (OracleConnection conn = objPersistence.openConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        throw new Exception("La conexión no se abrió.");

                    using (OracleCommand cmd = new OracleCommand("SELECT * from vw_insumos_cultivo_parcela", conn))
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
                throw new Exception("Error en showInputs: " + ex.Message, ex);
            }
            return farmData;
        }
        public DataSet showInputsDDL()
        {
            var farmData = new DataSet();

            try
            {
                using (OracleConnection conn = objPersistence.openConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        throw new Exception("La conexión no se abrió.");

                    using (OracleCommand cmd = new OracleCommand("SELECT * from vw_input_ddl", conn))
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
                throw new Exception("Error en showInputsDDL: " + ex.Message, ex);
            }
            return farmData;
        }

        //Metodo para actualizar un Cultivo
        public bool updateInputs(int _idInputs, string _nombre, string _tipo, string _cantidad, int _fkCultivoId, int _fkParcelaId)
        {
            try
            {
                using (OracleConnection conn = objPersistence.openConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        throw new Exception("La conexión no se abrió.");

                    const string query = "procUpdateInput";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("v_id", OracleDbType.Int32).Value = _idInputs;
                        cmd.Parameters.Add("v_nombre", OracleDbType.Varchar2).Value = _nombre;
                        cmd.Parameters.Add("v_tipo", OracleDbType.Varchar2).Value = _tipo;
                        cmd.Parameters.Add("v_cantidad", OracleDbType.Varchar2).Value = _cantidad;
                        cmd.Parameters.Add("vfk_cultivo", OracleDbType.Int32).Value = _fkCultivoId;
                        cmd.Parameters.Add("vfk_parcela", OracleDbType.Int32).Value = _fkParcelaId;


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
                throw new Exception("Error en updateInputs: " + ex.Message, ex);
            }
        }

        //Metodo para borrar una Inputs
        public bool deleteInputs(int _idInputs)
        {
            try
            {
                using (OracleConnection conn = objPersistence.openConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        throw new Exception("La conexión no se abrió.");

                    const string query = "BEGIN procDeleteInput(:v_id, :v_result); END;";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add("v_id", OracleDbType.Int32).Value = _idInputs;

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
                throw new Exception("Error en deleteInputs: " + ex.Message, ex);
            }
        }
    }
}