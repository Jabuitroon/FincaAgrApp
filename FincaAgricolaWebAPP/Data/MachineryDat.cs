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
        private readonly Orclpersistence objPersistence = new Orclpersistence();

        // Método para guardar una Maquinaria
        public bool SaveMachinery(string _nombre, string _descripcion, string _clasificacion, int _fkCultivo, int _fkParcela)
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
                throw new Exception("Error en SaveMachinery: " + ex.Message, ex);
            }
        }

        // Método para mostrar Maquinarias
        public DataSet ShowMachinery()
        {
            var farmData = new DataSet();

            try
            {
                using (OracleConnection conn = objPersistence.openConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        throw new Exception("La conexión no se abrió.");

                    using (OracleCommand cmd = new OracleCommand("SELECT * from vw_maquinaria_info", conn))
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
                throw new Exception("Error en showMachinery: " + ex.Message, ex);
            }
            return farmData;
        }

        public DataSet ShowMaquinariaDDL()
        {
            var farmData = new DataSet();

            try
            {
                using (OracleConnection conn = objPersistence.openConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        throw new Exception("La conexión no se abrió.");

                    using (OracleCommand cmd = new OracleCommand("SELECT * from vw_maquinaria_info", conn))
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
                throw new Exception("Error en showMaquinariaDDL: " + ex.Message, ex);
            }
            return farmData;
        }

        //Método para actualizar una Maquinaria
        public bool UpdateMachinery(int _idMachinery, string _nombre, string _descripcion, string _clasificacion, int _fkCultivo, int _fkParcela)
        {
            try
            {
                using (OracleConnection conn = objPersistence.openConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        throw new Exception("La conexión no se abrió.");

                    const string query = "procUpdateMaquinaria";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("v_id", OracleDbType.Int32).Value = _idMachinery;
                        cmd.Parameters.Add("v_nombre", OracleDbType.Varchar2).Value = _nombre;
                        cmd.Parameters.Add("v_descripcion", OracleDbType.Varchar2).Value = _descripcion;
                        cmd.Parameters.Add("v_clasificacion", OracleDbType.Varchar2).Value = _clasificacion;
                        cmd.Parameters.Add("vfk_cultivoId", OracleDbType.Int32).Value = _fkCultivo;
                        cmd.Parameters.Add("vfk_parcelaId", OracleDbType.Int32).Value = _fkParcela;                        

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
                throw new Exception("Error en UpdateMachinery: " + ex.Message, ex);
            }
        }

        //Método para eliminar una Maquinaria
        public bool DeleteMachinery(int _idMachinery)
        {
            try
            {
                using (OracleConnection conn = objPersistence.openConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        throw new Exception("La conexión no se abrió.");

                    const string query = "BEGIN procDeleteMaquinaria(:v_id, :v_result); END;";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add("v_id", OracleDbType.Int32).Value = _idMachinery;

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
                throw new Exception("Error en DeleteMachinery: " + ex.Message, ex);
            }
        }
    }
}