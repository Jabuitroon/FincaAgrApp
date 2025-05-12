using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;

namespace Data
{
    public class Orclpersistence
    {
        private readonly string connectionString;
        public Orclpersistence()
        {
            try
            {
                var connectionSetting = ConfigurationManager.ConnectionStrings["Conn"];
                if (connectionSetting == null || string.IsNullOrEmpty(connectionSetting.ConnectionString))
                {
                    throw new ConfigurationErrorsException("La cadena de conexión 'Conn' no está configurada.");
                }
                connectionString = connectionSetting.ConnectionString;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar la cadena de conexión: " + ex.Message);
                throw;
            }
        }

        public OracleConnection openConnection()
        {
            try
            {
                OracleConnection conn = new OracleConnection(connectionString);
                conn.Open();
                return conn;
            }
            catch (OracleException ex)
            {
                throw new InvalidOperationException("Error al abrir la conexión Oracle: " + ex.Message);
            }
        }
    }
}