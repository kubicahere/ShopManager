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
    /// Interaction logic for RootStartup.xaml
    /// </summary>
    public partial class RootStartup : UserControl
    {
        public RootStartup()
        {
            InitializeComponent();
        }

        #region Dependencies
        public static readonly DependencyProperty LogOutRootProperty = DependencyProperty.Register(
           "LogOutRoot", typeof(ICommand), typeof(RootStartup), new FrameworkPropertyMetadata(null)
           );
        public static readonly DependencyProperty ProductsProperty = DependencyProperty.Register(
            "AddProducts", typeof(ICommand), typeof(RootStartup), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty WorkersListProperty = DependencyProperty.Register(
            "ShowWorkersList", typeof(ICommand), typeof(RootStartup), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty PurchaseListProperty = DependencyProperty.Register(
            "ShowPurchaseList", typeof(ICommand), typeof(RootStartup), new FrameworkPropertyMetadata(null)
            );
        #endregion
        #region Getters & setters
        public ICommand LogOutRoot
        {
            get { return (ICommand)GetValue(LogOutRootProperty); }
            set { SetValue(LogOutRootProperty, value); }
        }
        public ICommand AddProducts
        {
            get { return (ICommand)GetValue(ProductsProperty); }
            set { SetValue(ProductsProperty, value); }
        }
        public ICommand ShowWorkersList
        {
            get { return (ICommand)GetValue(WorkersListProperty); }
            set { SetValue(WorkersListProperty, value); }
        }
        public ICommand ShowPurchaseList
        {
            get { return (ICommand)GetValue(PurchaseListProperty); }
            set { SetValue(PurchaseListProperty, value); }
        }
        #endregion
        #region Events
        public static readonly RoutedEvent LogOutRootClickEvent =
            EventManager.RegisterRoutedEvent("LogOutRootClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(RootStartup));
        public event RoutedEventHandler LogOutClick
        {
            add { AddHandler(LogOutRootClickEvent, value); }
            remove { RemoveHandler(LogOutRootClickEvent, value); }
        }
        void RaiseLogOutRootClick(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(LogOutRootClickEvent);
            RaiseEvent(args);
        }
        public static readonly RoutedEvent AddProductsClickEvent =
            EventManager.RegisterRoutedEvent("AddProductsClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(RootStartup));
        public event RoutedEventHandler AddProductsClick
        {
            add { AddHandler(AddProductsClickEvent, value); }
            remove { RemoveHandler(AddProductsClickEvent, value); }
        }
        void RaiseAddProductsClick(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(AddProductsClickEvent);
            RaiseEvent(args);
        }
        public static readonly RoutedEvent ShowWorkersListClickEvent =
            EventManager.RegisterRoutedEvent("ShowWorkersListClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(RootStartup));
        public event RoutedEventHandler ShowWorkersListClick
        {
            add { AddHandler(ShowWorkersListClickEvent, value); }
            remove { RemoveHandler(ShowWorkersListClickEvent, value); }
        }
        void RaiseShowWorkersListClick(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(ShowWorkersListClickEvent);
            RaiseEvent(args);
        }
        public static readonly RoutedEvent ShowPurchaseListClickEvent =
            EventManager.RegisterRoutedEvent("ShowPurchaseListClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(RootStartup));
        public event RoutedEventHandler ShowPurchaseListClick
        {
            add { AddHandler(ShowPurchaseListClickEvent, value); }
            remove { RemoveHandler(ShowPurchaseListClickEvent, value); }
        }
        void RaiseShowPurchaseListClick(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(ShowPurchaseListClickEvent);
            RaiseEvent(args);
        }
        #endregion
    }
}
