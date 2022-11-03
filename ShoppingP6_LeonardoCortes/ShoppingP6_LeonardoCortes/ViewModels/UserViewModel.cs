using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ShoppingP6_LeonardoCortes.Models;

namespace ShoppingP6_LeonardoCortes.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public UserRole MyUserRole { get; set; }

        public Country MyCounty { get; set; }

        public User MyUser { get; set; }

        public UserViewModel()
        {
            MyUserRole = new UserRole();
            MyCounty = new Country();
            MyUser = new User();
        }

        
        public async Task<List<UserRole>> GetUserRoleList()
        {
            try
            {
                List<UserRole> list = new List<UserRole>();

                list = await MyUserRole.GetUserRoles();

                if (list == null)
                {
                    return null;
                }
                else
                {
                    return list;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public async Task<List<Country>> GetCountryList()
        {
            try
            {
                List<Country> list = new List<Country>();

                list = await MyCounty.GetCountries();

                if (list == null)
                {
                    return null;
                }
                else
                {
                    return list;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        //funcion para agregar usuario
        public async Task<bool> AddNewUser(string pName, 
                                           string pEmail,
                                           string pPassword,
                                           string pBkpEmail,
                                           string pPhoneNumber,
                                           int pUserRole = 1,
                                           int pCountry = 1)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyUser.Name = pName;
                MyUser.Email = pEmail;
                MyUser.UserPassword = pPassword;
                MyUser.BackUpEmail = pBkpEmail;
                MyUser.PhoneNumber = pPhoneNumber;
                MyUser.IduserRole = pUserRole;
                MyUser.Idcountry = pCountry;

                bool R = await MyUser.AddUser();

                return R;

            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                IsBusy = false;
            }

           
        }
    }
}
