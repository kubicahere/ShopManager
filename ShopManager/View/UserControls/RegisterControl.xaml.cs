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
    /// Interaction logic for RegisterControl.xaml
    /// </summary>
    public partial class RegisterControl : UserControl
    {
        public RegisterControl()
        {
            InitializeComponent();
        }
        #region Dependencies
        public static readonly DependencyProperty BackButtonProperty = DependencyProperty.Register(
            "BackButton", typeof(ICommand), typeof(RegisterControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty RegisterProperty = DependencyProperty.Register(
            "Register", typeof(ICommand), typeof(RegisterControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty FirstnameProperty = DependencyProperty.Register(
            "Firstname", typeof(string), typeof(RegisterControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty SurnameProperty = DependencyProperty.Register(
            "Surname", typeof(string), typeof(RegisterControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty LoginProperty = DependencyProperty.Register(
            "Login", typeof(string), typeof(RegisterControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register(
            "Password", typeof(string), typeof(RegisterControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty RepeatPasswordProperty = DependencyProperty.Register(
            "RepeatPassword", typeof(string), typeof(RegisterControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty PhoneNumberProperty = DependencyProperty.Register(
            "PhoneNumber", typeof(string), typeof(RegisterControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty EmailAddressProperty = DependencyProperty.Register(
            "EmailAddress", typeof(string), typeof(RegisterControl), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty CanRegisterProperty = DependencyProperty.Register(
            "CanRegister", typeof(string), typeof(RegisterControl), new FrameworkPropertyMetadata(null)
            );
        #endregion
        #region Getters & setters
        public ICommand BackButton
        {
            get { return (ICommand)GetValue(BackButtonProperty); }
            set { SetValue(BackButtonProperty, value); }
        }
        public ICommand Register
        {
            get { return (ICommand)GetValue(RegisterProperty); }
            set { SetValue(RegisterProperty, value); }
        }
        public string Firstname
        {
            get { return (string)GetValue(FirstnameProperty); }
            set { SetValue(FirstnameProperty, value); }
        }
        public string Surname
        {
            get { return (string)GetValue(SurnameProperty); }
            set { SetValue(SurnameProperty, value); }
        }
        public string Login
        {
            get { return (string)GetValue(LoginProperty); }
            set { SetValue(LoginProperty, value); }
        }
        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }
        public string RepeatPassword
        {
            get { return (string)GetValue(RepeatPasswordProperty); }
            set { SetValue(RepeatPasswordProperty, value); }
        }
        public string PhoneNumber
        {
            get { return (string)GetValue(PhoneNumberProperty); }
            set { SetValue(PhoneNumberProperty, value); }
        }
        public string EmailAddress
        {
            get { return (string)GetValue(EmailAddressProperty); }
            set { SetValue(EmailAddressProperty, value); }
        }
        public string CanRegister
        {
            get { return (string)GetValue(CanRegisterProperty); }
            set { SetValue(CanRegisterProperty, value); }
        }
        #endregion
        #region Events
        public static readonly RoutedEvent BackButtonClickEvent =
            EventManager.RegisterRoutedEvent("OtherRegisterBackButtonClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(RegisterControl));
        public event RoutedEventHandler BackButtonClick
        {
            add { AddHandler(BackButtonClickEvent, value); }
            remove { RemoveHandler(BackButtonClickEvent, value); }
        }
        void RaiseGoBackClick(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(BackButtonClickEvent);
            RaiseEvent(args);
        }
        public static readonly RoutedEvent RegisterClickEvent =
            EventManager.RegisterRoutedEvent("OtherRegisterClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(RegisterControl));
        public event RoutedEventHandler RegisterClick
        {
            add { AddHandler(RegisterClickEvent, value); }
            remove { RemoveHandler(RegisterClickEvent, value); }
        }
        void RaiseRegisterClick(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(RegisterClickEvent);
            RaiseEvent(args);
        }
        #endregion
    }
}
