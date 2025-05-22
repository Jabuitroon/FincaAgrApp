using Logic;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class WFProducts : System.Web.UI.Page
    {
        private readonly ProductsLog objProducts = new ProductsLog();
        private readonly FincaLog objFinca = new FincaLog();
        private readonly CategoryLog objCategory = new CategoryLog();

        private int _idProduct, _quantity, _content, _fkFarm, _fkCategory;
        private string _name, _description, _img;
        private double _price;

        private bool executed = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                showProducts();
                showFarmDDL();
                showCategoriesDDL();
            }
        }

        private void showProducts() {
            DataSet objData = new DataSet();
            objData = objProducts.ShowProducts();
            GVPriducts.DataSource = objData;
            GVPriducts.DataBind();
        }

        private void showFarmDDL()
        {
            DDLFinca.DataSource = objFinca.showFarmDDL();
            DDLFinca.DataValueField = "fin_id";
            DDLFinca.DataTextField = "nombre";
            DDLFinca.DataBind();
            DDLFinca.Items.Insert(0, "Seleccione una finca");
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
            DDLFinca.SelectedIndex = 0;
            DDLCategory.SelectedIndex = 0;
        }

        protected void GVPriducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            HFProductId.Value = GVPriducts.SelectedRow.Cells[0].Text;
            TBName.Text = GVPriducts.SelectedRow.Cells[1].Text;
            TBDescription.Text = GVPriducts.SelectedRow.Cells[2].Text;
            TBCantidad.Text = GVPriducts.SelectedRow.Cells[3].Text;
            TBContenido.Text = GVPriducts.SelectedRow.Cells[4].Text;
            TBPrecio.Text = GVPriducts.SelectedRow.Cells[5].Text;
            TBImg.Text = GVPriducts.SelectedRow.Cells[6].Text;
            DDLFinca.SelectedValue = GVPriducts.SelectedRow.Cells[7].Text;
            DDLCategory.SelectedValue = GVPriducts.SelectedRow.Cells[9].Text;
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            _name = TBName.Text;
            _description = TBDescription.Text;
            _quantity = Convert.ToInt32(TBCantidad.Text);
            _content = Convert.ToInt32(TBContenido.Text);
            _price =  Convert.ToDouble(TBPrecio.Text);
            _img = TBImg.Text;

            _fkFarm = Convert.ToInt32(DDLFinca.SelectedValue);
            _fkCategory = Convert.ToInt32(DDLCategory.SelectedValue);
            
            executed = objProducts.SaveProducts(_name, _description, _quantity, _content, _price, _img, _fkFarm, _fkCategory);

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
            _content = Convert.ToInt32(TBContenido.Text);
            _price = Convert.ToDouble(TBPrecio.Text);
            _img = TBImg.Text;

            _fkFarm = Convert.ToInt32(DDLFinca.SelectedValue);
            _fkCategory = Convert.ToInt32(DDLCategory.SelectedValue);

            executed = objProducts.UpdateProducts(_idProduct, _name, _description, _quantity, _content, _price, _img, _fkFarm, _fkCategory);

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

            executed = objProducts.DeleteProducts(_idProduct);
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