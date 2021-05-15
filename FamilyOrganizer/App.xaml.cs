using FamilyOrganizer.DB.Seed;
using FamilyOrganizer.User;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
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

        public App()
        {
            
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Context = new FamilyOrganizerContext();
            Context.Photos.Load();
            Context.AppUsers.Load();
            Context.Transactions.Load();
            Context.Balances.Load();
            Context.Comments.Load();
            Context.ShoppingPlans.Load();
            Context.TodayPlans.Load();

            //Seed.SeedTransactions(Context); seed shopping list
            //Seed.SeedBalances(Context); seed photos
            Seed.SeedPhotos(Context);
           

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
            
        }
    }
}
