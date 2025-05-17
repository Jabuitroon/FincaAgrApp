using Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;

namespace Logic
{
    public class ClienteLog
    {
        private readonly ClienteDat objCli = new ClienteDat();
        public DataSet ShowCliente()
        {
            return objCli.ShowCliente();
        }
        public DataSet ShowClienteDDL()
        {
            return objCli.ShowClienteDDL();
        }
        public bool SaveCliente(string _nombre, string _correo, string _contrasena, string _direccion, string _ciudad)
        {
            return objCli.SaveCliente(_nombre, _correo, _contrasena, _direccion, _ciudad);
        }
        public bool UpdateCliente(int _idClient, string _nombre, string _correo, string _contrasena, string _direccion, string _ciudad)
        {
            return objCli.UpdateCliente(_idClient, _nombre, _correo, _contrasena, _direccion, _ciudad);
        }
        public bool DeleteCliente(int _idClient)
        {
            return objCli.DeleteCliente(_idClient);
        }
    }
}