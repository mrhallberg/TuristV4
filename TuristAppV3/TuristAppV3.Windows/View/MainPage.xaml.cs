using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using TuristAppV3;
using TuristAppV3.ViewModel;

namespace TuristAppV3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            if (User.loggedIn)
            {
                Frame.Navigate(typeof(Oversigt));
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (User.Login(Brugernavn.Text, Password.Password))
            {
                Frame.Navigate(typeof (Oversigt));
            }
            ForkertLogin.Text = "Forkert brugernavn/kode!";
            
        }

        private void OpretBruger_Click(object sender, RoutedEventArgs e)
        {
            if (Brugernavn.Text != "" && Password.Password != "")
            {
                if (User.CreateUser(Brugernavn.Text, Password.Password))
                {
                    User.Login(Brugernavn.Text, Password.Password);
                    Frame.Navigate(typeof(Oversigt));
                }
                else
                {
                    ForkertLogin.Text = "Brugernavn er taget";
                }
            }
            else
            {
                ForkertLogin.Text = "Udfyld begge felter";
            }
            
        }
    }
}
