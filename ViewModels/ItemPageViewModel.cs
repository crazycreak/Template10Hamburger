using System.Collections.Generic;
using System.Threading.Tasks;
using Template10Hamburger.Classes;
using Windows.UI;
using Windows.UI.Xaml.Navigation;

namespace Template10Hamburger.ViewModels
{
    public class ItemPageViewModel : MyViewModelBase
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
                string key = parameter as string; ;
                Title = key;

                int buttonIndex = 0;
                Color myColor;
                switch (key)
                {
                    case "ItemPage1":
                        buttonIndex = 1;
                        myColor = Colors.Green;
                        break;
                    case "ItemPage2":
                        buttonIndex = 2;
                        myColor = Colors.Orange;
                        break;
                    case "ItemPage3":
                        buttonIndex = 3;
                        myColor = Colors.Aqua;
                        break;
                }
                updateNavigation(myColor, buttonIndex);
            }
            return Task.CompletedTask;
        }

        private string _Title = "Default";
        public string Title { get { return _Title; } set { Set(ref _Title, value); } }
    }
}
