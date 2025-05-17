using Logic;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Presentation
{
    public partial class WFIrrigation : System.Web.UI.Page
    {
        IrrigationLog objIrrigation = new IrrigationLog();
        CropLog objCrop = new CropLog();
        ParcelLog objParcel = new ParcelLog();

        int _idRiego, _fkCultivoId, _fkParId;
        string _tipo, _cantidad, _frecuencia;


        private bool executed = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                showIrrigation();
                showCropDDL();
                showParcelDDL();
            }
        }

        private void showIrrigation() {
            DataSet objData = new DataSet();
            objData = objIrrigation.showIrrigation();
            GVIrrigation.DataSource = objData;
            GVIrrigation.DataBind();
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
            TBType.Text = "";
            TBWater.Text = "";
            TBFrequency.Text = "";
            DDLCrops.SelectedIndex = 0;
            DDLParcela.SelectedIndex = 0;
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            _tipo = TBType.Text;
            _cantidad = TBWater.Text;
            _frecuencia = TBFrequency.Text;
            _fkCultivoId = Convert.ToInt32(DDLCrops.SelectedValue);
            _fkParId = Convert.ToInt32(DDLParcela.SelectedValue);

            executed = objIrrigation.saveImputs(_tipo, _cantidad, _frecuencia, _fkCultivoId, _fkParId);
            if (executed)
            {
                LblMsj.Text = "Riego guardado exitosamente";
                clear();
                showIrrigation();
            }
            else
            {
                LblMsj.Text = "Riego no guardado";
            }
        }

        protected void GVIrrigation_SelectedIndexChanged(object sender, EventArgs e)
        {
            HFIrrigationId.Value = GVIrrigation.SelectedRow.Cells[2].Text;
            TBType.Text = GVIrrigation.SelectedRow.Cells[3].Text;
            TBWater.Text = GVIrrigation.SelectedRow.Cells[4].Text;
            TBFrequency.Text = GVIrrigation.SelectedRow.Cells[5].Text;
            DDLCrops.SelectedValue = GVIrrigation.SelectedRow.Cells[6].Text;
            DDLParcela.SelectedValue = GVIrrigation.SelectedRow.Cells[7].Text;
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            _idRiego = Convert.ToInt32(HFIrrigationId.Value);
            _tipo = TBType.Text;
            _cantidad = TBWater.Text;
            _frecuencia = TBFrequency.Text;
            _fkCultivoId = Convert.ToInt32(DDLCrops.SelectedValue);
            _fkParId = Convert.ToInt32(DDLParcela.SelectedValue);
            
            executed = objIrrigation.updateIrrigation(_idRiego, _tipo, _cantidad, _frecuencia, _fkCultivoId, _fkParId);
            if (executed)
            {
                LblMsj.Text = "El Riego se actualizó exitosamente";
                clear();
                showIrrigation();
            }
            else
            {
                LblMsj.Text = "El Riego no se actualizó";
            }
        }

        protected void GVIrrigation_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int _idRiego = Convert.ToInt32(GVIrrigation.DataKeys[e.RowIndex].Values[0]);
            executed = objIrrigation.deleteIrrigation(_idRiego);
            if (executed)
            {
                LblMsj.Text = "Riego eliminado exitosamente";
                GVIrrigation.EditIndex = -1;
                clear();
                showIrrigation();
            }
            else
            {
                LblMsj.Text = "Riego no eliminado";
            }
        }
    }
}