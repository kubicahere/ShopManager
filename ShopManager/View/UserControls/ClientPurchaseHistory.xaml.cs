using ShopManager.DAL.Entities;
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
    /// Logika interakcji dla klasy PurchaseHistory.xaml
    /// </summary>
    public partial class ClientPurchaseHistory : UserControl
    {
        public ClientPurchaseHistory()
        {
            InitializeComponent();
        }
        #region Dependency
        public static readonly DependencyProperty BackButtonProperty = DependencyProperty.Register(
           "BackButton", typeof(ICommand), typeof(ClientPurchaseHistory), new FrameworkPropertyMetadata(null)
           );
        public static readonly DependencyProperty PurchaseListProperty = DependencyProperty.Register(
           "PurchaseList", typeof(ObservableCollection<string>), typeof(ClientPurchaseHistory), new FrameworkPropertyMetadata(null)
           );
        public static readonly DependencyProperty SingleSelectedItemProperty = DependencyProperty.Register(
           "SingleSelectedItem", typeof(string), typeof(ClientPurchaseHistory), new FrameworkPropertyMetadata(null)
           );
        #endregion
        #region Getters & setters
        public ICommand BackButton
        {
            get { return (ICommand)GetValue(BackButtonProperty); }
            set { SetValue(BackButtonProperty, value); }
        }
        public ObservableCollection<string> PurchaseList
        {
            get { return (ObservableCollection<string>)GetValue(PurchaseListProperty); }
            set { SetValue(PurchaseListProperty, value); }
        }
        public string SingleSelectedItem
        {
            get { return (string)GetValue(SingleSelectedItemProperty); }
            set { SetValue(SingleSelectedItemProperty, value); }
        }

        #endregion
        #region Events
        public static readonly RoutedEvent BackButtonClickEvent =
            EventManager.RegisterRoutedEvent("OtherBackButtonClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ClientPurchaseHistory));
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
        public static readonly RoutedEvent PurchaseListItemChangedEvent =
            EventManager.RegisterRoutedEvent("PurchaseListItemChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ClientPurchaseHistory));
        public event RoutedEventHandler PurchaseListItemChanged
        {
            add { AddHandler(PurchaseListItemChangedEvent, value); }
            remove { RemoveHandler(PurchaseListItemChangedEvent, value); }
        }
        void RaisePurchaseListItemChanged(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(PurchaseListItemChangedEvent);
            RaiseEvent(args);
        }
        #endregion
    }
}
