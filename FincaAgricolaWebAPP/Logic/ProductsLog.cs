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
    public class ProductsLog
    {
        ProductsDat objPro = new ProductsDat();
        public DataSet showProducts()
        {
            return objPro.showProducts();
        }
        public DataSet showProductDDL()
        {           
            return objPro.showProductDDL();
        }
        public bool saveProducts(string _name, string _description, int _quantity, double _price, string _img, int _fkProvider, int _fkCategory)
        {
            return objPro.saveProducts(_name, _description, _quantity, _price, _img, _fkProvider, _fkCategory);
        }
        public bool updateProducts(int _idProduct, string _name, string _description, int _quantity, double _price, string _img, int _fkProvider, int _fkCategory)
        {
            return objPro.updateProducts(_idProduct, _name, _description, _quantity, _price, _img, _fkProvider, _fkCategory);
        }
        public bool deleteProducts(int _idProduct)
        {
            return objPro.deleteProducts(_idProduct);   
        }
    }
}