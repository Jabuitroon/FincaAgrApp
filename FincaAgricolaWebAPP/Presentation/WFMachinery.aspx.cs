using Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class WFMachinery : System.Web.UI.Page
    {
        private readonly MachineryLog objMac = new MachineryLog();
        private readonly CropLog objCrop = new CropLog();
        private readonly ParcelLog objParcel = new ParcelLog();

        private int _idMachinery, _fkCrop, _fkParcel;
        private string _nombre, _descripcion, _clasificacion;
        private bool executed = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ShowMachinery();
                ShowCropDDL();
                ShowParcelDDL();
            }
        }

        protected void GVMachinery_SelectedIndexChanged(object sender, EventArgs e)
        {
            HFMachineryId.Value = GVMachinery.SelectedRow.Cells[0].Text;
            TBName.Text = GVMachinery.SelectedRow.Cells[1].Text;
            TBDescription.Text = GVMachinery.SelectedRow.Cells[2].Text;
            TBClassification.Text = GVMachinery.SelectedRow.Cells[3].Text;
            DDLCrops.SelectedValue = GVMachinery.SelectedRow.Cells[4].Text;
            DDLParcela.SelectedValue = GVMachinery.SelectedRow.Cells[6].Text;
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            _nombre = TBName.Text;
            _descripcion = TBDescription.Text;
            _clasificacion = TBClassification.Text;
            _fkCrop = Convert.ToInt32(DDLCrops.SelectedValue);
            _fkParcel = Convert.ToInt32(DDLParcela.SelectedValue);
            executed = objMac.SaveMachinery(_nombre, _descripcion, _clasificacion, _fkCrop, _fkParcel);
            if (executed)
            {
                LblMsj.Text = "Maquinaria guardada exitosamente";
                Clear();
                ShowMachinery();
            }
            else
            {
                LblMsj.Text = "Maquinaria no guardada";
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            _idMachinery = Convert.ToInt32(HFMachineryId.Value);
            _nombre = TBName.Text;
            _descripcion = TBDescription.Text;
            _clasificacion = TBClassification.Text;
            _fkCrop = Convert.ToInt32(DDLCrops.SelectedValue);
            _fkParcel = Convert.ToInt32(DDLParcela.SelectedValue);
            executed = objMac.UpdateMachinery(_idMachinery, _nombre, _descripcion, _clasificacion, _fkCrop, _fkParcel);
            if (executed)
            {
                LblMsj.Text = "La Maquinaria se actualizó exitosamente";
                Clear();
                ShowMachinery();
            }
            else
            {
                LblMsj.Text = "La Maquinaria no se actualizó";
            }
        }

        protected void GVMachinery_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int _idInputs = Convert.ToInt32(GVMachinery.DataKeys[e.RowIndex].Values[0]);
            executed = objMac.DeleteMachinery(_idInputs);
            if (executed)
            {
                LblMsj.Text = "Maquinaria eliminada exitosamente";
                GVMachinery.EditIndex = -1;
                Clear();
                ShowMachinery();
            }
            else
            {
                LblMsj.Text = "Maquinaria no eliminada";
            }
        }

        private void ShowMachinery()
        {
            DataSet objData = new DataSet();
            objData = objMac.ShowMachinery();
            GVMachinery.DataSource = objData;
            GVMachinery.DataBind();
        }

        private void ShowCropDDL()
        {
            DDLCrops.DataSource = objCrop.ShowCropsDDL();
            DDLCrops.DataValueField = "cul_id";
            DDLCrops.DataTextField = "nombreCultivo";
            DDLCrops.DataBind();
            DDLCrops.Items.Insert(0, "Seleccione");
        }

        private void ShowParcelDDL()
        {
            DDLParcela.DataSource = objParcel.showParcelDDL();
            DDLParcela.DataValueField = "par_id";
            DDLParcela.DataTextField = "nombre";
            DDLParcela.DataBind();
            DDLParcela.Items.Insert(0, "Seleccione");
        }

        private void Clear()
        {
            TBName.Text = "";
            TBDescription.Text = "";
            TBClassification.Text = "";
            DDLCrops.SelectedIndex = 0;
            DDLParcela.SelectedIndex = 0;
        }
    }
}