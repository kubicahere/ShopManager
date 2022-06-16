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
    public partial class StartControl : UserControl
    {
        public StartControl()
        {
            InitializeComponent();
        }
        #region Dependencies
        public static readonly DependencyProperty UserLoginProperty = DependencyProperty.Register(
            "LoginUser", typeof(ICommand), typeof(StartControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty UserRegisterProperty = DependencyProperty.Register(
            "RegisterUser", typeof(ICommand), typeof(StartControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty RootLoginProperty = DependencyProperty.Register(
            "LoginRoot", typeof(ICommand), typeof(StartControl), new FrameworkPropertyMetadata(null)
            );
        #endregion
        #region Getters & setters
        public ICommand LoginUser
        {
            get { return (ICommand)GetValue(UserLoginProperty); }
            set { SetValue(UserLoginProperty, value); }
        }
        public ICommand RegisterUser
        {
            get { return (ICommand)GetValue(UserRegisterProperty); }
            set { SetValue(UserRegisterProperty, value); }
        }
        public ICommand LoginRoot
        {
            get { return (ICommand)GetValue(RootLoginProperty); }
            set { SetValue(RootLoginProperty, value); }
        }
        #endregion
        #region Events
        public static readonly RoutedEvent UserLoginClickEvent =
            EventManager.RegisterRoutedEvent("OtherUserLoginClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(StartControl));
        public event RoutedEventHandler UserLoginClick
        {
            add { AddHandler(UserLoginClickEvent, value); }
            remove { RemoveHandler(UserLoginClickEvent, value); }
        }
        void RaiseUserLoginClick(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(UserLoginClickEvent);
            RaiseEvent(args);
        }
        public static readonly RoutedEvent UserRegisterClickEvent =
            EventManager.RegisterRoutedEvent("OtherUserRegisterClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(StartControl));
        public event RoutedEventHandler UserRegisterClick
        {
            add { AddHandler(UserRegisterClickEvent, value); }
            remove { RemoveHandler(UserRegisterClickEvent, value); }
        }
        void RaiseUserRegisterClick(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(UserRegisterClickEvent);
            RaiseEvent(args);
        }
        public static readonly RoutedEvent RootLoginClickEvent =
            EventManager.RegisterRoutedEvent("OtherRootLoginClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(StartControl));
        public event RoutedEventHandler RootLoginClick
        {
            add { AddHandler(RootLoginClickEvent, value); }
            remove { RemoveHandler(RootLoginClickEvent, value); }
        }
        void RaiseRootLoginClick(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(RootLoginClickEvent);
            RaiseEvent(args);
        }
        #endregion
    }
}
