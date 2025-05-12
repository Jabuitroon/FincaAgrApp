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
        MachineryDat objMac = new MachineryDat();

        public DataSet showMachinery()
        {
            return objMac.showMachinery();
        }
        public DataSet showMaquinariaDDL()
        {
            return objMac.showMaquinariaDDL();
        }
        public bool saveMachinery(string _nombre, string _descripcion, string _clasificacion, int _fkCultivoId, int _fkParcelaId)
        {
            return objMac.saveMachinery(_nombre, _descripcion, _clasificacion, _fkCultivoId, _fkParcelaId);
        }
        public bool updateMachinery(int _idMachinery, string _nombre, string _descripcion, string _clasificacion, int _fkCultivoId, int _fkParcelaId)
        {
            return objMac.updateMachinery(_idMachinery, _nombre, _descripcion, _clasificacion, _fkCultivoId, _fkParcelaId);
        }
        public bool deleteMachinery(int _idMachinery)
        {
            return objMac.deleteMachinery(_idMachinery);
        }
    }
}