using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logika interakcji dla klasy UserShopping.xaml
    /// </summary>
    public partial class UserShopping : UserControl
    {
        public UserShopping()
        {
            InitializeComponent();
        }
        #region Dependencies
        public static readonly DependencyProperty ShoppingBackButtonProperty = DependencyProperty.Register(
           "ShoppingBackButton", typeof(ICommand), typeof(UserShopping), new FrameworkPropertyMetadata(null)
           );
        public static readonly DependencyProperty ProductsListProperty = DependencyProperty.Register(
           "ProductsList", typeof(ObservableCollection<string>), typeof(UserShopping), new FrameworkPropertyMetadata(null)
           );
        public static readonly DependencyProperty SingleSelectedProductProperty = DependencyProperty.Register(
           "SingleSelectedProduct", typeof(string), typeof(UserShopping), new FrameworkPropertyMetadata(null)
           );
        public static readonly DependencyProperty BuyButtonProperty = DependencyProperty.Register(
           "BuyButton", typeof(ICommand), typeof(UserShopping), new FrameworkPropertyMetadata(null)
           );
        #endregion
        #region Getters & setters
        public ICommand ShoppingBackButton
        {
            get { return (ICommand)GetValue(ShoppingBackButtonProperty); }
            set { SetValue(ShoppingBackButtonProperty, value); }
        }
        public ObservableCollection<string> ProductsList
        {
            get { return (ObservableCollection<string>)GetValue(ProductsListProperty); }
            set { SetValue(ProductsListProperty, value); }
        }
        public string SingleSelectedProduct
        {
            get { return (string)GetValue(SingleSelectedProductProperty); }
            set { SetValue(SingleSelectedProductProperty, value); }
        }
        public ICommand BuyButton
        {
            get { return (ICommand)GetValue(BuyButtonProperty); }
            set { SetValue(BuyButtonProperty, value); }
        }
        #endregion
        #region Events
        public static readonly RoutedEvent BackButtonClickEvent =
            EventManager.RegisterRoutedEvent("OtherBackButtonClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(UserShopping));
        public event RoutedEventHandler BackButtonClick
        {
            add { AddHandler(BackButtonClickEvent, value); }
            remove { RemoveHandler(BackButtonClickEvent, value); }
        }
        void RaiseBackButtonClick(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(BackButtonClickEvent);
            RaiseEvent(args);
        }
        public static readonly RoutedEvent ProductsListItemChangedEvent =
            EventManager.RegisterRoutedEvent("ProductsListItemChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(UserShopping));
        public event RoutedEventHandler ProductsListItemChanged
        {
            add { AddHandler(ProductsListItemChangedEvent, value); }
            remove { RemoveHandler(ProductsListItemChangedEvent, value); }
        }
        void RaiseProductsListItemChanged(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(ProductsListItemChangedEvent);
            RaiseEvent(args);
        }
        public static readonly RoutedEvent BuyButtonClickEvent =
            EventManager.RegisterRoutedEvent("OtherBuyButtonClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(UserShopping));
        public event RoutedEventHandler BuyButtonClick
        {
            add { AddHandler(BuyButtonClickEvent, value); }
            remove { RemoveHandler(BuyButtonClickEvent, value); }
        }
        void RaiseBuyButtonClick(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(BuyButtonClickEvent);
            RaiseEvent(args);
        }
        #endregion
    }
}
