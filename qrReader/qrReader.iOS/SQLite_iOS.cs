using SQLite;
using qrReader.iOS;
using Xamarin.Forms;
[assembly: Dependency(typeof(SQLite_iOS))]

namespace qrReader.iOS
{
    public class SQLite_iOS : DBConnectionInterface
    {
        public SQLiteConnection GetConnection()
        {
            var DB_Name = "Models.sql";
            var Path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var Full_Path = Path + "\\" + DB_Name;
            var Connection = new SQLiteConnection(Full_Path);
            return Connection;
        }
    }
}