using FinalAssignment.Helpers;
using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinalAssignment.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        string userName;
        string password;
        private DelegateCommand<string> login;

        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                NotifyPropertyChanged("UserName");
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                NotifyPropertyChanged("Password");
            }
        }

        public DelegateCommand<string> Login
        {
            get
            {
                return this.login ?? (this.login = new DelegateCommand<string>(
                                                             (arg) => true,
                                                             this.ExecuteLogin));
            }
        }

        private void ExecuteLogin(string obj)
        {
            App app = (App)Application.Current; 
            App.GoToPage(new MainPage());
             
        }
    }
}
