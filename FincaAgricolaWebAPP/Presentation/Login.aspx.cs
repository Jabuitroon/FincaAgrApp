using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logic;

namespace Presentation
{
    public partial class Login : System.Web.UI.Page
    {
        private static readonly LoginLog loginLog = new LoginLog();
        private readonly LoginLog objtLogin = loginLog;

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.AppendHeader("Cache-Control", "no_store");
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }

        protected void SubmitLogin(object sender, EventArgs e)
        {
            bool loginOK = objtLogin.InitLogin(TBUserName.Text, TBUserPassword.Text);

            if (loginOK)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('✅ Login exitoso');", true);
                Session["usuario"] = TBUserName.Text;
                Response.Redirect("index.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('❌ Usuario o contraseña incorrectos');", true);
            }
        }
    }
}