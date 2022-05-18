using LocalStorageDb.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LocalStorageDb
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ListadoClientesPage();
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
