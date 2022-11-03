using ShoppingP6_LeonardoCortes.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ShoppingP6_LeonardoCortes.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}