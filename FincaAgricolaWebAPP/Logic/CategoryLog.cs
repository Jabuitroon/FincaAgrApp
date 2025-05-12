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
    public class CategoryLog
    {
        CategoryDat objCat = new CategoryDat();

        public DataSet showCategory()
        {
            return objCat.showCategory();
        }
        public DataSet showCategoryDDL()
        {
            return objCat.showCategoryDDL();
        }
        public bool saveCategory(string _nombre, string _description)
        {
            return objCat.saveCategory(_nombre, _description);
        }
        public bool updateCategory(int _idCategory, string _nombre, string _description)
        {
            return objCat.updateCategory(_idCategory, _nombre, _description);
        }
        public bool deleteCategory(int _idCategory)
        {
            return objCat.deleteCategory(_idCategory);
        }
    }
}