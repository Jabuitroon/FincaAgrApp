using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;

namespace Data
{
    public class LoginDat
    {
        Orclpersistence objPersistence = new Orclpersistence();
        public bool InitLogin(string _user, string _password)
        {
            try
            {
                using (OracleConnection conn = objPersistence.openConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        throw new Exception("La conexión no se abrió.");

                    string sql = "SELECT COUNT(*) FROM usuarios WHERE username = :username AND password_hash = :password";

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.Add("username", OracleDbType.Varchar2).Value = _user;
                        cmd.Parameters.Add("password", OracleDbType.Varchar2).Value = _password;

                        int userCount = Convert.ToInt32(cmd.ExecuteScalar());

                        return userCount > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en Login: " + ex.Message, ex);
            }
        }
    }
}