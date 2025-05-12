using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Logic
{
    public class SupplierLog
    {
        SupplierDat objSupp = new SupplierDat();

        public DataSet showSupplier()
        {
            return objSupp.showSupplier();
        }
        public DataSet showSupplierDDL()
        {
            return objSupp.showSupplierDDL();
        }
        public bool saveSupplier(int _nit, string _name, int _fkFincaId)
        {
            return objSupp.saveSupplier(_nit, _name, _fkFincaId);
        }
        public bool updateSupplier(int _idSupp, int _nit, string _name, int _fkFincaId)
        {
            return objSupp.updateSupplier(_idSupp, _nit, _name, _fkFincaId);
        }
        public bool deleteSupplier(int _idSupp)
        {
            return objSupp.deleteSupplier(_idSupp);
        }
    }
}