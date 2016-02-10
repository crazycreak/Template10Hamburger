using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace Template10Hamburger.ViewModels
{
    public class ItemPageViewModel : ViewModelBase
    {
        public ItemPageViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                Title = "Designtime value";
            }
        }

        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (parameter != null)
            {
                Title = parameter as string;
            }
            return base.OnNavigatedToAsync(parameter, mode, state);
        }

        private string _Title = "Default";
        public string Title { get { return _Title; } set { Set(ref _Title, value); } }
    }
}
