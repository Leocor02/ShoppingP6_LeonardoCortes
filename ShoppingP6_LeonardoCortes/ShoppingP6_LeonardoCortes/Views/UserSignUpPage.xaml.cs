using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ShoppingP6_LeonardoCortes.ViewModels;

namespace ShoppingP6_LeonardoCortes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserSignUpPage : ContentPage
    {
        UserViewModel viewModel;

        public UserSignUpPage()
        {
            InitializeComponent();

            //se agrega el bindingContext de la vista contra el viewModel
            BindingContext = viewModel = new UserViewModel();   

            LoadUserRolesList();
            LoadCountryList();
        }

        private async void LoadUserRolesList()
        {
            PckUserRole.ItemsSource = await viewModel.GetUserRoleList();
        }

        private async void LoadCountryList()
        {
            PckCountry.ItemsSource = await viewModel.GetCountryList();
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();    
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            //En este caso la llamada al a funcionalidad no será por Command
            //TODO: implementar Command

            bool R = await viewModel.AddNewUser(TxtName.Text.Trim(),
                                                TxtEmail.Text.Trim(),
                                                TxtPassword.Text.Trim(),
                                                TxtEmailBackUp.Text.Trim(),
                                                TxtPhone.Text.Trim());

            if (R)
            {
                await DisplayAlert(":)", "Everything is OK", "OK");
                await Navigation.PopAsync();    
            }
            else
            {
                await DisplayAlert(":(", "Something went wrong", "OK");
            }
        }
    }
}