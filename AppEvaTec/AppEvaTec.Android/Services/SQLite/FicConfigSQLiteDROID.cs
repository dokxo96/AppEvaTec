using System.IO;
using Xamarin.Forms;
using AppEvaTec.Interfaces.SQLite;
using AppEvaTec.Droid.Services.SQLite;

[assembly: Dependency(typeof(FicConfigSQLiteDROID))]
namespace AppEvaTec.Droid.Services.SQLite
{
    public class FicConfigSQLiteDROID : IFicConfigSQLiteNETStd

    {
        public string FicGetDatabasePath()
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, AppSettings.ficDatabaseName);
        }
    }
}