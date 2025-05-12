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
        ClienteDat objCli = new ClienteDat();
        public DataSet showCliente()
        {
            return objCli.showCliente();
        }
        public DataSet showClienteDDL()
        {
            return objCli.showClienteDDL();
        }
        public bool saveCliente(string _nombre, string _correo, string _contrasena, string _direccion, string _ciudad)
        {
            return objCli.saveCliente(_nombre, _correo, _contrasena, _direccion, _ciudad);
        }
        public bool updateCliente(int _idClient, string _nombre, string _correo, string _contrasena, string _direccion, string _ciudad)
        {
            return objCli.updateCliente(_idClient, _nombre, _correo, _contrasena, _direccion, _ciudad);
        }
        public bool deleteCliente(int _idClient)
        {
            return objCli.deleteCliente(_idClient);
        }
    }
}