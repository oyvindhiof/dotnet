using ComicsUniverse.ViewModels;

using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.WinUI.UI.Controls;

using Microsoft.UI.Xaml.Controls;

namespace ComicsUniverse.Views
{
    public sealed partial class CharactersPage : Page
    {
        public CharactersViewModel ViewModel { get; }

        public CharactersPage()
        {
            ViewModel = Ioc.Default.GetService<CharactersViewModel>();
            InitializeComponent();
        }

        private void OnViewStateChanged(object sender, ListDetailsViewState e)
        {
            if (e == ListDetailsViewState.Both)
            {
                ViewModel.EnsureItemSelected();
            }
        }
    }
}
