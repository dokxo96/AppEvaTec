using System.IO;
using AppEvaTec.Interfaces.SQLite;
using AppEvaTec.UWP.Services.SQLite;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(FicConfigSQLiteUWP))]
namespace AppEvaTec.UWP.Services.SQLite
{
    class FicConfigSQLiteUWP : IFicConfigSQLiteNETStd
    {
        public string FicGetDatabasePath()
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, AppSettings.ficDatabaseName);
        }
    }
}