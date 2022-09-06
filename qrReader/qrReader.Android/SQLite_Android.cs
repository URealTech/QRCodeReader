using SQLite;
using qrReader.Droid;
using Xamarin.Forms;
[assembly: Dependency(typeof(SQLite_Android))]

namespace qrReader.Droid
{
    public class SQLite_Android : DBConnectionInterface
    {
        public SQLiteConnection GetConnection()
        {
            var DB_Name = "Models.sql";
            var Path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var Full_Path = Path + "\\" + DB_Name;
            var Connection = new SQLiteConnection(Full_Path);
            return Connection;
        }
    }
}