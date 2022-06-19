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
        public static readonly DependencyProperty LogOutProperty = DependencyProperty.Register(
           "LogOut", typeof(ICommand), typeof(UserStartup), new FrameworkPropertyMetadata(null)
           );
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
        #region Getters & setters
        public ICommand LogOut
        {
            get { return (ICommand)GetValue(LogOutProperty); }
            set { SetValue(LogOutProperty, value); }
        }
        public ICommand Shopping
        {
            get { return (ICommand)GetValue(ShoppingProperty); }
            set { SetValue(ShoppingProperty, value); }
        }
        public ICommand PurchaseList
        {
            get { return (ICommand)GetValue(PurchaseListProperty); }
            set { SetValue(PurchaseListProperty, value); }
        }
        public ICommand AccountSettings
        {
            get { return (ICommand)GetValue(AccountSettingsProperty); }
            set { SetValue(AccountSettingsProperty, value); }
        }
        #endregion
        #region Events
        public static readonly RoutedEvent LogOutClickEvent =
            EventManager.RegisterRoutedEvent("OtherLogOutClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(UserStartup));
        public event RoutedEventHandler LogOutClick
        {
            add { AddHandler(LogOutClickEvent, value); }
            remove { RemoveHandler(LogOutClickEvent, value); }
        }
        void RaiseLogOutClick(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(LogOutClickEvent);
            RaiseEvent(args);
        }
        public static readonly RoutedEvent ShoppingClickEvent =
            EventManager.RegisterRoutedEvent("OtherShoppingClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(UserStartup));
        public event RoutedEventHandler ShoppingClick
        {
            add { AddHandler(ShoppingClickEvent, value); }
            remove { RemoveHandler(ShoppingClickEvent, value); }
        }
        void RaiseShoppingClick(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(ShoppingClickEvent);
            RaiseEvent(args);
        }
        public static readonly RoutedEvent PurchaseListClickEvent =
            EventManager.RegisterRoutedEvent("OtherPurchaseListClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(UserStartup));
        public event RoutedEventHandler PurchaseListClick
        {
            add { AddHandler(PurchaseListClickEvent, value); }
            remove { RemoveHandler(PurchaseListClickEvent, value); }
        }
        void RaisePurchaseListClick(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(PurchaseListClickEvent);
            RaiseEvent(args);
        }
        public static readonly RoutedEvent AccountSettingsClickEvent =
            EventManager.RegisterRoutedEvent("OtherAccountSettingsClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(UserStartup));
        public event RoutedEventHandler AccountSettingsClick
        {
            add { AddHandler(AccountSettingsClickEvent, value); }
            remove { RemoveHandler(AccountSettingsClickEvent, value); }
        }
        void RaiseRootLoginClick(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(AccountSettingsClickEvent);
            RaiseEvent(args);
        }
        #endregion
    }
}
