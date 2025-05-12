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
        public bool saveParcel(int _dimenciones, string _ubicacion, int _fkfinca, int _fkclima)
        {
            
            return objPar.saveParcel(_dimenciones, _ubicacion, _fkfinca, _fkclima);

        }
        public bool updateParcel(int _idParcela, int _dimenciones, string _ubicacion, int _fkfinca, int _fkclima)
        {

            return objPar.updateParcel(_idParcela, _dimenciones, _ubicacion, _fkfinca, _fkclima);

        }
        public bool deleteParcel(int _idParcela)
        {
           
            return objPar.deleteParcel(_idParcela);

        }
    }
}