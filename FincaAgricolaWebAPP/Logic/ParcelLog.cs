using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;

namespace Logic
{
    public class ParcelLog
    {
        ParcelDat objPar = new ParcelDat();
        public DataSet showParcel()
        {

            return objPar.showParcel();

        }
        public DataSet showParcelDDL()
        {
            
            return objPar.showParcelDDL();
        }
        public bool saveParcel(int _dimenciones, string _ubicacion, double _Temperatura, double _Humedad, int _fkfinca)
        {
            
            return objPar.saveParcel(_dimenciones, _ubicacion, _Temperatura, _Humedad, _fkfinca);

        }
        public bool updateParcel(int _idParcela, int _dimenciones, string _ubicacion, double _Temperatura, double _Humedad, int _fkfinca)
        {

            return objPar.updateParcel(_idParcela, _dimenciones, _ubicacion, _Temperatura, _Humedad, _fkfinca);

        }
        public bool deleteParcel(int _idParcela)
        {
           
            return objPar.deleteParcel(_idParcela);

        }
    }
}