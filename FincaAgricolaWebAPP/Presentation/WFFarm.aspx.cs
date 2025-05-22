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
	public partial class WFFarm : System.Web.UI.Page
	{
		FincaLog objFarm = new FincaLog();
        private string _nombre, _ubicacion;
        private int _idFarm;
		private bool executed = false;
        protected void Page_Load(object sender, EventArgs e)
		{
            if (!Page.IsPostBack)
            {
                showFarm();
            }
        }

        private void showFarm()
        {
            DataSet objData = new DataSet();
            objData = objFarm.showFarm();
            GVFarm.DataSource = objData;
            GVFarm.DataBind();
        }
        private void clear()
        {
            TBName.Text = "";
            TBLocation.Text = "";
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            _nombre = TBName.Text;
            _ubicacion = TBLocation.Text;

            executed = objFarm.saveFarm(_nombre, _ubicacion);

            if (executed)
            {
                LblMsj.Text = "Finca guardada exitosamente";
                clear();
                showFarm();
            }
            else
            {
                LblMsj.Text = "Finca no guardada";
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            _idFarm = Convert.ToInt32(HFFarmId.Value);
            _nombre = TBName.Text;
            _ubicacion = TBLocation.Text;

            executed = objFarm.updateFarm(_idFarm, _nombre, _ubicacion);

            if (executed)
            {
                LblMsj.Text = "Finca actualizada exitosamente";
                clear();
                showFarm();
            }
            else
            {
                LblMsj.Text = "Finca no actualizada";
            }
        }

        protected void GVFarm_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int _id = Convert.ToInt32(GVFarm.DataKeys[e.RowIndex].Values[0]);

            executed = objFarm.deleteFarm(_id);
            if (executed)
            {
                LblMsj.Text = "Finca eliminada exitosamente";
                GVFarm.EditIndex = -1;
                clear();
                showFarm();
            }
            else
            {
                LblMsj.Text = "Finca no eliminada";
            }
        }

        protected void GVFarm_SelectedIndexChanged(object sender, EventArgs e)
        {
            HFFarmId.Value = GVFarm.SelectedRow.Cells[0].Text;
            TBName.Text = GVFarm.SelectedRow.Cells[1].Text;
            TBLocation.Text = GVFarm.SelectedRow.Cells[2].Text;
        }

        protected void gvData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.CssClass = "data-row";
            }
            // Aplicar clase a una celda
            Label lblNombre = (Label)e.Row.FindControl("lblNombre");
            lblNombre.CssClass = "nombre-celda";
        }
    }
}