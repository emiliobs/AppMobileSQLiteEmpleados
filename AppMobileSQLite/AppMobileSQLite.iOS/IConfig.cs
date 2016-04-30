using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using SQLite.Net.Interop;


namespace AppMobileSQLite
{
   public interface IConfig
    {
        //propiedad donde nos retorna el directorio de la BD y  donde almacena la BD:
        string DirectorioDB { get; }

        //nos dice a que pataforma obtenemos el directorio de datos:
         ISQLitePlatform plataforma { get; }
    }
}
