using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Utils;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Template10Hamburger.Classes
{
    public class MyViewModelBase : ViewModelBase
    {
        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            updateNavigation(AccentColor);
            return base.OnNavigatedToAsync(parameter, mode, state);
        }

        protected readonly Color AccentColor = (Color)Application.Current.Resources["CustomColor"];

        private SolidColorBrush _backgroundBrush;
        public SolidColorBrush BackgroundBrush { get { return _backgroundBrush; } set { Set(ref _backgroundBrush, value); } }

        public void updateNavigation(Color Color, int Index)
        {
            updateNavigation(Color);
            updateNavigation(Index);
        }

        public void updateNavigation(int Index)
        {
            Views.Shell.HamburgerMenu.Selected = Views.Shell.HamburgerMenu.PrimaryButtons.ElementAt(Index);
        }

        public void updateNavigation(Color Color)
        {
            BackgroundBrush = Color.ToSolidColorBrush();
            Views.Shell.HamburgerMenu.RefreshStyles(Color);
        }
    }
}