using ShopManager.DAL.Entities;
using ShopManager.DAL.Repositories;
using ShopManager.Model;
using ShopManager.View.Windows;
using ShopManager.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
        //purchases list
        private ObservableCollection<string> _listOfTotalPurchases = new ObservableCollection<string>();
        private string _selectedPurchase = string.Empty;
        //single employee data
        private string _firstname = string.Empty;
        private string _secondname = string.Empty;
        private string _salary = string.Empty;
        private string _position = string.Empty;
        //total purchase data
        private string _purchaseDate = string.Empty;
        private string _productName = string.Empty;
        private string _clientName = string.Empty;
        private string _purchaseListPrice = string.Empty;
        //add products window
        private string _ean = string.Empty;
        private string _addProductName = string.Empty;
        private string _addProductPrice = string.Empty;
        private string _addProductionCountry = string.Empty;
        private string _addProductionDate = string.Empty;
        private string _canAddProduct = "True";
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
        public ObservableCollection<string> listOfTotalPurchases { get { return _listOfTotalPurchases; } set { _listOfTotalPurchases = value; OnPropertyChanged(nameof(listOfTotalPurchases)); } }
        public string selectedPurchase { get { return _selectedPurchase; } set { _selectedPurchase = value; OnPropertyChanged(nameof(selectedPurchase)); } }
        public string firstname { get { return _firstname; } set { _firstname = value; OnPropertyChanged(nameof(firstname)); } }
        public string secondname { get { return _secondname; } set { _secondname = value; OnPropertyChanged(nameof(secondname)); } }
        public string salary { get { return _salary; } set { _salary = value; OnPropertyChanged(nameof(salary)); } }
        public string position { get { return _position; } set { _position = value; OnPropertyChanged(nameof(position)); } }
        public string purchaseDate { get { return _purchaseDate; } set { _purchaseDate = value; OnPropertyChanged(nameof(purchaseDate)); } }
        public string productName { get { return _productName; } set { _productName = value; OnPropertyChanged(nameof(productName)); } }
        public string clientName { get { return _clientName; } set { _clientName = value; OnPropertyChanged(nameof(clientName)); } }
        public string purchaseListPrice { get { return _purchaseListPrice; } set { _purchaseListPrice = value; OnPropertyChanged(nameof(purchaseListPrice)); } }
        public string ean { get { return _ean; } set { _ean = value; OnPropertyChanged(nameof(ean)); } }
        public string addProductName { get { return _addProductName; } set { _addProductName = value; OnPropertyChanged(nameof(addProductName)); } }
        public string addProductPrice { get { return _addProductPrice; } set { _addProductPrice = value; OnPropertyChanged(nameof(addProductPrice)); } }
        public string addProductionCountry { get { return _addProductionCountry; } set { _addProductionCountry = value; OnPropertyChanged(nameof(addProductionCountry)); } }
        public string addProductionDate { get { return _addProductionDate; } set { _addProductionDate = value; OnPropertyChanged(nameof(addProductionDate)); } }
        public string canAddProduct { get { return _canAddProduct; } set { _canAddProduct = value; OnPropertyChanged(nameof(canAddProduct)); } }


        #endregion

        #region ViewModel instances
        public StartWindowViewModel startWindow { get; set; }
        public RootMainWindow rootMainWindow { get; set; }
        public MainViewModel viewModel { get; set; }
        public Root rootModel { get; set; } = new Root();

        #endregion
        public RootLoginViewModel()
        {
            
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
            //AddProductsButton(true);
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
            LoadPurchases(true);
        }
        #endregion
        #region Workers list window methods
        public void LoadWorkers(object sender)
        {
            listOfWorkers.Clear();
            List<Employee> tmp = RepoEmployees.GetAllEmployees();
            for(int i = 0; i < tmp.Count; i++)
            {
                listOfWorkers.Add(tmp[i].ToString());
            }

        }
        public void WorkersBackButton(object sender)
        {
            isVisibleRootWindow = "Visible";
            isVisibleWorkersList = "Hidden";
        }
        public void WorkersListChanged(object sender)
        {
            int index = listOfWorkers.IndexOf(selectedWorker);
            Employee employee = new Employee(rootModel.listOfEmployees[index]);
            firstname = employee.Name;
            secondname = employee.Surname;
            salary = employee.Salary.ToString();
            string positionName = employee.PositionName;
            //Position pos = RepoPositions.GetPositionById(positionID);
            position = positionName;
            
        }
        #endregion
        #region TotalPurchaseList window methods
        public void TotalPurchaseBackButton(object sender)
        {
            isVisibleRootWindow = "Visible";
            isVisiblePurchaseList = "Hidden";
        }
        public void LoadPurchases(object sender)
        {
            listOfTotalPurchases.Clear();
            List<Purchase> tmp = RepoPurchases.GetAllPurchases();
            for (int i = 0; i < tmp.Count; i++)
            {
                listOfTotalPurchases.Add(tmp[i].ToString());
            }

        }
        public void TotalPurchaseListChanged(object sender)
        {
            int index = listOfTotalPurchases.IndexOf(selectedPurchase);
            Purchase purchase = new Purchase(rootModel.listOfPurchases[index]);
            purchaseDate = purchase.PurchaseDate;
            productName = purchase.ProductName;
            clientName = purchase.Client_name + " " + purchase.Client_surname;
            purchaseListPrice = purchase.Price.ToString();
        }
        #endregion
        #region AddProducts window methods
        public bool AddProductCheckData()
        {
            var date_format = "yyyy/MM/dd";
            DateTime dt;
            ean = ean.Trim(); addProductName = addProductName.Trim(); addProductPrice = addProductPrice.Trim();
            addProductionCountry = addProductionCountry.Trim(); addProductionDate = addProductionDate.Trim();
            if (ean == string.Empty | addProductName == string.Empty | addProductPrice == string.Empty | addProductionCountry == string.Empty | addProductionDate == string.Empty)
            { MessageBox.Show("Fill data!"); return false; }
            if (ean.Length < 3 || ean.Length > 15)
            { MessageBox.Show("Bad EAN!"); return false; }
            if (addProductName.Length < 2 || addProductName.Length > 15 || addProductName == string.Empty)
            { MessageBox.Show("Bad product name!"); return false; }
            if (addProductPrice == string.Empty || !decimal.TryParse(addProductPrice, out _))
            { MessageBox.Show("Bad product price!"); return false; }
            if (addProductionCountry == string.Empty || addProductionCountry.Length < 2)
            { MessageBox.Show("Bad production country!"); return false; }
            if (addProductionDate == string.Empty || !DateTime.TryParseExact(addProductionDate, date_format, null, DateTimeStyles.None, out dt))
            { MessageBox.Show("Invalid date!"); return false; }
            return true;
        }
        public void AddProductClearData()
        {
            ean = string.Empty;
            addProductName = string.Empty;
            addProductPrice = string.Empty;
            addProductionCountry = string.Empty;
            addProductionDate = string.Empty;
        }
        public void AddProductsBackButton(object sender)
        {
            AddProductClearData();
            canAddProduct = "True";
            isVisibleRootWindow = "Visible";
            isVisibleProducts = "Hidden";
        }
        public void AddProductsButton(object sender)
        {
            MessageBox.Show(ean + " " + addProductName + " " + addProductPrice + " " + addProductionCountry + " " + addProductionDate);
            if (!AddProductCheckData()) return;
            canAddProduct = "False";
            var product = new Product(ean, addProductName, decimal.Parse(addProductPrice), addProductionCountry, addProductionDate);
            if(RepoProducts.AddProduct(product))
            {
                AddProductClearData();
            }

        }
        #endregion
    }
}
