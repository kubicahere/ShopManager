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
    /// Logika interakcji dla klasy UserAccount.xaml
    /// </summary>
    public partial class UserAccount : UserControl
    {
        public UserAccount()
        {
            InitializeComponent();
        }
        #region Dependencies
        public static readonly DependencyProperty BackButtonProperty = DependencyProperty.Register(
            "BackButton", typeof(ICommand), typeof(UserAccount), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty EditProperty = DependencyProperty.Register(
            "Edit", typeof(ICommand), typeof(UserAccount), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty FirstnameProperty = DependencyProperty.Register(
            "Firstname", typeof(string), typeof(UserAccount), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty SurnameProperty = DependencyProperty.Register(
            "Surname", typeof(string), typeof(UserAccount), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty LoginProperty = DependencyProperty.Register(
            "Login", typeof(string), typeof(UserAccount), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register(
            "Password", typeof(string), typeof(UserAccount), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty RepeatPasswordProperty = DependencyProperty.Register(
            "RepeatPassword", typeof(string), typeof(UserAccount), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty PhoneNumberProperty = DependencyProperty.Register(
            "PhoneNumber", typeof(string), typeof(UserAccount), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty EmailAddressProperty = DependencyProperty.Register(
            "EmailAddress", typeof(string), typeof(UserAccount), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty CanChangeProperty = DependencyProperty.Register(
            "CanChange", typeof(string), typeof(UserAccount), new FrameworkPropertyMetadata(null)
            );
        #endregion
        #region Getters & setters
        public ICommand BackButton
        {
            get { return (ICommand)GetValue(BackButtonProperty); }
            set { SetValue(BackButtonProperty, value); }
        }
        public ICommand Edit
        {
            get { return (ICommand)GetValue(EditProperty); }
            set { SetValue(EditProperty, value); }
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
        public string CanChange
        {
            get { return (string)GetValue(CanChangeProperty); }
            set { SetValue(CanChangeProperty, value); }
        }
        #endregion
        #region Events
        public static readonly RoutedEvent BackButtonClickEvent =
            EventManager.RegisterRoutedEvent("OtherEditBackButtonClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(UserAccount));
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
        public static readonly RoutedEvent EditClickEvent =
            EventManager.RegisterRoutedEvent("OtherEditClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(UserAccount));
        public event RoutedEventHandler EditClick
        {
            add { AddHandler(EditClickEvent, value); }
            remove { RemoveHandler(EditClickEvent, value); }
        }
        void RaiseEditClick(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(EditClickEvent);
            RaiseEvent(args);
        }
        #endregion
    }
}
