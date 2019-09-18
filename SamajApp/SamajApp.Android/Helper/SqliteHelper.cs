using System;
using System.IO;
using SamajApp.Droid.Helper;
using SamajApp.Helper;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqliteHelper))]
namespace SamajApp.Droid.Helper
{
    public class SqliteHelper : ISqlite
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public SqliteHelper()
        {
        }
        public SQLiteAsyncConnection GetConnection()
        {
            try
            {
                string DBName = "SamajAppDB.sqlite";
                var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal, System.Environment.SpecialFolderOption.Create), DBName);
                Console.WriteLine("Database Path:" + Path.GetFullPath(path));
                if (!File.Exists(path))
                {
                    using (var asset = Android.App.Application.Context.Assets.Open(DBName))
                    using (var dest = File.Create(path))
                        asset.CopyTo(dest);
                }
                return new SQLiteAsyncConnection(path, SQLiteOpenFlags.ReadWrite, false);
            }
            catch (Exception e)
            {
                logger.Error(e, e.Message);
            }
            return null;
        }
    }
}
