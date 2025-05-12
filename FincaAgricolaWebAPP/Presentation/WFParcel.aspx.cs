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
    public partial class WFParcel : System.Web.UI.Page
    {
        ParcelLog objPar = new ParcelLog();
        FincaLog objFin = new FincaLog();
        WeatherLog objWeat = new WeatherLog();
        private int _idParcel, _fkfinca, _fkclima;
        private int _dimenciones;
        private string _ubicacion;

        
        private bool executed = false;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                showParcel();
                showFarmDDL();
                showWeatherDDL();
                
            }
        }
        private void showParcel()
        {
            DataSet objData = new DataSet();
            objData = objPar.showParcel();
            GVParcel.DataSource = objData;
            GVParcel.DataBind();
        }
        private void showFarmDDL()
        {
            DDLFarm.DataSource = objFin.showFarmDDL();
            DDLFarm.DataValueField = "fin_id";
            DDLFarm.DataTextField = "nombre";
            DDLFarm.DataBind();
            DDLFarm.Items.Insert(0, "Seleccione");
        }

        private void showWeatherDDL()

        {  
            DDLWeather.DataSource = objWeat.showWeatherDDL();
            DDLWeather.DataValueField = "clim_id";
            DDLWeather.DataTextField = "temperatura";
            DDLWeather.DataBind();
            DDLWeather.Items.Insert(0, "Seleccione");
        }
        private void clear()
        {
            TBDimensiones.Text = "";
            TBUbicacion.Text = "";
            DDLFarm.SelectedIndex = 0;
            DDLWeather.SelectedIndex = 0;
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            _dimenciones = Convert.ToInt32(TBDimensiones.Text); 
            _ubicacion = TBUbicacion.Text;
            _fkfinca = Convert.ToInt32(DDLFarm.Text);
            _fkclima = Convert.ToInt32(DDLWeather.Text);
            executed = objPar.saveParcel(_dimenciones, _ubicacion, _fkfinca, _fkclima);

            if (executed)
            {
                LblMsj.Text = "La parcela se guardo exitosamente!";
                showParcel();
                clear();
            }
            else
            {
                LblMsj.Text = "Error al guardar";
            }
        }

        protected void GVParcel_SelectedIndexChanged(object sender, EventArgs e)
        {
            HFParcelId.Value = GVParcel.SelectedRow.Cells[0].Text;
            TBDimensiones.Text = GVParcel.SelectedRow.Cells[1].Text;
            TBUbicacion.Text = GVParcel.SelectedRow.Cells[2].Text;
            DDLFarm.SelectedValue = GVParcel.SelectedRow.Cells[3].Text;
            DDLWeather.SelectedValue = GVParcel.SelectedRow.Cells[5].Text;
            
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            _idParcel = Convert.ToInt32(HFParcelId.Value);
            _dimenciones = Convert.ToInt32(TBDimensiones.Text);
            _ubicacion = TBUbicacion.Text;
            _fkfinca = Convert.ToInt32(DDLFarm.Text);
            _fkclima = Convert.ToInt32(DDLWeather.Text);

            executed = objPar.updateParcel(_idParcel, _dimenciones, _ubicacion, _fkfinca, _fkclima);
            if (executed)
            {
                LblMsj.Text = "La parcela se actualizó exitosamente";
                clear();
                showParcel();
            }
            else
            {
                LblMsj.Text = "La parcela no se actualizó";
            }


        }
        protected void GVParcel_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int _idParcel = Convert.ToInt32(GVParcel.DataKeys[e.RowIndex].Values[0]);

            executed = objPar.deleteParcel(_idParcel);
            if (executed)
            {
                LblMsj.Text = "La parcela se elimino exitosamente";
                GVParcel.EditIndex = -1;
                clear();
                showParcel();
            }
            else
            {
                LblMsj.Text = "Parcela no eliminada";
            }
        }
    }
}