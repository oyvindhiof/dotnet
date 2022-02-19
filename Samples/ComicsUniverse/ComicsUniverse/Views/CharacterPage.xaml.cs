using ComicsUniverse.ViewModels;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ComicsUniverse.Views
{
    public sealed partial class CharacterPage : Page
    {
        public CharacterViewModel ViewModel { get; }

        public CharacterPage(CharacterViewModel viewModel)
        {
            ViewModel = viewModel;

            this.InitializeComponent();
        }
    }
}
