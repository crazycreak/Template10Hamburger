using Template10.Mvvm;
using Windows.UI.Xaml.Controls;

namespace Template10Hamburger.Models
{
    public class NavigationItemModel : BindableBase
    {
        private string _text;
        public string Text { get { return _text; } set { Set(ref _text, value); } }

        private Symbol _icon;
        public Symbol Icon { get { return _icon; } set { Set(ref _icon, value); } }
    }
}