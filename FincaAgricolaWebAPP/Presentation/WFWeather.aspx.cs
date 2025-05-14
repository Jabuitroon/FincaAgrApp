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
    public partial class WFWeather : System.Web.UI.Page
    {
        WeatherLog objWeat = new WeatherLog();
        private int _idWeather;
        private float _temperatura;
        private string _humedad;
        private bool executed = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                showWeather();
                HFWhatherId.Visible = false;
            }
        }
        //Metodo para mostrar todos los climas
        private void showWeather()
        {
            DataSet ds = new DataSet();
            ds = objWeat.showWeather();
            GVWeather.DataSource = ds;
            GVWeather.DataBind();
        }
        //Metodo para limpiar las cajas de texto 
        private void clear()
        {

            HFWhatherId.Value = "";
            TBTemperatra.Text = "";
            TBHumedad.Text = "";

        }
        //Evento que se ejecuta al dar clic en el boton Guardar
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            _temperatura = Convert.ToSingle(TBTemperatra.Text); // Convert to float explicitly  
            _humedad = TBHumedad.Text;

            executed = objWeat.saveWeather(_temperatura, _humedad);

            if (executed)
            {
                LblMsj.Text = "El clima se guardo exitosamente!";
                showWeather();
                clear();
            }
            else
            {
                LblMsj.Text = "Error al guardar";
            }
        }
        //Evento que se ejecuta al dar clic en el boton Actualizar
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            _idWeather = Convert.ToInt32(HFWhatherId.Value);
            _temperatura = Convert.ToSingle(TBTemperatra.Text); // Convert to float explicitly  
            _humedad = TBHumedad.Text;

            executed = objWeat.updateWeather(_idWeather, _temperatura, _humedad);

            if (executed)
            {
                LblMsj.Text = "El clima se Actualizo exitosamente!";
                showWeather();
                clear();
            }
            else
            {
                LblMsj.Text = "Error al Actualizar";
            }
        }
        protected void GVWeather_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int _idWeather = Convert.ToInt32(GVWeather.DataKeys[e.RowIndex].Values[0]);
            executed = objWeat.deleteWeather(_idWeather);
            if (executed)
            {
                LblMsj.Text = "Clima eliminada exitosamente";
                GVWeather.EditIndex = -1;
                clear();
                showWeather();
            }
            else
            {
                LblMsj.Text = "Clima no eliminado";
            }
        }

        protected void GVWeather_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Se asigna el ID del producto al campo de texto TBId.
            HFWhatherId.Value = GVWeather.SelectedRow.Cells[0].Text;
            TBTemperatra.Text = GVWeather.SelectedRow.Cells[1].Text;
            TBHumedad.Text = GVWeather.SelectedRow.Cells[2].Text;
        }
    }
}