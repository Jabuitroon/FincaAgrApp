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
        MachineryLog objMac = new MachineryLog();
        CropLog objCrop = new CropLog();
        ParcelLog objParcel = new ParcelLog();
        private int _idMachinery, _fkCrop, _fkParcel;
        private string _nombre, _descripcion, _clasificacion;
        private bool executed = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                showMachinery();
                showCropDDL();
                showParcelDDL();
            }
        }

        protected void GVMachinery_SelectedIndexChanged(object sender, EventArgs e)
        {
            HFMachineryId.Value = GVMachinery.SelectedRow.Cells[0].Text;
            TBName.Text = GVMachinery.SelectedRow.Cells[1].Text;
            TBDescription.Text = GVMachinery.SelectedRow.Cells[2].Text;
            TBClassification.Text = GVMachinery.SelectedRow.Cells[3].Text;
            DDLCrops.SelectedValue = GVMachinery.SelectedRow.Cells[4].Text;
            DDLParcela.SelectedValue = GVMachinery.SelectedRow.Cells[5].Text;
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            _nombre = TBName.Text;
            _descripcion = TBDescription.Text;
            _clasificacion = TBClassification.Text;
            _fkCrop = Convert.ToInt32(DDLCrops.SelectedValue);
            _fkParcel = Convert.ToInt32(DDLParcela.SelectedValue);
            executed = objMac.saveMachinery(_nombre, _descripcion, _clasificacion, _fkCrop, _fkParcel);
            if (executed)
            {
                LblMsj.Text = "Maquinaria guardada exitosamente";
                clear();
                showMachinery();
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
            executed = objMac.updateMachinery(_idMachinery, _nombre, _descripcion, _clasificacion, _fkCrop, _fkParcel);
            if (executed)
            {
                LblMsj.Text = "La Maquinaria se actualizó exitosamente";
                clear();
                showMachinery();
            }
            else
            {
                LblMsj.Text = "La Maquinaria no se actualizó";
            }
        }

        protected void GVMachinery_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int _idInputs = Convert.ToInt32(GVMachinery.DataKeys[e.RowIndex].Values[0]);
            executed = objMac.deleteMachinery(_idInputs);
            if (executed)
            {
                LblMsj.Text = "Maquinaria eliminada exitosamente";
                GVMachinery.EditIndex = -1;
                clear();
                showMachinery();
            }
            else
            {
                LblMsj.Text = "Maquinaria no eliminada";
            }
        }

        private void showMachinery()
        {
            DataSet objData = new DataSet();
            objData = objMac.showMachinery();
            GVMachinery.DataSource = objData;
            GVMachinery.DataBind();
        }

        private void showCropDDL()
        {
            DDLCrops.DataSource = objCrop.showCropsDDL();
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
            TBDescription.Text = "";
            TBClassification.Text = "";
            DDLCrops.SelectedIndex = 0;
            DDLParcela.SelectedIndex = 0;
        }
    }
}