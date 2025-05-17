using Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Presentation
{
    public partial class WFSale : System.Web.UI.Page
    {
        ProductsLog objProduct = new ProductsLog();
        ClienteLog objClient = new ClienteLog();
        SaleLog objSale = new SaleLog();

        int idSale, _total, _fkProId, _fkCliId;
        DateTime _fecha;


        private bool executed = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                showSale();
                showProductsDDL();
                showClientDDL();
            }

        }
        private void showSale()
            {
                DataSet objData = new DataSet();
                objData = objSale.showSale();
                GVSale.DataSource = objData;
                GVSale.DataBind();
            }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void showProductsDDL()
        {
            DDLProcucts.DataSource = objProduct.showProductDDL();
            DDLProcucts.DataValueField = "pro_id";
            DDLProcucts.DataTextField = "pro_nombre";
            DDLProcucts.DataBind();
            DDLProcucts.Items.Insert(0, "Seleccione");
        }
        private void showClientDDL()
        {
            DDLClients.DataSource = objClient.ShowClienteDDL();
            DDLClients.DataValueField = "cli_id";
            DDLClients.DataTextField = "NombreCompleto";
            DDLClients.DataBind();
            DDLClients.Items.Insert(0, "Seleccione");
        }

        private void clear()
        {
            DDLProcucts.SelectedIndex = 0;
            DDLClients.SelectedIndex = 0;
            TBTotal.Text = "";
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            // idSale = Convert.ToInt32(TBPrecio.Text);
            _fecha = Convert.ToDateTime(Calendar.SelectedDate);
            _fkProId = Convert.ToInt32(DDLProcucts.SelectedValue);
            _fkCliId = Convert.ToInt32(DDLClients.SelectedValue);
            _total = Convert.ToInt32(TBTotal.Text);

            executed = objSale.saveSale(_fecha, _fkProId, _fkCliId, _total);

            if (executed)
            {
                LblMsj.Text = "Vendido !!";
                clear();
                showSale();
            }
            else
            {
                LblMsj.Text = "No se pudo vender";
                Console.WriteLine(_fecha);
            }
        }

        protected void GVSale_SelectedIndexChanged(object sender, EventArgs e)
        {
            HFSaleId.Value = GVSale.SelectedRow.Cells[2].Text;
            Calendar.SelectedDate = Convert.ToDateTime(GVSale.SelectedRow.Cells[3].Text);
            DDLProcucts.SelectedValue = GVSale.SelectedRow.Cells[4].Text;
            DDLClients.SelectedValue = GVSale.SelectedRow.Cells[5].Text;
        }

        protected void GVSale_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int _idSale = Convert.ToInt32(GVSale.DataKeys[e.RowIndex].Values[0]);

            executed = objSale.deleteSale(_idSale);
            if (executed)
            {
                LblMsj.Text = "Registro eliminado exitosamente";
                GVSale.EditIndex = -1;
                clear();
                showSale();
            }
            else
            {
                LblMsj.Text = "Registro no eliminado";
            }

        }
    }
}