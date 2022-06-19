using ShopManager.DAL.Entities;
using ShopManager.DAL.Repositories;
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
    class RootLoginViewModel : BaseViewModel
    {
        #region Attributes
        private string _isVisible = "Hidden";
        private string _login = string.Empty;
        private string _password = string.Empty;
        private ObservableCollection<string> _listOfProducts;
        private ObservableCollection<Purchase> _listOfPurchases;
        private string _selectedProduct = null;

        private string _isVisibleRootWindow = "Visible";
        private string _isVisibleProducts = "Hidden";
        private string _isVisibleWorkersList = "Hidden";
        private string _isVisiblePurchaseList = "Hidden";
        //workers list
        private ObservableCollection<string> _listOfWorkers = new ObservableCollection<string>();
        private string _selectedWorker = string.Empty;
        private ObservableCollection<string> _listOfInfo = new ObservableCollection<string>();
        #endregion

        #region Getters & setters
        public string isVisible { get { return _isVisible; } set { _isVisible = value; OnPropertyChanged(nameof(isVisible)); } }
        public string login { get { return _login; } set { _login = value; OnPropertyChanged(nameof(login)); } }
        public string password { get { return _password; } set { _password = value; OnPropertyChanged(nameof(password)); } }
        public ObservableCollection<string> listOfProducts { get { return _listOfProducts; } set { _listOfProducts = value; OnPropertyChanged(nameof(listOfProducts)); } }
        public ObservableCollection<Purchase> listOfPurchases { get { return _listOfPurchases; } set { _listOfPurchases = value; OnPropertyChanged(nameof(listOfPurchases)); } }
        public string selectedProduct { get { return _selectedProduct; } set { _selectedProduct = value; OnPropertyChanged(nameof(selectedProduct)); } }
        public string isVisibleRootWindow { get { return _isVisibleRootWindow; } set { _isVisibleRootWindow = value; OnPropertyChanged(nameof(isVisibleRootWindow)); } }
        public string isVisibleProducts { get { return _isVisibleProducts; } set { _isVisibleProducts = value; OnPropertyChanged(nameof(isVisibleProducts)); } }
        public string isVisibleWorkersList { get { return _isVisibleWorkersList; } set { _isVisibleWorkersList = value; OnPropertyChanged(nameof(isVisibleWorkersList)); } }
        public string isVisiblePurchaseList { get { return _isVisiblePurchaseList; } set { _isVisiblePurchaseList = value; OnPropertyChanged(nameof(isVisiblePurchaseList)); } }
        public ObservableCollection<string> listOfWorkers { get { return _listOfWorkers; } set { _listOfWorkers = value; OnPropertyChanged(nameof(listOfWorkers)); } }
        public string selectedWorker { get { return _selectedWorker; } set { _selectedWorker = value; OnPropertyChanged(nameof(selectedWorker)); } }
        public ObservableCollection<string> listOfInfo { get { return _listOfInfo; } set { _listOfInfo = value; OnPropertyChanged(nameof(listOfInfo)); } }
        #endregion

        #region ViewModel instances
        public StartWindowViewModel startWindow { get; set; }
        public RootMainWindow rootMainWindow { get; set; }
        public MainViewModel viewModel { get; set; }

        #endregion
        public RootLoginViewModel()
        {
            listOfWorkers.Add("X");
            listOfWorkers.Add("X");
            listOfWorkers.Add("X");
        }
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
        #endregion
        #region Window methods
        public void LogOut(object sender)
        {
            rootMainWindow.Close();
        }
        public void AddProducts(object sender)
        {
            isVisibleRootWindow = "Hidden";
            isVisibleProducts = "Visible";
        }
        public void WorkersList(object sender)
        {
            isVisibleRootWindow = "Hidden";
            isVisibleWorkersList = "Visible";
            LoadWorkers(true);
        }
        public void PurchaseList(object sender)
        {
            isVisibleRootWindow = "Hidden";
            isVisiblePurchaseList = "Visible";
        }
        #endregion
        #region Workers list window methods
        public void LoadWorkers(object sender)
        {
            //nie wchodzi tu
            listOfWorkers.Clear();
            List<Employee> tmp = RepoEmployees.GetAllEmployees();
            for(int i = 0; i < tmp.Count; i++)
            {
                listOfWorkers.Add($"Employee: {tmp[i].ToString()}");
            }

        }
        public void WorkersBackButton(object sender)
        {
            isVisibleRootWindow = "Visible";
            isVisibleWorkersList = "Hidden";
        }
        public void WorkersListChanged(object sender)
        {
            MessageBox.Show("LIST CHANGED");
        }
        #endregion
    }
}
