using SQLite;

namespace SamajApp.Helper
{
    public interface ISqlite
    {
        SQLiteAsyncConnection GetConnection();
    }
}
