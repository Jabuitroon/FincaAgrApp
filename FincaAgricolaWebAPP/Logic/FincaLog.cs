using Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;


namespace Logic
{
    public class FincaLog
    {
        FarmDat objFin = new FarmDat();
        public DataSet showFarm()
        {
            return objFin.showFarm();
        }
        public DataSet showFarmDDL()
        {
            return objFin.showFarmDDL();
        }
        public bool saveFarm(string _nombre, string _ubicacion)
        {
            return objFin.saveFarm(_nombre, _ubicacion);
        }
        public bool updateFarm(int _idFarm, string _nombre, string _ubicacion)
        {
            return objFin.updateFarm(_idFarm, _nombre, _ubicacion);
        }
        public bool deleteFarm(int _idFarm)
        {
            return objFin.deleteFarm(_idFarm);
        }

    }  
}