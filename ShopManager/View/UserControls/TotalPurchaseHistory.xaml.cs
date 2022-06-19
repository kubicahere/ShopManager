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
    /// Logika interakcji dla klasy PurchaseList.xaml
    /// </summary>
    public partial class TotalPurchaseHistory : UserControl
    {
        public TotalPurchaseHistory()
        {
            InitializeComponent();
        }
        #region Dependency
        public static readonly DependencyProperty BackButtonProperty = DependencyProperty.Register(
           "PurchaseBackButton", typeof(ICommand), typeof(TotalPurchaseHistory), new FrameworkPropertyMetadata(null)
           );
        public static readonly DependencyProperty TotalPurchaseListProperty = DependencyProperty.Register(
           "TotalPurchaseList", typeof(ObservableCollection<string>), typeof(TotalPurchaseHistory), new FrameworkPropertyMetadata(null)
           );
        public static readonly DependencyProperty SingleSelectedPurchaseProperty = DependencyProperty.Register(
           "SingleSelectedPurchase", typeof(string), typeof(TotalPurchaseHistory), new FrameworkPropertyMetadata(null)
           );
        #endregion
        #region Getters & setters
        public ICommand PurchaseBackButton
        {
            get { return (ICommand)GetValue(BackButtonProperty); }
            set { SetValue(BackButtonProperty, value); }
        }
        public ObservableCollection<string> TotalPurchaseList
        {
            get { return (ObservableCollection<string>)GetValue(TotalPurchaseListProperty); }
            set { SetValue(TotalPurchaseListProperty, value); }
        }
        public string SingleSelectedPurchase
        {
            get { return (string)GetValue(SingleSelectedPurchaseProperty); }
            set { SetValue(SingleSelectedPurchaseProperty, value); }
        }
        #endregion
        #region Events
        public static readonly RoutedEvent BackButtonClickEvent =
            EventManager.RegisterRoutedEvent("OtherPurchaseBackButtonClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TotalPurchaseHistory));
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
            EventManager.RegisterRoutedEvent("TotalPurchaseListItemChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TotalPurchaseHistory));
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
