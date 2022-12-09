using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingP6_LeonardoCortes.Services
{
    public static class CnnToP6API
    {
        //En esta clase se definen las rutas de consumo del API
        //Además se define la info de API key necesaria para poder consumir los controladores.

        public static string ProductionURL = "http://192.168.0.6:45455/api/";
        public static string TestingURL = "http://192.168.0.5:45455/api/";

        public static string ApiKeyName = "P6ApiKey";
        public static string ApiKeyValue = "P6shoppingQwerty1234/*";

    }
}
