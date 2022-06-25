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
    /// Logika interakcji dla klasy AddProducts.xaml
    /// </summary>
    public partial class AddProducts : UserControl
    {
        public AddProducts()
        {
            InitializeComponent();
        }
        #region Dependencies
        public static readonly DependencyProperty ProductBackButtonProperty = DependencyProperty.Register(
            "ProductBackButton", typeof(ICommand), typeof(AddProducts), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty AddProductProperty = DependencyProperty.Register(
            "AddProduct", typeof(ICommand), typeof(AddProducts), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty EANProperty = DependencyProperty.Register(
            "EAN", typeof(string), typeof(AddProducts), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty ProductNameProperty = DependencyProperty.Register(
            "ProductName", typeof(string), typeof(AddProducts), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty ProductPriceProperty = DependencyProperty.Register(
            "ProductPrice", typeof(string), typeof(AddProducts), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty ProductionCountryProperty = DependencyProperty.Register(
            "ProductionCountry", typeof(string), typeof(AddProducts), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty ProductionDateProperty = DependencyProperty.Register(
            "ProductionDate", typeof(string), typeof(AddProducts), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty CanAddProperty = DependencyProperty.Register(
            "CanAdd", typeof(string), typeof(AddProducts), new FrameworkPropertyMetadata(null)
            );
        #endregion
        #region Getters & setters
        public ICommand ProductBackButton
        {
            get { return (ICommand)GetValue(ProductBackButtonProperty); }
            set { SetValue(ProductBackButtonProperty, value); }
        }
        public ICommand AddProduct
        {
            get { return (ICommand)GetValue(AddProductProperty); }
            set { SetValue(AddProductProperty, value); }
        }
        public string EAN
        {
            get { return (string)GetValue(EANProperty); }
            set { SetValue(EANProperty, value); }
        }
        public string ProductName
        {
            get { return (string)GetValue(ProductNameProperty); }
            set { SetValue(ProductNameProperty, value); }
        }
        public string ProductPrice
        {
            get { return (string)GetValue(ProductPriceProperty); }
            set { SetValue(ProductPriceProperty, value); }
        }
        public string ProductionCountry
        {
            get { return (string)GetValue(ProductionCountryProperty); }
            set { SetValue(ProductionCountryProperty, value); }
        }
        public string ProductionDate
        {
            get { return (string)GetValue(ProductionDateProperty); }
            set { SetValue(ProductionDateProperty, value); }
        }
        public string CanAdd
        {
            get { return (string)GetValue(CanAddProperty); }
            set { SetValue(CanAddProperty, value); }
        }
        #endregion
        #region Events
        public static readonly RoutedEvent ProductBackButtonClickEvent =
            EventManager.RegisterRoutedEvent("OtherProductBackButtonClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(AddProducts));
        public event RoutedEventHandler BackButtonClick
        {
            add { AddHandler(ProductBackButtonClickEvent, value); }
            remove { RemoveHandler(ProductBackButtonClickEvent, value); }
        }
        void RaiseGoBackClick(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(ProductBackButtonClickEvent);
            RaiseEvent(args);
        }
        public static readonly RoutedEvent AddProductClickEvent =
            EventManager.RegisterRoutedEvent("OtherAddProductClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(AddProducts));
        public event RoutedEventHandler RegisterClick
        {
            add { AddHandler(AddProductClickEvent, value); }
            remove { RemoveHandler(AddProductClickEvent, value); }
        }
        void RaiseAddProductClick(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(AddProductClickEvent);
            RaiseEvent(args);
        }
        #endregion
    }
}
