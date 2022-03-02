*Recommended Markdown viewer: [Markdown Editor VS Extension](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.MarkdownEditor).*

This project was created using [Microsoft Windows Template Studio](https://aka.ms/wts).

This project uses resources from https://www.dccomics.com/characters; all site content TM and © 2020 DC Entertainment, all rights reserved.

## Getting Started
This app was built using WinUI 3 and Windows App SDK (previously known as Project Reunion).
Windows UI Library (WinUI) 3 is a native user experience (UX) framework for both Windows Desktop and UWP apps.

You're ready to build, deploy, and launch your app hitting F5. You can find the app entry point in the `App.xaml.cs` file. 
Add a breakpoint in the `OnLaunched` method and debug the code. Step into the `ActivationService` methods to understand the app lifecycle.

Don't forget to review the `developer TODOs` we've added for you.
You can open the Task List using the menu `Views -> Task List`.

## File Structure
```
.
├── ComicsUniverse/ - WinUI 3 Desktop app
│ ├── Activation/ - app activation handlers
│ ├── Behaviors/ - UI controls behaviors
│ ├── Contracts/ - class interfaces
│ ├── Helpers/ - static helper classes
│ ├── Services/ - services implementations
│ │ ├── ActivationService.cs - app activation and initialization
│ │ ├── NavigationService.cs - navigate between pages
│ │ └──  ...
│ ├── Strings/en-us/Resources.resw - localized string resources
│ ├── Styles/ - custom style definitions
│ ├── ViewModels/ - properties and commands consumed in the views
│ ├── Views/ - UI pages
│ │ ├── ShellPage.xaml - main app page with navigation frame (only for SplitView and MenuBar)
│ │ └── ...
│ └── App.xaml - app definition and lifecycle events
├── ComicsUniverse.Core/ - core project (.NET Standard)
│ ├── Constants/ - constants
│ ├── Contracts/ - class interfaces
│ ├── Helpers/ - static helper classes
│ ├── Dtos/ - business objects used to transfer data
│ └── Services/ - services implementations
├── ComicsUniverse (Package)/ - MSIX packaging project
│ ├── Strings/en-us/Resources.resw - localized string resources
│ └── Package.appxmanifest - app properties and declarations
├── ComicsUniverse.Data.Api/ - RESTful Api exposing the database
├── ComicsUniverse.DataAccess/ - EF based data access
├── ComicsUniverse.Image.Api/ - RESTful Api for handling impages
├── ComicsUniverse.Model/ - Model resources used throughout the solution
├── ComicsUniverse.sln - open the solution file in Visual Studio
└── README.md - this file
```

### Design pattern
This app uses MVVM Toolkit, for more information see https://aka.ms/mvvmtoolkit.

### Project type
This app is a blank advanced project, for more information see [blank advanced docs](https://github.com/microsoft/WindowsTemplateStudio/blob/dev/docs/UWP/projectTypes/blankadvanced.md).

## Publish / Distribute

Use the [packaging project](http://aka.ms/msix) to create the app package to distribute your app and future updates. 
Right click on the packaging project and click `Publish -> Create App Packages...` to create an app package.

## Additional Documentation

- [WTS WinUI 3 docs](https://github.com/microsoft/WindowsTemplateStudio/tree/dev/docs/WinUI)
- [WinUI 3 docs](https://docs.microsoft.com/windows/apps/winui/winui3/)
- [WinUI 3 GitHub repo](https://github.com/microsoft/microsoft-ui-xaml)
- [Windows App SDK GitHub repo](https://github.com/microsoft/WindowsAppSDK)
