using ShoppingP6_LeonardoCortes.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;


namespace ShoppingP6_LeonardoCortes.ViewModels
{
    public class InventoryViewModel : BaseViewModel
    {
        public Inventory MyInventory { get; set; }

        public InventoryViewModel()
        {
            MyInventory = new Inventory();
        }

            public async Task<ObservableCollection<Inventory>> GetFullInventoryList()
            {
                if (IsBusy)
                {
                    return null;
                }
                else
                {
                    IsBusy = true;

                    try
                    {
                        ObservableCollection<Inventory> list = new ObservableCollection<Inventory>();

                        list = await MyInventory.GetFullInventoryList();

                        if (list == null)
                        {
                            return null;
                        }

                        return list;
                    }
                    catch (Exception)
                    {

                        return null;
                    }
                    finally { IsBusy = false; }
                }
            }
    }
}


