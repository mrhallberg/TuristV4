using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using TuristAppV3.Annotations;
using TuristAppV3.Model;
using TuristAppV3.View;
using TuristAppV3.ViewModel;

namespace TuristAppV3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary> 
    public sealed partial class Oversigt : INotifyPropertyChanged
    {
        private OversigtViewModel oversigt;

        public Oversigt()
        {
            this.InitializeComponent();
            oversigt = new OversigtViewModel();
            DataContext = oversigt;
            if (OversigtViewModel.Language == "English")
            {
                LangToggle.IsOn = true;
            }

        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            User.loggedIn = false;
            oversigt.SelectedOversigt = null;
            DetailViewModel._selectedDetail = null;
            Frame.Navigate(typeof (MainPage));
        }

        private void GridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetIndex();
        }

        private void SetIndex()
        {
            try
            {
                oversigt.SelectedOversigt = OversigtViewModel.Kategorier[OversigtListe.SelectedIndex];
                OversigtButton.Visibility = Visibility.Visible;
            }
            catch (Exception)
            {
                oversigt.SelectedOversigt = OversigtViewModel.Default;
                OversigtButton.Visibility = Visibility.Collapsed;
            }
        }

        private void ToggleSwitch_OnToggled(object sender, RoutedEventArgs e)
        {
            OversigtViewModel.Language = LangToggle.IsOn ? "English" : "Danish";
            oversigt.ChangeLanguage();
            SetIndex();
        }

        #region 

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        private void OversigtButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (DetailView));
        }

    }
}
