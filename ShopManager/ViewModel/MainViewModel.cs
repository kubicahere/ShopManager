using ShopManager.DAL.Entities;
using ShopManager.Model;
using ShopManager.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShopManager.ViewModel
{
    class MainViewModel : BaseViewModel
    {
        #region Attributes
        private ObservableCollection<string> _listOfProducts;
        private ObservableCollection<Purchase> _listOfPurchases;
        private ObservableCollection<Employee> _listOfEmployers;
        private ObservableCollection<Client> _listOfClients;
        #endregion

        #region Getters & setters
        public ObservableCollection<string> listOfProducts { get; set; }
        public ObservableCollection<Purchase> listOfPurchases { get; set; }
        public ObservableCollection<Employee> listOfEmployers { get; set; }
        public ObservableCollection<Client> listOfClients { get; set; }
        #endregion

        #region ViewModel instances
        public RegisterWindowViewModel registerWindowViewModel { get; set; } = new RegisterWindowViewModel();
        public RootLoginViewModel rootLoginViewModel { get; set; } = new RootLoginViewModel();
        public StartWindowViewModel startWindowViewModel { get; set; } = new StartWindowViewModel();
        public UserLoginViewModel userLoginViewModel { get; set; } = new UserLoginViewModel();
        #endregion
        public MainViewModel()
        {
            Root rootModel = new Root();
            User userModel = new User();
            startWindowViewModel.RegisterWindow = registerWindowViewModel;
            startWindowViewModel.UserLogin = userLoginViewModel;
            startWindowViewModel.RootLogin = rootLoginViewModel;
            registerWindowViewModel.startWindow = startWindowViewModel;
            registerWindowViewModel.mainModel = userModel;
            rootLoginViewModel.startWindow = startWindowViewModel;
            rootLoginViewModel.viewModel = this;
            userLoginViewModel.startWindow = startWindowViewModel;
            userLoginViewModel.viewModel = this;
            
        }
        #region ICommand StartControl
        private ICommand _registerUserClick = null;
        public ICommand RegisterUserClick
        {
            get
            {
                if (_registerUserClick == null)
                {
                    _registerUserClick = new RelayCommand(startWindowViewModel.Register, arg => true);
                }
                return _registerUserClick;
            }
        }
        private ICommand _loginUserClick = null;
        public ICommand LoginUserClick
        {
            get
            {
                if(_loginUserClick == null)
                {
                    _loginUserClick = new RelayCommand(startWindowViewModel.LoginUser, arg => true);
                }
                return _loginUserClick;
            }
        }
        private ICommand _loginRootClick = null;
        public ICommand LoginRootClick
        {
            get
            {
                if(_loginRootClick == null)
                {
                    _loginRootClick = new RelayCommand(startWindowViewModel.LoginRoot, arg => true);
                }
                return _loginRootClick;
            }
        }
        #endregion
        #region ICommand LoginControl
        private ICommand _loginUser = null;
        public ICommand LoginUser   //TODO
        {
            get
            {
                if(_loginUser == null)
                {
                    _loginUser = new RelayCommand(userLoginViewModel.LoginUser, arg => true);
                }
                return _loginUser;
            }
        }
        private ICommand _userBackButton = null;
        public ICommand UserBackButton
        {
            get
            {
                if(_userBackButton == null)
                {
                    _userBackButton = new RelayCommand(userLoginViewModel.BackButton, arg => true);
                }
                return _userBackButton;
            }
        }
        #endregion
        #region ICommand RootLoginControl
        private ICommand _loginRoot = null;
        public ICommand LoginRoot  //TODO
        {
            get
            {
                if (_loginRoot == null)
                {
                    _loginRoot = new RelayCommand(rootLoginViewModel.LoginRoot, arg => true);
                }
                return _loginRoot;
            }
        }
        private ICommand _rootBackButton = null;
        public ICommand RootBackButton
        {
            get
            {
                if (_rootBackButton == null)
                {
                    _rootBackButton = new RelayCommand(rootLoginViewModel.BackButton, arg => true);
                }
                return _rootBackButton;
            }
        }
        #endregion
        #region ICommand RegisterControl
        private ICommand _registerUser = null;
        public ICommand RegisterUser
        {
            get
            {
                if (_registerUser == null)
                {
                    _registerUser = new RelayCommand(registerWindowViewModel.RegisterUser, arg => true);
                }
                return _registerUser;
            }
        }

        private ICommand _registerBackButton = null;
        public ICommand RegisterBackButton
        {
            get
            {
                if (_registerBackButton == null)
                {
                    _registerBackButton = new RelayCommand(registerWindowViewModel.BackButton, arg => true);
                }
                return _registerBackButton;
            }
        }
        #endregion
        #region ICommand UserStartup
        private ICommand _logOutClick = null;
        public ICommand logOutClick
        {
            get
            {
                if(_logOutClick == null)
                {
                    _logOutClick = new RelayCommand(userLoginViewModel.LogOut, arg => true);
                }
                return _logOutClick;
            }
        }
        private ICommand _shoppingClick = null;
        public ICommand shoppingClick
        {
            get
            {
                if(_shoppingClick == null)
                {
                    _shoppingClick = new RelayCommand(userLoginViewModel.GoShopping, arg => true);
                }
                return _shoppingClick;
            }
        }
        private ICommand _purchaseHistoryClick = null;
        public ICommand purchaseHistoryClick
        {
            get
            {
                if(_purchaseHistoryClick == null)
                {
                    _purchaseHistoryClick = new RelayCommand(userLoginViewModel.PurchaseHistory, arg => true);
                }
                return _purchaseHistoryClick;
            }
        }
        private ICommand _accountSettingClick = null;
        public ICommand accountSettingsClick
        {
            get
            {
                if(_accountSettingClick == null)
                {
                    _accountSettingClick = new RelayCommand(userLoginViewModel.AccountSettings, arg => true);
                }
                return _accountSettingClick;
            }
        }

        #endregion
        #region ICommand RootStartup
        private ICommand _logOutRoot = null;
        public ICommand logOutRoot
        {
            get
            {
                if (_logOutRoot == null)
                {
                    _logOutRoot = new RelayCommand(rootLoginViewModel.LogOut, arg => true);
                }
                return _logOutRoot;
            }
        }
        private ICommand _addProduct = null;
        public ICommand addProduct
        {
            get
            {
                if (_addProduct == null)
                {
                    _addProduct = new RelayCommand(rootLoginViewModel.AddProducts, arg => true);
                }
                return _addProduct;
            }
        }
        private ICommand _showWorkers = null;
        public ICommand showWorkers
        {
            get
            {
                if (_showWorkers == null)
                {
                    _showWorkers = new RelayCommand(rootLoginViewModel.WorkersList, arg => true);
                }
                return _showWorkers;
            }
        }
        private ICommand _showPurchases = null;
        public ICommand showPurchases
        {
            get
            {
                if (_showPurchases == null)
                {
                    _showPurchases = new RelayCommand(rootLoginViewModel.PurchaseList, arg => true);
                }
                return _showPurchases;
            }
        }

        #endregion
        #region ICommand ClientPurchaseHistory
        private ICommand _purchaseBackButton = null;
        public ICommand purchaseBackButton
        {
            get
            {
                if (_purchaseBackButton == null)
                {
                    _purchaseBackButton = new RelayCommand(userLoginViewModel.PurchaseBackButton, arg => true);
                }
                return _purchaseBackButton;
            }
        }
        private ICommand _clientPurchaseList = null;
        public ICommand clientPurchaseList
        {
            get
            {
                if (_clientPurchaseList == null)
                {
                    _clientPurchaseList = new RelayCommand(userLoginViewModel.LoadCustomerPurchases, arg => true);
                }
                return _clientPurchaseList;
            }
        }
        private ICommand _purchaseSelectedItem = null;
        public ICommand purchaseSelectedItem
        {
            get
            {
                if (_purchaseSelectedItem == null)
                {
                    _purchaseSelectedItem = new RelayCommand(userLoginViewModel.PurchaseListChanged, arg => true);
                }
                return _purchaseSelectedItem;
            }
        }
        #endregion
        #region ICommand WorkersList
        private ICommand _workersBackButton = null;
        public ICommand workersBackButton
        {
            get
            {
                if (_workersBackButton == null)
                {
                    _workersBackButton = new RelayCommand(rootLoginViewModel.WorkersBackButton, arg => true);
                }
                return _workersBackButton;
            }
        }
        private ICommand _workersList = null;
        public ICommand workersList
        {
            get
            {
                if(_workersList == null)
                {
                    _workersList = new RelayCommand(rootLoginViewModel.LoadWorkers, arg => true);
                }
                return _workersList;
            }
        }
        private ICommand _workersSelectedItem = null;
        public ICommand workersSelectedItem
        {
            get
            {
                if (_workersSelectedItem == null)
                {
                    _workersSelectedItem = new RelayCommand(rootLoginViewModel.WorkersListChanged, arg => true);
                }
                return _workersSelectedItem;
            }
        }
        #endregion
        #region ICommand TotalPurchaseList
        private ICommand _totalPurchaseBackButton = null;
        public ICommand totalPurchaseBackButton
        {
            get
            {
                if (_totalPurchaseBackButton == null)
                {
                    _totalPurchaseBackButton = new RelayCommand(rootLoginViewModel.TotalPurchaseBackButton, arg => true);
                }
                return _totalPurchaseBackButton;
            }
        }
        private ICommand _totalPurchaseList = null;
        public ICommand totalPurchaseList
        {
            get
            {
                if (_totalPurchaseList == null)
                {
                    _totalPurchaseList = new RelayCommand(rootLoginViewModel.LoadPurchases, arg => true);
                }
                return _totalPurchaseList;
            }
        }
        private ICommand _totalPurchasesSelectedItem = null;
        public ICommand totalPurchasesSelectedItem
        {
            get
            {
                if (_totalPurchasesSelectedItem == null)
                {
                    _totalPurchasesSelectedItem = new RelayCommand(rootLoginViewModel.TotalPurchaseListChanged, arg => true);
                }
                return _totalPurchasesSelectedItem;
            }
        }
        #endregion
        #region ICommand UserAccount
        private ICommand _editUser = null;
        public ICommand EditUser
        {
            get
            {
                if (_editUser == null)
                {
                    _editUser = new RelayCommand(userLoginViewModel.EditUser, arg => true);
                }
                return _editUser;
            }
        }

        private ICommand _editBackButton = null;
        public ICommand EditBackButton
        {
            get
            {
                if (_editBackButton == null)
                {
                    _editBackButton = new RelayCommand(userLoginViewModel.BackButton, arg => true);
                }
                return _editBackButton;
            }
        }
        #endregion
    }
}
