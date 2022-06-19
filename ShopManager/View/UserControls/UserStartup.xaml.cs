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

namespace ShopManager.View.UserControls
{
    /// <summary>
    /// Interaction logic for UserStartup.xaml
    /// </summary>
    public partial class UserStartup : UserControl
    {
        public UserStartup()
        {
            InitializeComponent();
        }
        #region Dependencies
        public static readonly DependencyProperty ShoppingProperty = DependencyProperty.Register(
            "Shopping", typeof(ICommand), typeof(UserStartup), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty PurchaseListProperty = DependencyProperty.Register(
            "PurchaseList", typeof(ICommand), typeof(UserStartup), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty AccountSettingsProperty = DependencyProperty.Register(
            "AccountSettings", typeof(ICommand), typeof(UserStartup), new FrameworkPropertyMetadata(null)
            );
        #endregion

    }
}
