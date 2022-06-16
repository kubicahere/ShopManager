using ShopManager.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManager.ViewModel
{
    class StartWindowViewModel : BaseViewModel
    {
        private string _isVisible = "Visible";
        public string isVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
                OnPropertyChanged(nameof(isVisible));
            }
        }
        #region ViewModel instances
        public RegisterWindowViewModel RegisterWindow { get; set; }
        public UserLoginViewModel UserLogin { get; set; }
        public RootLoginViewModel RootLogin { get; set; }
        #endregion
        #region Methods
        public void LoginUser(object sender)
        {
            isVisible = "Hidden";
            UserLogin.isVisible = "Visible";
        }
        public void LoginRoot(object sender)
        {
            isVisible = "Hidden";
            RootLogin.isVisible = "Visible";
        }
        public void Register(object sender)
        {
            isVisible = "Hidden";
            RegisterWindow.isVisible = "Visible";
        }
        #endregion
    }
}
