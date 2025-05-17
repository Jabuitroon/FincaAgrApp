using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Data
{
    public class ClienteDat
    {
        private readonly Orclpersistence objPersistence = new Orclpersistence();

        //Metodo para guardar un cliente
        public bool SaveCliente(string _nombre, string _correo, string _contrasena, string _direccion, string _ciudad)
        {
            try
            {
                using (OracleConnection conn = objPersistence.openConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        throw new Exception("La conexión no se abrió.");

                    const string query = "procInsertClient";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("v_nombre", OracleDbType.Varchar2).Value = _nombre;
                        cmd.Parameters.Add("v_correo", OracleDbType.Varchar2).Value = _correo;
                        cmd.Parameters.Add("v_contrasena", OracleDbType.Varchar2).Value = _contrasena;
                        cmd.Parameters.Add("v_direccion", OracleDbType.Varchar2).Value = _direccion;
                        cmd.Parameters.Add("v_ciudad", OracleDbType.Varchar2).Value = _ciudad;

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
                throw new Exception("Error en SaveCliente: " + ex.Message, ex);
            }
        }

        //Metodo para mostrar todos los clientes
        public DataSet ShowCliente()
        {
            var farmData = new DataSet();

            try
            {
                using (OracleConnection conn = objPersistence.openConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        throw new Exception("La conexión no se abrió.");
                    const string query = "SELECT * FROM vw_clientes";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        adapter.Fill(farmData);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en ShowCliente: " + ex.Message, ex);
            }
            return farmData;
        }

        //Metodo para mostrar unicamente el id y la nombre
        public DataSet ShowClienteDDL()
        {
            var farmData = new DataSet();

            try
            {
                using (OracleConnection conn = objPersistence.openConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        throw new Exception("La conexión no se abrió.");
                    const string query = "SELECT * FROM wv_clientes_ddl";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        adapter.Fill(farmData);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en ShowClienteDDL: " + ex.Message, ex);
            }
            return farmData;
        }

        //Metodo para actualizar un cliente
        public bool UpdateCliente(int _idClient,string _nombre, string _correo, string _contrasena, string _direccion, string _ciudad)
        {
            try
            {
                using (OracleConnection conn = objPersistence.openConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        throw new Exception("La conexión no se abrió.");

                    const string query = "procUpdateClient";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("v_id", OracleDbType.Int32).Value = _idClient;
                        cmd.Parameters.Add("v_nombre", OracleDbType.Varchar2).Value = _nombre;
                        cmd.Parameters.Add("v_correo", OracleDbType.Varchar2).Value = _correo;
                        cmd.Parameters.Add("v_contrasena", OracleDbType.Varchar2).Value = _contrasena;
                        cmd.Parameters.Add("v_direccion", OracleDbType.Varchar2).Value = _direccion;
                        cmd.Parameters.Add("v_ciudad", OracleDbType.Varchar2).Value = _ciudad;

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
                throw new Exception("Error en UpdateCliente: " + ex.Message, ex);
            }
        }

        //Metodo para borrar un Cliente
        public bool DeleteCliente(int _idClient)
        {
            try
            {
                using (OracleConnection conn = objPersistence.openConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        throw new Exception("La conexión no se abrió.");

                    const string query = "BEGIN procDeleteClient(:v_id, :v_result); END;";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add("v_id", OracleDbType.Int32).Value = _idClient;

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
                throw new Exception("Error en DeleteCliente: " + ex.Message, ex);
            }
        }
    }
}