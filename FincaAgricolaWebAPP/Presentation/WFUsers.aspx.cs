using Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class WFUsers : System.Web.UI.Page
    {
        UsersLog objUsu = new UsersLog();
        private string _nombre, _correo, _contrasena, _rol;
        private int _idUsers;
        private bool executed = false;

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            _nombre = TBName.Text;
            _correo = TBEmail.Text;
            _contrasena = TBPassword.Text;
            _rol = TBRol.Text;

            executed = objUsu.saveUsers(_nombre, _correo, _contrasena, _rol);

            if (executed)
            {
                LblMsj.Text = "Usuario guardado exitosamente";
                clear();
                showUsers();
            }
            else
            {
                LblMsj.Text = "Usuario no guardada";
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            _idUsers = Convert.ToInt32(HFUsersId.Value);
            _nombre = TBName.Text;
            _correo = TBEmail.Text;
            _contrasena = TBPassword.Text;
            _rol = TBRol.Text;

            executed = objUsu.updateUser(_idUsers, _nombre, _correo, _contrasena, _rol);

            if (executed)
            {
                LblMsj.Text = "Usuario actualizado exitosamente";
                clear();
                showUsers();
            }
            else
            {
                LblMsj.Text = "Usuario no actualizado";
            }
        }

        protected void GVUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            HFUsersId.Value = GVUsers.SelectedRow.Cells[0].Text;
            TBName.Text = GVUsers.SelectedRow.Cells[1].Text;
            TBEmail.Text = GVUsers.SelectedRow.Cells[2].Text;
            TBPassword.Text = GVUsers.SelectedRow.Cells[3].Text;
            TBRol.Text = GVUsers.SelectedRow.Cells[4].Text;
        }

        protected void GVUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int _id = Convert.ToInt32(GVUsers.DataKeys[e.RowIndex].Values[0]);

            executed = objUsu.deleteUser(_id);
            if (executed)
            {
                LblMsj.Text = "Usuario eliminado exitosamente";
                GVUsers.EditIndex = -1;
                clear();
                showUsers();
            }
            else
            {
                LblMsj.Text = "Usuario no eliminado";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                showUsers();
            }

        }

        private void showUsers()
        {
            DataSet objData = new DataSet();
            objData = objUsu.showUsers();
            GVUsers.DataSource = objData;
            GVUsers.DataBind();
        }

        private void clear()
        {
            TBName.Text = "";
            TBEmail.Text = "";
            TBPassword.Text = "";
            TBRol.Text = "";
        }
    }
}