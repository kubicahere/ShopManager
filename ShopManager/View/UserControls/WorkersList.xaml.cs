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
           "WorkerList", typeof(ObservableCollection<string>), typeof(WorkersList), new FrameworkPropertyMetadata(null)
           );
        public static readonly DependencyProperty SingleSelectedItemProperty = DependencyProperty.Register(
           "SingleSelectedItem", typeof(string), typeof(WorkersList), new FrameworkPropertyMetadata(null)
           );
        public static readonly DependencyProperty FirstNameFillProperty = DependencyProperty.Register(
           "FirstNameFill", typeof(string), typeof(WorkersList), new FrameworkPropertyMetadata(null)
           );
        public static readonly DependencyProperty SecondNameFillProperty = DependencyProperty.Register(
          "SecondNameFill", typeof(string), typeof(WorkersList), new FrameworkPropertyMetadata(null)
          );
        public static readonly DependencyProperty SalaryFillProperty = DependencyProperty.Register(
          "SalaryFill", typeof(string), typeof(WorkersList), new FrameworkPropertyMetadata(null)
          );
        public static readonly DependencyProperty PositionFillProperty = DependencyProperty.Register(
          "PositionFill", typeof(string), typeof(WorkersList), new FrameworkPropertyMetadata(null)
          );
        #endregion
        #region Getters & setters
        public ICommand BackButton
        {
            get { return (ICommand)GetValue(BackButtonProperty); }
            set { SetValue(BackButtonProperty, value); }
        }
        public ObservableCollection<string> WorkerList
        {
            get { return (ObservableCollection<string>)GetValue(WorkersListProperty); }
            set { SetValue(WorkersListProperty, value); }
        }
        public string SingleSelectedItem
        {
            get { return (string)GetValue(SingleSelectedItemProperty); }
            set { SetValue(SingleSelectedItemProperty, value); }
        }
        public string FirstNameFill
        {
            get { return (string)GetValue(FirstNameFillProperty); }
            set { SetValue(FirstNameFillProperty, value); }
        }
        public string SecondNameFill
        {
            get { return (string)GetValue(SecondNameFillProperty); }
            set { SetValue(SecondNameFillProperty, value); }
        }
        public string SalaryFill
        {
            get { return (string)GetValue(SalaryFillProperty); }
            set { SetValue(SalaryFillProperty, value); }
        }
        public string PositionFill
        {
            get { return (string)GetValue(PositionFillProperty); }
            set { SetValue(PositionFillProperty, value); }
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
            EventManager.RegisterRoutedEvent("WorkersListItemChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(WorkersList));
        public event RoutedEventHandler WorkersListItemChanged
        {
            add { AddHandler(WorkersListItemChangedEvent, value); }
            remove { RemoveHandler(WorkersListItemChangedEvent, value); }
        }
        void RaiseWorkersListItemChanged(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(WorkersListItemChangedEvent);
            RaiseEvent(args);
        }
        #endregion
    }
}
