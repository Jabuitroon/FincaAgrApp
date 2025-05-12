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
    public partial class WFCategory : System.Web.UI.Page
    {
        CategoryLog objCategory = new CategoryLog();
        private string _nombre, _description;
        private int _idCategory;

        private bool executed = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                showCategory();
            }
        }

        private void showCategory()
        {
            DataSet objData = new DataSet();
            objData = objCategory.showCategory();
            GVCategory.DataSource = objData;
            GVCategory.DataBind();
        }
        private void clear()
        {
            TBName.Text = "";
            TBDescription.Text = "";
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            _nombre = TBName.Text;
            _description = TBDescription.Text;

            executed = objCategory.saveCategory(_nombre, _description);

            if (executed)
            {
                LblMsj.Text = "Categoría guardada exitosamente";
                clear();
                showCategory();
            }
            else
            {
                LblMsj.Text = "Categoría no guardada";
            }
        }
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            _idCategory = Convert.ToInt32(HFCategoryId.Value);
            _nombre = TBName.Text;
            _description = TBDescription.Text;

            executed = objCategory.updateCategory(_idCategory, _nombre, _description);

            if (executed)
            {
                LblMsj.Text = "Categoría actualizada exitosamente";
                clear();
                showCategory();
            }
            else
            {
                LblMsj.Text = "Categoría no actualizada";
            }
        }

        protected void GVFarm_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int _id = Convert.ToInt32(GVCategory.DataKeys[e.RowIndex].Values[0]);

            Console.WriteLine(_id);

            executed = objCategory.deleteCategory(_id);
            if (executed)
            {
                LblMsj.Text = "Categoría eliminada exitosamente";
                GVCategory.EditIndex = -1;
                clear();
                showCategory();
            }
            else
            {
                LblMsj.Text = "Finca no eliminada";
            }
        }

        protected void GVFarm_SelectedIndexChanged(object sender, EventArgs e)
        {
            HFCategoryId.Value = GVCategory.SelectedRow.Cells[0].Text;
            TBName.Text = GVCategory.SelectedRow.Cells[1].Text;
            TBDescription.Text = GVCategory.SelectedRow.Cells[2].Text;
        }
    }
}