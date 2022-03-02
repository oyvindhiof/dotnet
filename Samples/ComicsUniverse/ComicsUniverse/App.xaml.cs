using ComicsUniverse.Activation;
using ComicsUniverse.Contracts.Services;
using ComicsUniverse.Core.Constants;
using ComicsUniverse.Core.Contracts.Services;
using ComicsUniverse.Core.Services;
using ComicsUniverse.Helpers;
using ComicsUniverse.Services;
using ComicsUniverse.ViewModels;
using ComicsUniverse.Views;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using System.IO;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.UI.WindowsAndMessaging;

// To learn more about WinUI3, see: https://docs.microsoft.com/windows/apps/winui/winui3/.
namespace ComicsUniverse
{
    public partial class App : Application
    {
        // Handle needs to stay alive as long as this window
        Microsoft.Win32.SafeHandles.SafeFileHandle iIcon;

        public static Window MainWindow { get; set; } = new Window() { Title = "AppDisplayName".GetLocalized() };

        public App()
        {
            InitializeComponent();

            UnhandledException += App_UnhandledException;
            Ioc.Default.ConfigureServices(ConfigureServices());

            // Commented out due to issues on some machines
            // LoadIcon("super-hero.ico");
        }

        private void LoadIcon(string iconName)
        {
            // see https://github.com/microsoft/microsoft-ui-xaml/issues/4056
            string iconPath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, iconName);
            iIcon = PInvoke.LoadImage(null, iconPath, GDI_IMAGE_TYPE.IMAGE_ICON, 24, 24, IMAGE_FLAGS.LR_LOADFROMFILE);

            HWND hWnd = new(WinRT.Interop.WindowNative.GetWindowHandle(MainWindow));

            _ = PInvoke.SendMessage(hWnd, WindowMessage.WM_SETICON, new WPARAM(0), new LPARAM(iIcon.DangerousGetHandle()));
        }

        private void App_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // TODO WTS: Please log and handle the exception as appropriate to YOUR scenario
            // For more info see https://docs.microsoft.com/windows/winui/api/microsoft.ui.xaml.unhandledexceptioneventargs
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            base.OnLaunched(args);
            var activationService = Ioc.Default.GetService<IActivationService>();
            await activationService.ActivateAsync(args);
        }

        private static System.IServiceProvider ConfigureServices()
        {
            ServiceCollection services = new();

            // Default Activation Handler
            _ = services.AddTransient<ActivationHandler<LaunchActivatedEventArgs>, DefaultActivationHandler>();

            // Other Activation Handlers

            // Services
            _ = services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();
            _ = services.AddSingleton<IActivationService, ActivationService>();
            _ = services.AddSingleton<IPageService, PageService>();
            _ = services.AddSingleton<INavigationService, NavigationService>();

            // Core Services
            services.AddSingleton<ICharacterService, CharacterService>();

            // Views and ViewModels
            _ = services.AddTransient<CharactersViewModel>();
            _ = services.AddTransient<CharactersPage>();
            _ = services.AddTransient<SettingsViewModel>();
            _ = services.AddTransient<SettingsPage>();
            return services.BuildServiceProvider();
        }
    }
}
