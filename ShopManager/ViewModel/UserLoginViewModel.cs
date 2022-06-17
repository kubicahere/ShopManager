using ShopManager.DAL.Entities;
using ShopManager.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManager.ViewModel
{
    class UserLoginViewModel : BaseViewModel
    {
        #region Attributes
        private string _isVisible = "Hidden";
        private string _login = string.Empty;
        private string _password = string.Empty;
        private ObservableCollection<string> _listOfProducts;
        private ObservableCollection<Purchase> _listOfPurchases;
        private string _selectedProduct = null;

        
        #endregion
    }
}
