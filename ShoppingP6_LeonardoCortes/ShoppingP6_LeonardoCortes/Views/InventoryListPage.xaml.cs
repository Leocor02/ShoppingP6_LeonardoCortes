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
    public partial class InventoryListPage : ContentPage
    {

        InventoryViewModel vm;

        public InventoryListPage()
        {
            InitializeComponent();

            BindingContext = vm = new InventoryViewModel();

            LoadItemList();
        }

        private async void LoadItemList()
        {
            LstInventory.ItemsSource = await vm.GetFullInventoryList();
        }
    }
}