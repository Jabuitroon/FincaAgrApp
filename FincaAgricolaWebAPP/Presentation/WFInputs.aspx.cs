
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
    public partial class WFInputs : System.Web.UI.Page
    {
        InputsLog objInputs = new InputsLog();
        CropLog objCrop = new CropLog();
        ParcelLog objParcel = new ParcelLog();
        private int _idInputs, _fkCrop, _fkParcel;
        private string _nombre, _Tipo, _cantidad;
        private bool executed = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                showInputs();
                showCropDDL();
                showParcelDDL();
            }
        }
        private void showInputs()
        {
            DataSet objData = new DataSet();
            objData = objInputs.showInputs();
            GVInputs.DataSource = objData;
            GVInputs.DataBind();
        }
        private void showCropDDL()
        {
            DDLCrops.DataSource = objCrop.ShowCropsDDL();
            DDLCrops.DataValueField = "cul_id";
            DDLCrops.DataTextField = "nombreCultivo";
            DDLCrops.DataBind();
            DDLCrops.Items.Insert(0, "Seleccione");
        }
        private void showParcelDDL()
        {
            DDLParcela.DataSource = objParcel.showParcelDDL();
            DDLParcela.DataValueField = "par_id";
            DDLParcela.DataTextField = "nombre";
            DDLParcela.DataBind();
            DDLParcela.Items.Insert(0, "Seleccione");
        }

        private void clear()
        {
            TBName.Text = "";
            TBTipo.Text = "";
            TBQuantity.Text = "";
            DDLCrops.SelectedIndex = 0;
            DDLParcela.SelectedIndex = 0;
        }
        protected void GVInputs_SelectedIndexChanged(object sender, EventArgs e)
        {
            HFInputsId.Value = GVInputs.SelectedRow.Cells[0].Text;
            TBName.Text = GVInputs.SelectedRow.Cells[1].Text;
            TBTipo.Text = GVInputs.SelectedRow.Cells[2].Text;
            TBQuantity.Text = GVInputs.SelectedRow.Cells[3].Text;
            DDLCrops.SelectedValue = GVInputs.SelectedRow.Cells[4].Text;
            DDLParcela.SelectedValue = GVInputs.SelectedRow.Cells[6].Text;
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            _nombre = TBName.Text;
            _Tipo = TBTipo.Text;
            _cantidad = TBQuantity.Text;
            _fkCrop = Convert.ToInt32(DDLCrops.SelectedValue);
            _fkParcel = Convert.ToInt32(DDLParcela.SelectedValue);
            executed = objInputs.saveImputs(_nombre, _Tipo, _cantidad, _fkCrop, _fkParcel);
            if (executed)
            {
                LblMsj.Text = "Insumo guardado exitosamente";
                clear();
                showInputs();
            }
            else
            {
                LblMsj.Text = "Insumo no guardado";
            }
        }
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            _idInputs = Convert.ToInt32(HFInputsId.Value);
            _nombre = TBName.Text;
            _Tipo = TBTipo.Text;
            _cantidad = TBQuantity.Text;
            _fkCrop = Convert.ToInt32(DDLCrops.SelectedValue);
            _fkParcel = Convert.ToInt32(DDLParcela.SelectedValue);
            executed = objInputs.updateInputs(_idInputs, _nombre, _Tipo, _cantidad, _fkCrop, _fkParcel);
            if (executed)
            {
                LblMsj.Text = "El Insumo se actualizó exitosamente";
                clear();
                showInputs();
            }
            else
            {
                LblMsj.Text = "El Insumo no se actualizó";
            }
        }
        protected void GVInputs_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int _idInputs = Convert.ToInt32(GVInputs.DataKeys[e.RowIndex].Values[0]);
            executed = objInputs.deleteInputs(_idInputs);
            if (executed)
            {
                LblMsj.Text = "Insumo eliminado exitosamente";
                GVInputs.EditIndex = -1;
                clear();
                showInputs();
            }
            else
            {
                LblMsj.Text = "Insumo no eliminado";
            }
        }
    }
}