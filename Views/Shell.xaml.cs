using Template10.Common;
using Template10.Controls;
using Template10.Services.NavigationService;
using Template10Hamburger.Controls;
using Template10Hamburger.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Template10Hamburger.Views
{
    public sealed partial class Shell : Page
    {
        public static Shell Instance { get; set; }
        public static HamburgerMenu HamburgerMenu { get { return Instance.MyHamburgerMenu; } }

        public Shell()
        {
            Instance = this;
            InitializeComponent();
            Loaded += Shell_Loaded;
        }

        private void Shell_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            SettingsButton.IsEnabled = false;
        }

        public Shell(INavigationService navigationService)
        {
            Instance = this;
            InitializeComponent();
            SetNavigationService(navigationService);
            generateNavigation();
        }

        public void SetNavigationService(INavigationService navigationService)
        {
            MyHamburgerMenu.NavigationService = navigationService;
        }

        public static void SetBusy(bool busy, string text = null)
        {
            WindowWrapper.Current().Dispatcher.Dispatch(() =>
            {
                Instance.BusyView.BusyText = text;
                Instance.ModalContainer.IsModal = Instance.BusyView.IsBusy = busy;
            });
        }

        private void generateNavigation()
        {
            MyHamburgerMenu.PrimaryButtons.Add(genereateButton(new NavigationItemModel() { Text = "ItemPage1", Icon = Symbol.Link }));
            MyHamburgerMenu.PrimaryButtons.Add(genereateButton(new NavigationItemModel() { Text = "ItemPage2", Icon = Symbol.Mail }));
            MyHamburgerMenu.PrimaryButtons.Add(genereateButton(new NavigationItemModel() { Text = "ItemPage3", Icon = Symbol.Send }));
        }

        private HamburgerButtonInfo genereateButton(NavigationItemModel Item)
        {
            NavigationItem ItemControl = new NavigationItem() { DataContext = Item };
            HamburgerButtonInfo HamburgerButton = new HamburgerButtonInfo
            {
                Content = ItemControl,
                ButtonType = HamburgerButtonInfo.ButtonTypes.Toggle,
                ClearHistory = false,
                PageParameter = Item.Text,
            };
            HamburgerButton.Tapped += Button_Tapped;

            return HamburgerButton;
        }

        private void Button_Tapped(object sender, RoutedEventArgs e)
        {
            HamburgerButtonInfo Button = sender as HamburgerButtonInfo;
            MyHamburgerMenu.NavigationService.Navigate(typeof(ItemPage), Button.PageParameter);
        }
    }
}
