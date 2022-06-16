using ShopManager.ViewModel.Base;
using ShopManager.Model
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManager.ViewModel
{
    class RegisterWindowViewModel : BaseViewModel
    {
        public StartWindowViewModel startWindow { get; set; }
        public MainViewModel mainVM { get; set; }
        public MainModel mainModel { get; set; }
        public RegisterWindowViewModel()
        {
            mainModel = new MainModel();
            //TODO LOAD LIST OF USERS FROM DB
        }
        #region Attributes
        private string _isVisible = "Hidden";
        private string _login = string.Empty;
        private string _password = string.Empty;
        private string _repeatPassword = string.Empty;
        private string _phoneNumber = string.Empty;
        private string _emailAddress = string.Empty;
        private string _canRegister = "True";
        #endregion
        #region Getters & setters
        public string isVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
                OnPropertyChanged(nameof(isVisible));
            }
        }
        public string login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged(nameof(login));
            }
        }
        public string password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(password));
            }
        }
        public string repeatPassword
        {
            get { return _repeatPassword; }
            set
            {
                _repeatPassword = value;
                OnPropertyChanged(nameof(repeatPassword));
            }
        }
        public string phoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(phoneNumber));
            }
        }
        public string emailAddress
        {
            get { return _emailAddress; }
            set
            {
                _emailAddress = value;
                OnPropertyChanged(nameof(emailAddress));
            }
        }
        public string canRegister
        {
            get { return _canRegister; }
            set
            {
                _canRegister = value;
                OnPropertyChanged(nameof(canRegister));
            }
        }
        #endregion
        #region Methods
        public void ClearData()
        {
            login = string.Empty;
            password = string.Empty;
            repeatPassword = string.Empty;
            phoneNumber = string.Empty; 
            emailAddress = string.Empty;    
        }
        public void SetStartWindow(object sender)
        {
            ClearData();
            canRegister = "True";
            startWindow.isVisible = "Visible";
            isVisible = "Hidden";
        }
        public bool CheckData()
        {
            //TODO CHECKING VALIDITY OF INPUT
        }
        public void RegisterUser(object sender)
        {
            if (!CheckData()) return;
            canRegister = "False";
            var user = new Client();    //TODO REFACTOR CLIENT CTOR
        }

        #endregion
    }
}
