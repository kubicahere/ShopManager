using ShopManager.DAL.Entities;
using ShopManager.DAL.Repositories;
using ShopManager.Model;
using ShopManager.View.Windows;
using ShopManager.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        //VISIBILITY OF BUYING ETC
        private string _isVisibleUserWindow = "Visible";
        private string _isVisibleBuying = "Hidden";
        private string _isVisiblePurchaseHistory = "Hidden";
        private string _isVisibleAccountSettings = "Hidden";
        //CLIENT PURCHASE HISTORY
        private ObservableCollection<string> _listOfTransactions = new ObservableCollection<string>();
        private string _selectedTransaction = string.Empty;
        private ObservableCollection<string> _listOfInfo = new ObservableCollection<string>();
        #endregion
        #region Getters & setters
        public string isVisible { get { return _isVisible; } set { _isVisible = value; OnPropertyChanged(nameof(isVisible)); } }
        public string login { get { return _login; } set { _login = value; OnPropertyChanged(nameof(login)); } }
        public string password { get { return _password; } set { _password = value; OnPropertyChanged(nameof(password)); } }
        public ObservableCollection<string> listOfProducts { get { return _listOfProducts; } set { _listOfProducts = value; OnPropertyChanged(nameof(listOfProducts)); } }
        public ObservableCollection<Purchase> listOfPurchases { get { return _listOfPurchases; } set { _listOfPurchases = value; OnPropertyChanged(nameof(listOfPurchases)); } }
        public string selectedProduct { get { return _selectedProduct; } set { _selectedProduct = value; OnPropertyChanged(nameof(selectedProduct)); } }
        public string isVisibleUserWindow { get { return _isVisibleUserWindow; } set { _isVisibleUserWindow = value; OnPropertyChanged(nameof(isVisibleUserWindow)); } }
        public string isVisibleBuying { get { return _isVisibleBuying; } set { _isVisibleBuying = value; OnPropertyChanged(nameof(isVisibleBuying)); } }
        public string isVisiblePurchaseHistory { get { return _isVisiblePurchaseHistory; } set { _isVisiblePurchaseHistory = value; OnPropertyChanged(nameof(isVisiblePurchaseHistory)); } }
        public string isVisibleAccountSettings { get { return _isVisibleAccountSettings; } set { _isVisibleAccountSettings = value; OnPropertyChanged(nameof(isVisibleAccountSettings)); } }
        public ObservableCollection<string> listOfTransactions { get { return _listOfTransactions; } set { _listOfTransactions = value; OnPropertyChanged(nameof(listOfTransactions)); } }
        public string selectedTransaction { get { return _selectedTransaction; } set { _selectedTransaction = value; OnPropertyChanged(nameof(selectedTransaction)); } }
        public ObservableCollection<string> listOfInfo { get { return _listOfInfo; } set { _listOfInfo = value; OnPropertyChanged(nameof(listOfInfo)); } }

        #endregion
        public StartWindowViewModel startWindow { get; set; }
        public UserMainWindow userMainWindow { get; set; }
        public MainViewModel viewModel { get; set; }
        public User userModel { get; set; }
        public UserLoginViewModel()
        {
            listOfTransactions.Add("TEST");
            listOfTransactions.Add("TEST");
            listOfTransactions.Add("TEST");
        }

        #region Methods
        public void ClearData()
        {
            login = string.Empty;
            password = string.Empty;
        }
        public bool CheckData()
        {
            if (login == "root") return false;
            Client singleClient = RepoClients.GetClientByLoginAndPasswd(login, password);
            if (singleClient.Login == login && singleClient.Password == password)
                return true;
            return false;
        }
        public void LoginUser(object sender)
        {
            if (!CheckData())
            {
                ClearData();
                return;
            }
            userMainWindow = new UserMainWindow();
            userMainWindow.DataContext = this;
            userMainWindow.Show();
            ClearData();
        }
        public void BackButton(object sender)
        {
            ClearData();
            startWindow.isVisible = "Visible";
            isVisible = "Hidden";
        }
        #endregion
        #region Window methods
        public void LogOut(object sender)
        {
            userMainWindow.Close();
        }
        public void GoShopping(object sender)
        {
            isVisibleUserWindow = "Hidden";
            isVisibleBuying = "Visible";
        }
        public void PurchaseHistory(object sender)
        {
            isVisibleUserWindow = "Hidden";
            isVisiblePurchaseHistory = "Visible";
        }
        public void AccountSettings(object sender)
        {
            isVisibleUserWindow = "Hidden";
            isVisibleAccountSettings = "Visible";
        }
        #endregion
        #region Purchase window methods

        #endregion
        #region Purchase history window methods
        public void LoadCustomerPurchases(object sender)
        {
            listOfTransactions.Clear();
            Client singleClient = RepoClients.GetClientByLoginAndPasswd(login, password);
            ObservableCollection<Purchase> clientPurchases = RepoPurchases.GetClientPurchasesById(singleClient);
            for(int i = 0; i < clientPurchases.Count; i++)
            {
                listOfTransactions.Add($"Order no.{clientPurchases[i].Id}");
            }
        }
        public void PurchaseBackButton(object sender)
        {
            isVisiblePurchaseHistory = "Hidden";
            isVisibleUserWindow = "Visible";
        }
        public void PurchaseListChanged(object sender)
        {

        }
        #endregion
        #region Account Setting window methods
        #endregion
    }
}
