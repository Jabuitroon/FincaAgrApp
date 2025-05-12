using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Logic
{
    public class InputsLog
    {
        InputsDatcs objInput = new InputsDatcs();

        public DataSet showInputs()
        {
            return objInput.showInputs();
        }
        public DataSet showInputsDDL()
        {
            return objInput.showInputsDDL();
        }
        public bool saveImputs(string _nombre, string _tipo, string _cantidad, int _fkCultivoId, int _fkParcelaId)
        {
            return objInput.saveInputs( _nombre,  _tipo,  _cantidad,  _fkCultivoId,  _fkParcelaId);
        }
        public bool updateInputs(int _idInputs, string _nombre, string _tipo, string _cantidad, int _fkCultivoId, int _fkParcelaId)
        {
            return objInput.updateInputs( _idInputs, _nombre,  _tipo,  _cantidad, _fkCultivoId,  _fkParcelaId);
        }
        public bool deleteInputs(int _idInputs)
        {
            return objInput.deleteInputs(_idInputs);
        }
    }
}