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
    public class WeatherLog
    {
        WeatherDat objWea = new WeatherDat();

        public bool saveWeather(float _temperatura, string _humedad)
        {
            return objWea.saveWeather(_temperatura, _humedad);
        }
        public DataSet showWeather()
        {
            return objWea.showWeather();
        }

        public DataSet showWeatherDDL()
        {
            return objWea.showWeatherDDL();
        }
        public bool updateWeather(int _idWeather, float _temperatura, string _humedad)
        {
            return objWea.updateWeather(_idWeather, _temperatura, _humedad);
        }
        public bool deleteWeather(int _idWeather)
        {
            return objWea.deleteWeather(_idWeather);
        }
    }
}