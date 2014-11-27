using Windows.UI.Xaml.Media.Imaging;
using TuristAppV3.Common;
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

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237
using TuristAppV3.ViewModel;

namespace TuristAppV3.View
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    /// 
    /// kommentar
    public sealed partial class DetailView : Page
    {

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        private DetailViewModel detail;

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }


        public DetailView()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;

            detail = new DetailViewModel();
            DataContext = detail;
            pageTitle.Text = OversigtViewModel._selectedOversigt.ToString();
            if (OversigtViewModel.Language == "English")
            {
                LangToggle.IsOn = true;
            }
        }

        /// <summary>
        /// Populates the page with content passed during navigation. Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session. The state will be null the first time a page is visited.</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetIndex();
        }

        private void SetIndex()
        {
            try
            {
                detail.SelectedDetail = DetailViewModel.details[ListGridView.SelectedIndex];
                LinkButton.Content = detail.HomePage;
                LinkButton.Visibility = Visibility.Visible;
            }
            catch (Exception)
            {
                detail.SelectedDetail = DetailViewModel.Default;
                LinkButton.Visibility = Visibility.Collapsed;
            }
        }

        private void Log_ud_OnClick(object sender, RoutedEventArgs e)
        {
            User.loggedIn = false;
            OversigtViewModel._selectedOversigt = null;
            DetailViewModel._selectedDetail = null;
            Frame.Navigate(typeof(MainPage));
        }

        private void ToggleSwitch_OnToggled(object sender, RoutedEventArgs e)
        {
            OversigtViewModel.Language = LangToggle.IsOn ? "English" : "Danish";
            detail.ChangeLanguage();
            SetIndex();
        }
    }
}
