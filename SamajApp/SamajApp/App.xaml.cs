using System;
using System.Collections.Generic;
using System.Linq;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using SamajApp.Data;
using SamajApp.Helper;
using SamajApp.Views;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SamajApp
{
    public partial class App : PrismApplication
    {
        public static SQLiteAsyncConnection Connection;
        public static DatabaseHelper DbHelper;

        public App() : this(null) { }
        public App(IPlatformInitializer initializer = null) : base(initializer) { }
        protected override void OnInitialized()
        {
            InitializeComponent();
            DbHelper = new DatabaseHelper();
            GetConnection();
        }

        public static void GetConnection()
        {
            if (Connection == null)
                Connection = DependencyService.Get<ISqlite>().GetConnection();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<AppMasterPage>();
           
        }

        protected async override void OnStart()
        {
            base.OnStart();
            List<string> sqlFiles = TableInfo.Tables;
            if (sqlFiles != null && sqlFiles.Count > 0)
            {
                List<Info> sqlexecuted = new List<Info>();
                if (await App.DbHelper.GetTableCount() > 1)
                    sqlexecuted = await App.DbHelper.GetScriptsLoaded();
                foreach (string item in sqlFiles)
                {
                    if (sqlexecuted != null && sqlexecuted.Count(e => e.key.Equals(item)) == 0)
                    {
                        string file = DependencyService.Get<IFileHelper>().GetFile(item);
                        if (!string.IsNullOrEmpty(file))
                        {
                            List<string> queries = new List<string>(file.Split(';'));
                            foreach (string query in queries)
                            {
                                if (!string.IsNullOrEmpty(query))
                                {
                                    await DbHelper.ExecuteQuery(query);
                                }
                            }
                            await DbHelper.SaveInfo(item, "script");
                        }
                    }
                }
            }
            //Authenticate();
            //await NavigationService.NavigateAsync("LoginPage");
            await NavigationService.NavigateAsync("//AppMasterPage/NavigationPage/MainPage");
            //Xamarin.Forms.MessagingCenter.Subscribe<ActivityResult>(this, "success", Navigate);
        }

        protected async override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected async override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
