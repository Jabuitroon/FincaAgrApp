using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Logic
{
    public class SaleLog
    {
        SaleDat objSale = new SaleDat();
        public DataSet showSale()
        {
            return objSale.showSale();
        }
        public DataSet shoSaleDDL()
        {
            return objSale.showSale();
        }
        public bool saveSale(DateTime _fecha, int _fkProId, int _fkCliId, int _total)
        {
            return objSale.saveSale(_fecha, _fkProId, _fkCliId, _total);
        }
        public bool updateSale(int _idSale, DateTime _fecha, int _total, int _fkProdId, int _fkProId, int _fkCatId, int _fkCliId)
        {
            return objSale.updateSale(_idSale, _fecha, _total, _fkProdId, _fkProId, _fkCatId, _fkCliId);
        }
        public bool deleteSale(int _idSale)
        {
            return objSale.deleteSale(_idSale);
        }
    }
}