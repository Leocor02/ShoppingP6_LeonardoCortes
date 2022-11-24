using ShoppingP6_LeonardoCortes.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShoppingP6_LeonardoCortes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserManagementPage : ContentPage
    {
        UserViewModel viewModel;

        public UserManagementPage()
        {
            InitializeComponent();

            //se agrega el bindingContext de la vista contra el viewModel
            BindingContext = viewModel = new UserViewModel();

            LoadUserRolesList();
            LoadCountryList();

            //llenar los campos con la data del usuario global
        }

        private void LoadUserData()
        {
            TxtName.Text = GlobalObjects.GlobalUser.Nombre;
            TxtEmail.Text = GlobalObjects.GlobalUser.CorreoElectronico;
            TxtEmailBackUp.Text = GlobalObjects.GlobalUser.CorreoRespaldo;
            TxtPhone.Text = GlobalObjects.GlobalUser.NumeroTelefono;
        }

        private async void LoadUserRolesList()
        {
            PckUserRole.ItemsSource = await viewModel.GetUserRoleList();
        }

        private async void LoadCountryList()
        {
            PckCountry.ItemsSource = await viewModel.GetCountryList();
        }

        private void BtnApply_Clicked(object sender, EventArgs e)
        {

        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}