using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Data;

namespace Logic
{
    public class LoginLog
    {
        LoginDat objLogin = new LoginDat();
        public bool InitLogin(string _user, string _password)
        {
            return objLogin.InitLogin(_user, _password);
        }
    }
}