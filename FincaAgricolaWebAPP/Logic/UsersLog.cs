using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Logic
{
    public class UsersLog
    {
        UserDat objUsu = new UserDat();
        public DataSet showUsers()
        {
            return objUsu.showUsers();
        }
        
        public bool saveUsers(string _nombre, string _correo, string _contrasena, string _rol)
        {
            return objUsu.saveUser(_nombre, _correo, _contrasena, _rol);
        }
        public bool updateUser(int _idUsers, string _nombre, string _correo, string _contrasena, string _rol)
        {
            return objUsu.updateUser(_idUsers, _nombre, _correo, _contrasena, _rol);
        }
        public bool deleteUser(int _idUsers)
        {
            return objUsu.deleteUser(_idUsers);
        }
    }
}