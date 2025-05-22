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
        private readonly ProductsDat objPro = new ProductsDat();
        public DataSet ShowProducts()
        {
            return objPro.ShowProducts();
        }
        public DataSet ShowProductDDL()
        {           
            return objPro.ShowProductDDL();
        }
        public bool SaveProducts(string _name, string _description, int _quantity, int _content, double _price, string _img, int _fkFarm, int _fkCategory)
        {
            return objPro.SaveProducts(_name, _description, _quantity, _content, _price, _img, _fkFarm, _fkCategory);
        }
        public bool UpdateProducts(int _idProduct, string _name, string _description, int _quantity, int _content, double _price, string _img, int _fkFarm, int _fkCategory)
        {
            return objPro.updateProducts(_idProduct, _name, _description, _quantity, _content, _price, _img, _fkFarm, _fkCategory);
        }
        public bool DeleteProducts(int _idProduct)
        {
            return objPro.DeleteProducts(_idProduct);   
        }
    }
}