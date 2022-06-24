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
        private string _purchaseDate = string.Empty;
        private string _productName = string.Empty;
        private string _clientName = string.Empty;
        private string _purchaseListPrice = string.Empty;
        //ACCOUNT SETTINGS ELEMENTS
        private string _accountFirstname = string.Empty;
        private string _accountSurname = string.Empty;
        private string _accountLogin = string.Empty;
        private string _accountPassword = string.Empty;
        private string _accountRepeatPassword = string.Empty;
        private string _accountEmailAddress = string.Empty;
        private string _accountPhoneNumber = string.Empty;
        private string _canEdit = "True";

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
        public string purchaseDate { get { return _purchaseDate; } set { _purchaseDate = value; OnPropertyChanged(nameof(purchaseDate)); } }
        public string productName { get { return _productName; } set { _productName = value; OnPropertyChanged(nameof(productName)); } }
        public string clientName { get { return _clientName; } set { _clientName = value; OnPropertyChanged(nameof(clientName)); } }
        public string purchaseListPrice { get { return _purchaseListPrice; } set { _purchaseListPrice = value; OnPropertyChanged(nameof(purchaseListPrice)); } }
        //ACCOUNT DATA
        public string accountFirstname { get { return _accountFirstname; } set { _accountFirstname = value; OnPropertyChanged(nameof(accountFirstname)); } }
        public string accountSurname { get { return _accountSurname; } set { _accountSurname = value; OnPropertyChanged(nameof(accountSurname)); } }
        public string accountLogin { get { return _accountLogin; } set { _accountLogin = value; OnPropertyChanged(nameof(accountLogin)); } }
        public string accountPassword { get { return _accountPassword; } set { _accountPassword = value; OnPropertyChanged(nameof(accountPassword)); } }
        public string accountRepeatPassword { get { return _accountRepeatPassword; } set { _accountRepeatPassword = value; OnPropertyChanged(nameof(accountRepeatPassword)); } }
        public string accountEmailAddress { get { return _accountEmailAddress; } set { _accountEmailAddress = value; OnPropertyChanged(nameof(accountEmailAddress)); } }
        public string accountPhoneNumber { get { return _accountPhoneNumber; } set { _accountPhoneNumber = value; OnPropertyChanged(nameof(accountPhoneNumber)); } }
        public string canEdit { get { return _canEdit; } set { _canEdit = value; OnPropertyChanged(nameof(canEdit)); } }

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
            //ClearData();
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
            LoadCustomerPurchases(true);
        }
        public void AccountSettings(object sender)
        {
            isVisibleUserWindow = "Hidden";
            isVisibleAccountSettings = "Visible";
            Client client = new Client();
            client = RepoClients.GetClientByLoginAndPasswd(login, password);
            accountLogin = client.Login;
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
                listOfTransactions.Add(clientPurchases[i].ToString());
            }
        }
        public void PurchaseBackButton(object sender)
        {
            isVisiblePurchaseHistory = "Hidden";
            isVisibleUserWindow = "Visible";
        }
        public void PurchaseListChanged(object sender)
        {
            int index = listOfTransactions.IndexOf(selectedTransaction);
            Client singleClient = RepoClients.GetClientByLoginAndPasswd(login, password);
            ObservableCollection<Purchase> transactions = RepoPurchases.GetClientPurchasesById(singleClient);
            Purchase purchase = new Purchase(transactions[index]);
            purchaseDate = purchase.PurchaseDate;
            productName = purchase.ProductName;
            clientName = purchase.Client_name + " " + purchase.Client_surname;
            purchaseListPrice = purchase.Price.ToString(); 
        }
        #endregion
        #region Account Setting window methods
        //todo check data
        public void SettingsBackButton(object sender)
        {
            isVisibleAccountSettings = "Hidden";
            isVisibleUserWindow = "Visible";
        }
        public void EditUser(object sender)
        {
            //TODO
        }

        #endregion
    }
}
