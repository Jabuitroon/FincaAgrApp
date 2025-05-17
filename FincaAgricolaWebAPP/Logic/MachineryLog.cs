using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Logic
{
    public class MachineryLog
    {
        private readonly MachineryDat objMac = new MachineryDat();

        public DataSet ShowMachinery()
        {
            return objMac.ShowMachinery();
        }
        public DataSet ShowMaquinariaDDL()
        {
            return objMac.ShowMaquinariaDDL();
        }
        public bool SaveMachinery(string _nombre, string _descripcion, string _clasificacion, int _fkCultivoId, int _fkParcelaId)
        {
            return objMac.SaveMachinery(_nombre, _descripcion, _clasificacion, _fkCultivoId, _fkParcelaId);
        }
        public bool UpdateMachinery(int _idMachinery, string _nombre, string _descripcion, string _clasificacion, int _fkCultivoId, int _fkParcelaId)
        {
            return objMac.UpdateMachinery(_idMachinery, _nombre, _descripcion, _clasificacion, _fkCultivoId, _fkParcelaId);
        }
        public bool DeleteMachinery(int _idMachinery)
        {
            return objMac.DeleteMachinery(_idMachinery);
        }
    }
}