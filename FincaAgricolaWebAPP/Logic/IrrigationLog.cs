using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Logic
{
    public class IrrigationLog
    {
        IrrigationDat objIrrigation = new IrrigationDat();

        public DataSet showIrrigation()
        {
            return objIrrigation.showIrrigation();
        }
        public DataSet showIrrigationDDL()
        {
            return objIrrigation.showIrrigationDDL();
        }
        public bool saveImputs(string _tipo, string _cantidad, string _frecuencia, int _fkCultivoId, int _fkParId)
        {
            return objIrrigation.saveIrrigation(_tipo, _cantidad, _frecuencia, _fkCultivoId, _fkParId);
        }
        public bool updateIrrigation(int _idRiego, string _tipo, string _cantidad, string _frecuencia, int _fkCultivoId, int _fkParId)
        {
            return objIrrigation.updateIrrigation(_idRiego, _tipo, _cantidad, _frecuencia, _fkCultivoId, _fkParId);
        }
        public bool deleteIrrigation(int _idRiego)
        {
            return objIrrigation.deleteIrrigation(_idRiego);
        }
    }
}