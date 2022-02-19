using ComicsUniverse.Contracts.Services;
using ComicsUniverse.Contracts.ViewModels;
using ComicsUniverse.Core.Constants;
using ComicsUniverse.Core.Contracts.Services;
using ComicsUniverse.Core.Dtos;
using ComicsUniverse.Views;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ComicsUniverse.ViewModels
{
    public class CharactersViewModel : ObservableRecipient, INavigationAware
    {
        private readonly ICharacterService _characterService;
        private readonly INavigationService _navigationService;

        public CharactersViewModel(ICharacterService characterService, INavigationService navigationService)
        {
            _characterService = characterService;
            _navigationService = navigationService;
        }

        private CharacterViewModel _selectedCharacter;
        public CharacterViewModel Selected
        {
            get => _selectedCharacter;
            set => SetProperty(ref _selectedCharacter, value);
        }

        private ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new RelayCommand<CharacterViewModel>(async param =>
                    {
                        ContentDialog deleteDialog = new()
                        {
                            Title = "Delete character permanently?",
                            Content = "If you delete this character, you won't be able to recover it. Do you want to delete it?",
                            PrimaryButtonText = "Delete",
                            CloseButtonText = "Cancel",
                            DefaultButton = ContentDialogButton.Close,
                            XamlRoot = _navigationService.Frame.XamlRoot
                        };

                        ContentDialogResult result = await deleteDialog.ShowAsync();

                        if (result == ContentDialogResult.Primary)
                        {
                            if (await _characterService.DeleteCharacterAsync((CharacterDto)param))
                            {
                                _ = Characters.Remove(param);
                            }
                        }
                    }, param => param != null);
                }

                return _deleteCommand;
            }
        }

        private ICommand _addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand(async () =>
                    {
                        CharacterViewModel newCharacter = new() { ProfileImage = $"{BaseAddress.ImageApi}/Unknown.jpg" };
                        CharacterPage page = new(newCharacter);

                        ContentDialog dialog = new()
                        {
                            Title = "Add new character",
                            Content = page,
                            PrimaryButtonText = "Add",
                            IsPrimaryButtonEnabled = false,
                            CloseButtonText = "Cancel",
                            DefaultButton = ContentDialogButton.Primary,
                            XamlRoot = _navigationService.Frame.XamlRoot
                        };

                        newCharacter.PropertyChanged += (sender, e) => dialog.IsPrimaryButtonEnabled = !newCharacter.HasErrors;

                        ContentDialogResult result = await dialog.ShowAsync();

                        if (result == ContentDialogResult.Primary)
                        {
                            var characterDto = await _characterService.CreateCharacterAsync((CharacterDto)newCharacter);
                            CharacterViewModel character = new(characterDto);

                            Characters.Add(character);
                            Selected = character;
                        }
                    });
                }

                return _addCommand;
            }
        }

        private ICommand _settingsCommand;
        public ICommand SettingsCommand
        {
            get
            {
                if (_settingsCommand == null)
                {
                    _settingsCommand = new RelayCommand(() =>
                    {
                        _navigationService.NavigateTo(typeof(SettingsViewModel).FullName);
                    });
                }

                return _settingsCommand;
            }
        }

        public ObservableCollection<CharacterViewModel> Characters { get; private set; } = new();

        public async void OnNavigatedTo(object parameter)
        {
            if (Characters.Count == 0)
            {
                var characterDtos = await _characterService.GetCharactersAsync();

                foreach (var characterDto in characterDtos)
                {
                    Characters.Add(new CharacterViewModel(characterDto));
                }
            }
        }

        public void OnNavigatedFrom() { }

        public void EnsureItemSelected()
        {
            if (Selected == null && Characters.Count > 0)
            {
                Selected = Characters.First();
            }
        }
    }
}
