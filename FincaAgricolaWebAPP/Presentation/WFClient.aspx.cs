using Logic;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class WFClient : System.Web.UI.Page
    {
        ClienteLog objClient = new ClienteLog();
        private string _nombre, _correo, _contrasena, _direccion, _ciudad;
        private int idClient;
        private bool executed =  false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                showClient();
            }
        }
        private void showClient()
        {
            DataSet objData = new DataSet();
            objData = objClient.showCliente();
            GVClient.DataSource = objData;
            GVClient.DataBind();
        }
        private void clear()
        {
            TBName.Text = "";
            TBEmail.Text = "";
            TBPassword.Text = "";
            TBLocation.Text = "";
            TBCity.Text = "";
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            idClient = Convert.ToInt32(HFClientId.Value);
            _nombre = TBName.Text;
            _correo = TBEmail.Text;
            _contrasena = TBPassword.Text;
            _direccion = TBLocation.Text;
            _ciudad = TBCity.Text;

            executed = objClient.updateCliente(idClient, _nombre, _correo, _contrasena, _direccion, _ciudad);

            if (executed)
            {
                LblMsj.Text = "Cliente actualizado exitosamente";
                clear();
                showClient();
            }
            else
            {
                LblMsj.Text = "Cliente no actualizado";
            }
        }

        protected void GVClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            HFClientId.Value = GVClient.SelectedRow.Cells[0].Text;
            TBName.Text = GVClient.SelectedRow.Cells[1].Text;
            TBEmail.Text = GVClient.SelectedRow.Cells[2].Text;
            TBPassword.Text = GVClient.SelectedRow.Cells[3].Text;
            TBLocation.Text = GVClient.SelectedRow.Cells[4].Text;
            TBCity.Text = GVClient.SelectedRow.Cells[5].Text;
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            _nombre = TBName.Text;
            _correo = TBEmail.Text;
            _contrasena = TBPassword.Text;
            _direccion = TBLocation.Text;
            _ciudad = TBCity.Text;


            executed = objClient.saveCliente(_nombre, _correo, _contrasena, _direccion, _ciudad);

            if (executed)
            {
                LblMsj.Text = "Cliente guardado exitosamente";
                clear();
                showClient();
            }
            else
            {
                LblMsj.Text = "Cliente no guardado";
            }
        }

        protected void GVClient_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int _id = Convert.ToInt32(GVClient.DataKeys[e.RowIndex].Values[0]);

            executed = objClient.deleteCliente(_id);
            if (executed)
            {
                LblMsj.Text = "Cliente eliminado exitosamente";
                GVClient.EditIndex = -1;
                clear();
                showClient();
            }
            else
            {
                LblMsj.Text = "Cliente no eliminado";
            }
        }

    }
}