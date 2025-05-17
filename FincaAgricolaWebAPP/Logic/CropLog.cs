using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;
using Data;

namespace Logic
{
    public class CropLog
    {
        private readonly CropDat objCro = new CropDat();
        public bool SaveCrops(string _nombre, string _descripcion, int _fkParcelaId)
        {
            return objCro.SaveCrops(_nombre, _descripcion, _fkParcelaId);
        }

        public DataSet ShowCrops()
        {
            return objCro.ShowCrops();
        }

        public DataSet ShowCropsDDL()
        {
            return objCro.ShowCropsDDL();
        }

        public bool UpdateCrops(int _idCultivo, string _nombre, string _descripcion, int _fkParcelaId)
        {
            return objCro.UpdateCrops(_idCultivo, _nombre, _descripcion, _fkParcelaId);
        }

        public bool DeleteCrops(int _idCultivo) { 
            return objCro.DeleteCrops(_idCultivo);
        }
    }
}