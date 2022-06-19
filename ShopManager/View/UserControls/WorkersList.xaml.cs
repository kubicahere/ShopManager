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
    /// Logika interakcji dla klasy WorkersList.xaml
    /// </summary>
    public partial class WorkersList : UserControl
    {
        public WorkersList()
        {
            InitializeComponent();
        }
        #region Dependency
        public static readonly DependencyProperty BackButtonProperty = DependencyProperty.Register(
           "BackButton", typeof(ICommand), typeof(WorkersList), new FrameworkPropertyMetadata(null)
           );
        public static readonly DependencyProperty WorkersListProperty = DependencyProperty.Register(
           "WorkerList", typeof(ObservableCollection<Employee>), typeof(WorkersList), new FrameworkPropertyMetadata(null)
           );
        public static readonly DependencyProperty SingleSelectedItemProperty = DependencyProperty.Register(
           "SingleSelectedItem", typeof(string), typeof(WorkersList), new FrameworkPropertyMetadata(null)
           );
        #endregion
        #region Getters & setters
        public ICommand BackButton
        {
            get { return (ICommand)GetValue(BackButtonProperty); }
            set { SetValue(BackButtonProperty, value); }
        }
        public ObservableCollection<Employee> WorkerList
        {
            get { return (ObservableCollection<Employee>)GetValue(WorkersListProperty); }
            set { SetValue(WorkersListProperty, value); }
        }
        public string SingleSelectedItem
        {
            get { return (string)GetValue(SingleSelectedItemProperty); }
            set { SetValue(SingleSelectedItemProperty, value); }
        }

        #endregion
        #region Events
        public static readonly RoutedEvent BackButtonClickEvent =
            EventManager.RegisterRoutedEvent("OtherBackButtonClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(WorkersList));
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
        public static readonly RoutedEvent WorkersListItemChangedEvent =
            EventManager.RegisterRoutedEvent("PurchaseListItemChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(WorkersList));
        public event RoutedEventHandler PurchaseListItemChanged
        {
            add { AddHandler(WorkersListItemChangedEvent, value); }
            remove { RemoveHandler(WorkersListItemChangedEvent, value); }
        }
        void RaisePurchaseListItemChanged(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(WorkersListItemChangedEvent);
            RaiseEvent(args);
        }
        #endregion
    }
}
