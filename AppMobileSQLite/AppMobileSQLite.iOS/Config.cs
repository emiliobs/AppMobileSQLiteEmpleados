using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Interop;
using static System.Environment;
using System.IO;
//
using Xamarin.Forms;


[assembly: Dependency(typeof(AppMobileSQLite.iOS.Config))]
namespace AppMobileSQLite.iOS
{
    public class Config : IConfig
    {
        private string directorioDB;
        private ISQLitePlatform plataforma;

        public string DirectorioDB
        {
            //obtener plataforma en iOS:
            get
            {
                if (string.IsNullOrEmpty(directorioDB))
                {
                    var directorio = Environment.GetFolderPath(SpecialFolder.Personal);
                    directorioDB = Path.Combine(directorio, ". ." , "Library");
                }

                return directorioDB;
            }
        }

        public object GetFolderPatch { get; private set; }

        ISQLitePlatform IConfig.plataforma
        {
            get
            {
                if (plataforma == null)
                {
                    plataforma = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
                }

                return plataforma;
            }
        }
    }
}
