using System.ComponentModel;
using System.Linq;
using Template10.Common;
using Template10.Controls;
using Template10.Services.NavigationService;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Template10Hamburger.Views
{
    // DOCS: https://github.com/Windows-XAML/Template10/wiki/Docs-%7C-SplitView
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
            MyHamburgerMenu.PrimaryButtons.Add(genereateButton("ItemPage1"));
            MyHamburgerMenu.PrimaryButtons.Add(genereateButton("ItemPage2"));
            MyHamburgerMenu.PrimaryButtons.Add(genereateButton("ItemPage3"));
        }

        private HamburgerButtonInfo genereateButton(string Text)
        {
            StackPanel stackPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal
            };
            stackPanel.Children.Add(new SymbolIcon
            {
                Width = 48,
                Height = 48,
                Symbol = Symbol.Link
            });
            stackPanel.Children.Add(new TextBlock
            {
                Margin = new Thickness(12, 0, 0, 0),
                VerticalAlignment = VerticalAlignment.Center,
                Text = Text
            });
            HamburgerButtonInfo hamburgerButton = new HamburgerButtonInfo
            {
                Content = stackPanel,
                ButtonType = HamburgerButtonInfo.ButtonTypes.Toggle,
                ClearHistory = false,
                PageType = typeof(Views.ItemPage),
                PageParameter = Text
            };
            return hamburgerButton;
        }
    }
}

