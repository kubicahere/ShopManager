using ShopManager.ViewModel.Base;
using ShopManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopManager.DAL.Entities;
using System.Windows;
using System.Text.RegularExpressions;

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
        private string _firstName = string.Empty;
        private string _surname = string.Empty;
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
        public string firstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(firstName));
            }
        }
        public string surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(surname));
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
            firstName = string.Empty;
            surname = string.Empty;
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
            string mailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                             + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                             + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            login = login.Trim(); phoneNumber = phoneNumber.Trim(); emailAddress = emailAddress.Trim(); emailAddress = emailAddress.ToLower();
            if (login == string.Empty | password == string.Empty | repeatPassword == string.Empty | phoneNumber == string.Empty | emailAddress == string.Empty)
            { MessageBox.Show("Fill data!"); return false; }
            if (login.Length < 3 || login.Length > 15)
            { MessageBox.Show("Bad Login!"); return false; }
            if (password.Length < 3 || password.Length > 15|| password == string.Empty)
            { MessageBox.Show("Bad password!"); return false; }
            if ((!string.Equals(password, repeatPassword)) || (password == string.Empty & repeatPassword == string.Empty))
            { MessageBox.Show("Different passwords!"); return false; }
            if(firstName == string.Empty || firstName.Length < 3 || firstName.Length > 15)
            { MessageBox.Show("Bad firstname!"); return false; }
            if(surname == string.Empty || surname.Length < 3 || surname.Length > 15)
            { MessageBox.Show("Bad surname!"); return false; }
            if (!(Regex.Match(phoneNumber, @"(?<!\w)(\(?(\+|00)?48\)?)?[ -]?\d{3}[ -]?\d{3}[ -]?\d{3}(?!\w)").Success))
            { MessageBox.Show("Bad phone number!"); return false; }
            if (!(Regex.Match(emailAddress, mailPattern).Success))
            { MessageBox.Show("Bad e-mail address!"); return false; }
            return true;
        }
        public void RegisterUser(object sender)
        {
            if (!CheckData()) return;
            canRegister = "False";
            var user = new Client(login, password, firstName, surname, emailAddress, phoneNumber);
            //TODO ADD CLIENT TO DB
        }

        #endregion
    }
}
