using SQLite;

namespace qrReader
{
    public interface DBConnectionInterface
    {
        SQLiteConnection GetConnection();
    }
}
