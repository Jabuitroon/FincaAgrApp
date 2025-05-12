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
    public partial class WFCrop : System.Web.UI.Page
    {
        CropLog objCrop = new CropLog();
        ParcelLog objPar = new ParcelLog();
        private int _idCultivo, _fkParcelaId;
        private string _nombre;
        private string _descripcion;

        private bool executed = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                showCrops();
                showParcelDDL();


            }
        }
        private void showCrops()
        {
            DataSet objData = new DataSet();
            objData = objCrop.showCrops();
            GVCrop.DataSource = objData;
            GVCrop.DataBind();
        }
        private void showParcelDDL()
        {
            DDLParcel.DataSource = objPar.showParcelDDL();
            DDLParcel.DataValueField = "par_id";
            DDLParcel.DataTextField = "nombre";
            DDLParcel.DataBind();
            DDLParcel.Items.Insert(0, "Seleccione");
        }
        private void clear()
        {
            TBNombre.Text = "";
            TBDescripcion.Text = "";
            DDLParcel.SelectedIndex = 0;
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {

            _nombre = TBNombre.Text;
            _descripcion = TBNombre.Text;
            _fkParcelaId = Convert.ToInt32(DDLParcel.Text);
            executed = objCrop.saveCrops(_nombre, _descripcion, _fkParcelaId);

            if (executed)
            {
                LblMsj.Text = "El cultivo se guardo exitosamente!";
                showCrops();
                clear();
            }
            else
            {
                LblMsj.Text = "Error al guardar";
            }
        }
        protected void GVCrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            HFCultivolId.Value = GVCrop.SelectedRow.Cells[0].Text;
            TBNombre.Text = GVCrop.SelectedRow.Cells[1].Text;
            TBDescripcion.Text = GVCrop.SelectedRow.Cells[2].Text;
            DDLParcel.SelectedValue = GVCrop.SelectedRow.Cells[3].Text;

        }

        

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            _idCultivo = Convert.ToInt32(HFCultivolId.Value);
            _nombre = TBNombre.Text;
            _descripcion = TBNombre.Text;
            _fkParcelaId = Convert.ToInt32(DDLParcel.Text);

            executed = objCrop.updateCrops(_idCultivo, _nombre, _descripcion, _fkParcelaId);
            if (executed)
            {
                LblMsj.Text = "El Cultivo se actualizó exitosamente";
                clear();
                showCrops();
            }
            else
            {
                LblMsj.Text = "El Cultivo no se actualizó";
            }


        }
        protected void GVCrop_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int _idCultivo = Convert.ToInt32(GVCrop.DataKeys[e.RowIndex].Values[0]);

            executed = objCrop.deleteCrops(_idCultivo);
            if (executed)
            {
                LblMsj.Text = "El Cultivo se elimino exitosamente";
                GVCrop.EditIndex = -1;
                clear();
                showCrops();
            }
            else
            {
                LblMsj.Text = "Cultivo no eliminado";
            }
        }

    }
}