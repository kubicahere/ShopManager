using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShopManager.View
{
    /// <summary>
    /// Interaction logic for LoginControl.xaml
    /// </summary>
    public partial class LoginControl : UserControl
    {
        public LoginControl()
        {
            InitializeComponent();
        }
        #region Dependencies
        public static readonly DependencyProperty GoBackProperty = DependencyProperty.Register(
            "GoBack", typeof(ICommand), typeof(LoginControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty LogProperty = DependencyProperty.Register(
            "Log", typeof(ICommand), typeof(LoginControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty LoginProperty = DependencyProperty.Register(
            "Login", typeof(string), typeof(LoginControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register(
            "Password", typeof(string), typeof(LoginControl), new FrameworkPropertyMetadata(null)
            );
        #endregion
    }
}
