using FamilyOrganizer.DB.Seed;
using FamilyOrganizer.User;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace FamilyOrganizer
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public FamilyOrganizerContext Context { get; set; }
        const string AppId = "FAMILY ORGANIZER";
        static Mutex mutex = new Mutex(false, AppId);
        static bool mutexAccessed = false;

        public App()
        {

        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            try
            {
                if (mutex.WaitOne(0))
                    mutexAccessed = true;
            }
            catch (AbandonedMutexException)
            {
                mutexAccessed = true;
            }

            if (mutexAccessed)
                base.OnStartup(e);
            else
            {
                MessageBox.Show("FamilyOrganizer is running");
                Shutdown();
                return;
            }

            var ss = new SplashScreen();
            ss.Show();
            Context = new FamilyOrganizerContext();
            await Context.Photos.LoadAsync();
            await Context.AppUsers.LoadAsync();
            await Context.Transactions.LoadAsync();
            await Context.Balances.LoadAsync();
            await Context.Comments.LoadAsync();
            await Context.ShoppingPlans.LoadAsync();
            await Context.TodayPlans.LoadAsync();


            //Seed.SeedTransactions(Context);
            //Seed.SeedBalances(Context);
            //Seed.SeedPhotos(Context);


            if (Context.AppUsers.Count() == 0)
            {
                var r = new Register(Context, true);
                r.Show();
            }
            else
            {
                var l = new Login(Context);
                l.Show();
            }
            ss.Close();

        }

        protected override void OnExit(ExitEventArgs e)
        {
            if (mutexAccessed)
                mutex?.ReleaseMutex();

            mutex?.Dispose();
            mutex = null;
            base.OnExit(e);
        }
    
    }
}
