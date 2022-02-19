using ComicsUniverse.Contracts.Services;
using ComicsUniverse.Helpers;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using System.Windows.Input;
using Windows.ApplicationModel;

namespace ComicsUniverse.ViewModels
{
    public class SettingsViewModel : ObservableRecipient
    {
        private readonly INavigationService _navigationService;

        private readonly IThemeSelectorService _themeSelectorService;
        private ElementTheme _elementTheme;

        public ElementTheme ElementTheme
        {
            get { return _elementTheme; }

            set => SetProperty(ref _elementTheme, value);
        }

        private string _versionDescription;

        public string VersionDescription
        {
            get { return _versionDescription; }

            set => SetProperty(ref _versionDescription, value);
        }

        private ICommand _switchThemeCommand;
        public ICommand SwitchThemeCommand
        {
            get
            {
                if (_switchThemeCommand == null)
                {
                    _switchThemeCommand = new RelayCommand<ElementTheme>(
                        async (param) =>
                        {
                            if (ElementTheme != param)
                            {
                                ElementTheme = param;
                                await _themeSelectorService.SetThemeAsync(param);
                            }
                        });
                }

                return _switchThemeCommand;
            }
        }

        private ICommand _backCommand;
        public ICommand BackCommand
        {
            get
            {
                if (_backCommand == null)
                {
                    _backCommand = new RelayCommand(() =>
                    {
                        _navigationService.GoBack();
                    });

                }

                return _backCommand;
            }
        }

        public SettingsViewModel(IThemeSelectorService themeSelectorService, INavigationService navigationService)
        {
            _themeSelectorService = themeSelectorService;
            _elementTheme = _themeSelectorService.Theme;
            VersionDescription = GetVersionDescription();

            _navigationService = navigationService;
        }

        private static string GetVersionDescription()
        {
            var appName = "AppDisplayName".GetLocalized();
            var package = Package.Current;
            var packageId = package.Id;
            var version = packageId.Version;

            return $"{appName} - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
        }
    }
}
