using ShoppingP6_LeonardoCortes.Services;
using ShoppingP6_LeonardoCortes.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShoppingP6_LeonardoCortes
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();

            //Con esto indicamos en cual lista empieza la app
            MainPage = new NavigationPage(new AppLoginPage());
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
