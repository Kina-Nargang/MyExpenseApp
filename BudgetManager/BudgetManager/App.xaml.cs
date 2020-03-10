using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BudgetManager
{
    public partial class App : Application
    {
        public static string FolderPath { get; set; }

        public App()
        {
            InitializeComponent();

            FolderPath = Environment.GetFolderPath
                (Environment.SpecialFolder.LocalApplicationData);

            MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.FromHex("#151515"),
                BarTextColor = Color.Beige
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
