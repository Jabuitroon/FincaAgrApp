using Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class WFSupplier : System.Web.UI.Page
    {
        SupplierLog objSupplier = new SupplierLog();
        FincaLog objFarm = new FincaLog();

        private string _name;
        private int _id, _nit, _fkFincaId;
        private bool executed = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                showSuppliers();
                showFarmDDL();
            }
        }

        private void showSuppliers() { 
            DataSet ds = new DataSet();
            ds = objSupplier.showSupplier();
            GVSupplier.DataSource = ds;
            GVSupplier.DataBind();
        }

        private void showFarmDDL() {
            DDLFarm.DataSource = objFarm.showFarmDDL();
            DDLFarm.DataValueField = "fin_id";
            DDLFarm.DataTextField = "nombre";
            DDLFarm.DataBind();
            DDLFarm.Items.Insert(0, "Seleccione una Finca");
        }

        private void clear()
        {
            HFSupplierId.Value = "";
            TBNit.Text = "";
            TBName.Text = "";
            DDLFarm.SelectedIndex = 0;
        }

        protected void GVSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            HFSupplierId.Value = GVSupplier.SelectedRow.Cells[0].Text;
            TBNit.Text = GVSupplier.SelectedRow.Cells[1].Text;
            TBName.Text = GVSupplier.SelectedRow.Cells[2].Text;
            DDLFarm.SelectedValue = GVSupplier.SelectedRow.Cells[3].Text;
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            _nit = Convert.ToInt32(TBNit.Text);
            _name = TBName.Text;
            _fkFincaId = Convert.ToInt32(DDLFarm.SelectedValue);

            executed = objSupplier.saveSupplier(_nit, _name, _fkFincaId);

            if (executed)
            {
                LblMsj.Text = "El Proveedor se guardó exitosamente";
                clear();
                showSuppliers();
            }
            else
            {
                LblMsj.Text = "El Proveedor no se guardó";
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            _id = Convert.ToInt32(HFSupplierId.Value);
            _nit = Convert.ToInt32(TBNit.Text);
            _name = TBName.Text;
            _fkFincaId = Convert.ToInt32(DDLFarm.SelectedValue);

            executed = objSupplier.updateSupplier(_id, _nit, _name, _fkFincaId);

            if (executed)
            {
                LblMsj.Text = "El proveedor se actualizó exitosamente";
                clear();
                showSuppliers();
            }
            else
            {
                LblMsj.Text = "El proveedor no se actualizó";
            }
        }
        protected void GVSupplier_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int _idSupp = Convert.ToInt32(GVSupplier.DataKeys[e.RowIndex].Values[0]);

            executed = objSupplier.deleteSupplier(_idSupp);
            if (executed)
            {
                LblMsj.Text = "Proveedor eliminado exitosamente";
                GVSupplier.EditIndex = -1;
                clear();
                showSuppliers();
            }
            else
            {
                LblMsj.Text = "Proveedor no eliminado";
            }

        }
    }
}