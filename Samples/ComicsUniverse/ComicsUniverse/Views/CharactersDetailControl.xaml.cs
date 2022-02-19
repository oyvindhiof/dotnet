using ComicsUniverse.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace ComicsUniverse.Views
{
    public sealed partial class CharactersDetailControl : UserControl
    {
        public CharacterViewModel ListDetailsMenuItem
        {
            get { return GetValue(ListDetailsMenuItemProperty) as CharacterViewModel; }
            set { SetValue(ListDetailsMenuItemProperty, value); }
        }

        public static readonly DependencyProperty ListDetailsMenuItemProperty = DependencyProperty.Register("ListDetailsMenuItem", typeof(CharacterViewModel), typeof(CharactersDetailControl), new PropertyMetadata(null, OnListDetailsMenuItemPropertyChanged));

        public CharactersDetailControl()
        {
            InitializeComponent();
        }

        private static void OnListDetailsMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as CharactersDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
