using Logic;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class WFProducts : System.Web.UI.Page
    {
        ProductsLog objProducts = new ProductsLog();
        SupplierLog objSupplier = new SupplierLog();
        CategoryLog objCategory = new CategoryLog();

        private int _idProduct, _quantity, _fkProvider, _fkCategory;
        private string _name, _description, _img;
        private double _price;

        private bool executed = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                showProducts();
                showSuppliersDDL();
                showCategoriesDDL();
            }
        }

        private void showProducts() {
            DataSet objData = new DataSet();
            objData = objProducts.showProducts();
            GVPriducts.DataSource = objData;
            GVPriducts.DataBind();
        }

        private void showSuppliersDDL()
        {
            DDLSupplier.DataSource = objSupplier.showSupplierDDL();
            DDLSupplier.DataValueField = "pro_id";
            DDLSupplier.DataTextField = "nombreProveedor";
            DDLSupplier.DataBind();
            DDLSupplier.Items.Insert(0, "Seleccione un Producto");
        }

        private void showCategoriesDDL()
        {
            DDLCategory.DataSource = objCategory.showCategoryDDL();
            DDLCategory.DataValueField = "cat_id";
            DDLCategory.DataTextField = "nombre";
            DDLCategory.DataBind();
            DDLCategory.Items.Insert(0, "Seleccione una Categoría");
        }

        private void clear()
        {
            TBName.Text = "";
            TBDescription.Text = "";
            TBCantidad.Text = "";
            TBPrecio.Text = "";
            DDLSupplier.SelectedIndex = 0;
            DDLCategory.SelectedIndex = 0;
        }

        protected void GVPriducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            HFProductId.Value = GVPriducts.SelectedRow.Cells[0].Text;
            TBName.Text = GVPriducts.SelectedRow.Cells[1].Text;
            TBDescription.Text = GVPriducts.SelectedRow.Cells[2].Text;
            TBCantidad.Text = GVPriducts.SelectedRow.Cells[3].Text;
            TBPrecio.Text = GVPriducts.SelectedRow.Cells[4].Text;
            TBImg.Text = GVPriducts.SelectedRow.Cells[5].Text;
            DDLSupplier.SelectedValue = GVPriducts.SelectedRow.Cells[6].Text;
            DDLCategory.SelectedValue = GVPriducts.SelectedRow.Cells[8].Text;
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            _name = TBName.Text;
            _description = TBDescription.Text;
            _quantity = Convert.ToInt32(TBCantidad.Text);
            _price =  Convert.ToDouble(TBPrecio.Text);
            _img = TBImg.Text;
            _fkProvider = Convert.ToInt32(DDLSupplier.SelectedValue);
            _fkCategory = Convert.ToInt32(DDLCategory.SelectedValue);
            
            executed = objProducts.saveProducts(_name, _description, _quantity, _price, _img, _fkProvider, _fkCategory);

            if (executed)
            {
                LblMsj.Text = "Producto guardado exitosamente";
                clear();
                showProducts();
            }
            else
            {
                LblMsj.Text = "Producto no guardad";
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            _idProduct = Convert.ToInt32(HFProductId.Value);
            _name = TBName.Text;
            _description = TBDescription.Text;
            _quantity = Convert.ToInt32(TBCantidad.Text);
            _price = Convert.ToDouble(TBPrecio.Text);
            _img = TBImg.Text;
            _fkProvider = Convert.ToInt32(DDLSupplier.SelectedValue);
            _fkCategory = Convert.ToInt32(DDLCategory.SelectedValue);

            executed = objProducts.updateProducts(_idProduct, _name, _description, _quantity, _price, _img, _fkProvider, _fkCategory);

            if (executed)
            {
                LblMsj.Text = "El Producto se actualizó exitosamente";
                clear();
                showProducts();
            }
            else
            {
                LblMsj.Text = "El Producto no se actualizó";
            }
        }

        protected void GVProduct_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int _idProduct = Convert.ToInt32(GVPriducts.DataKeys[e.RowIndex].Values[0]);

            executed = objProducts.deleteProducts(_idProduct);
            if (executed)
            {
                LblMsj.Text = "Producto eliminado exitosamente";
                GVPriducts.EditIndex = -1;
                clear();
                showProducts();
            }
            else
            {
                LblMsj.Text = "Producto no eliminado";
            }

        }
    }
}