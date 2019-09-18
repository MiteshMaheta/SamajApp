using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SamajApp.Data;

namespace SamajApp.Helper
{
    public class DatabaseHelper
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public DatabaseHelper()
        {
        }

        public async Task ExecuteQuery(string query)
        {
            if (App.Connection != null)
            {
                try
                {
                    await App.Connection.ExecuteScalarAsync<bool>(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<List<Info>> GetScriptsLoaded(string value = "script")
        {
            if (App.Connection != null)
            {
                try
                {
                    List<Info> info = await App.Connection.QueryAsync<Info>($"select * from info where value = '{value}'");
                    //await App.Connection.CloseAsync();
                    return info;
                }
                catch (Exception ex)
                {
                    logger.Error(ex, ex.Message);
                }
            }
            return new List<Info>();
        }

        public async Task SaveInfo(string key, string value)
        {
            if (App.Connection != null)
            {
                try
                {
                    await App.Connection.ExecuteAsync("insert into info values (?,?)", key, value);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public async Task<int> GetTableCount()
        {
            if (App.Connection != null)
            {
                return await App.Connection.ExecuteScalarAsync<int>("select count(*) from sqlite_master");
            }
            else
                return 0;
        }

    }
}
