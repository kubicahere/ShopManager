using ShopManager.DAL.Entities;
using ShopManager.View.Windows;
using ShopManager.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManager.ViewModel
{
    class RootLoginViewModel : BaseViewModel
    {
        #region Attributes
        private string _isVisible = "Hidden";
        private string _login = string.Empty;
        private string _password = string.Empty;
        private ObservableCollection<string> _listOfProducts;
        private ObservableCollection<Purchase> _listOfPurchases;
        private string _selectedProduct = null;
        #endregion

        #region Getters & setters
        public string isVisible { get { return _isVisible; } set { _isVisible = value; OnPropertyChanged(nameof(isVisible)); } }
        public string login { get { return _login; } set { _login = value; OnPropertyChanged(nameof(login)); } }
        public string password { get { return _password; } set { _password = value; OnPropertyChanged(nameof(password)); } }
        public ObservableCollection<string> listOfProducts { get { return _listOfProducts; } set { _listOfProducts = value; OnPropertyChanged(nameof(listOfProducts)); } }
        public ObservableCollection<Purchase> listOfPurchases { get { return _listOfPurchases; } set { _listOfPurchases = value; OnPropertyChanged(nameof(listOfPurchases)); } }
        public string selectedProduct { get { return _selectedProduct; } set { _selectedProduct = value; OnPropertyChanged(nameof(selectedProduct)); } }
        #endregion

        #region ViewModel instances
        public StartWindowViewModel startWindow { get; set; }
        public RootMainWindow rootMainWindow { get; set; }
        public MainViewModel viewModel { get; set; }

        #endregion

        #region Methods
        public void ClearData()
        {
            login = string.Empty;
            password = string.Empty;
        }
        public bool CheckData()
        {
            if (login != "root" || password != "root")
                return false;
            return true;
        }
        public void LoginRoot(object sender)
        {
            if(!CheckData())
            {
                ClearData();
                return;
            }
            rootMainWindow = new RootMainWindow();
            rootMainWindow.DataContext = this;
            rootMainWindow.Show();
            ClearData();
        }
        public void BackButton(object sender)
        {
            ClearData();
            startWindow.isVisible = "Visible";
            isVisible = "Hidden";
        }
        //TODO WINDOW METHODS
        #endregion
    }
}
