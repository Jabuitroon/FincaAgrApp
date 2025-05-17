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
        CropDat objCro = new CropDat();
        public bool SaveCrops(string _nombre, string _descripcion, int _fkParcelaId)
        {
            return objCro.SaveCrops(_nombre, _descripcion, _fkParcelaId);
        }

        public DataSet showCrops()
        {
            return objCro.showCrops();
        }

        public DataSet showCropsDDL()
        {
            return objCro.showCropsDDL();
        }

        public bool updateCrops(int _idCultivo, string _nombre, string _descripcion, int _fkParcelaId)
        {
            return objCro.updateCrops(_idCultivo, _nombre, _descripcion, _fkParcelaId);
        }

        public bool deleteCrops(int _idCultivo) { 
            return objCro.deleteCrops(_idCultivo);
        }
    }
}