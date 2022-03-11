using ComicsUniverse.Core.Constants;
using ComicsUniverse.Core.Dtos;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ComicsUniverse.ViewModels
{
    // The view model class dresses the dto with functionality, e.g. validation and obervability
    // The use of ObservableValidator is inspired by Diederik Krols article https://xamlbrewer.wordpress.com/2021/06/07/data-validation-with-the-microsoft-mvvm-toolkit/
    public class CharacterViewModel : ObservableValidator
    {
        public CharacterViewModel()
        {
            _characterDto = new CharacterDto();
            ValidateAllProperties();
            _errors.AddRange(GetErrors());
        }
        public CharacterViewModel(CharacterDto characterDto)
        {
            _characterDto = characterDto;
            ValidateAllProperties();
            _errors.AddRange(GetErrors());
        }

        public static explicit operator CharacterDto(CharacterViewModel c) => new()
        {
            CharacterId = c.CharacterId,
            Name = c.Name,
            Alias = c.Alias,
            Occupation = c.Occupation,
            Description = c.Description,
            ProfileImage = c.ProfileImage,
            Universe = c.Universe,
            Powers = c.Powers
        };

        private readonly CharacterDto _characterDto;
        private readonly List<ValidationResult> _errors = new();

        public string Errors => string.Join(Environment.NewLine, from ValidationResult e in _errors select e.ErrorMessage);

        public new bool HasErrors => Errors.Length > 0;

        public string ProfileImageFullPath => $"{BaseAddress.ImageApi}/{ProfileImage}";

        public int CharacterId
        {
            get => _characterDto.CharacterId;
            set => SetProperty(_characterDto.CharacterId, value, _characterDto, (_characterDto, id) => _characterDto.CharacterId = value);
        }

        [Required(ErrorMessage = "Name is required")]
        [MinLength(2, ErrorMessage = "Name should be longer than one character")]
        public string Name
        {
            get => _characterDto.Name;
            set
            {
                _ = _errors.RemoveAll(v => v.MemberNames.Contains(nameof(Name)));
                _ = TrySetProperty(_characterDto.Name, value, (name) => _characterDto.Name = name, out IReadOnlyCollection<ValidationResult> errors);

                _errors.AddRange(errors);
                OnPropertyChanged(nameof(Errors));
                OnPropertyChanged(nameof(HasErrors));
            }
        }

        [Required(ErrorMessage = "Alias is required")]
        [MinLength(2, ErrorMessage = "Alias should be longer than one character")]
        public string Alias
        {
            get => _characterDto.Alias;
            set
            {
                _ = _errors.RemoveAll(v => v.MemberNames.Contains(nameof(Alias)));
                _ = TrySetProperty(_characterDto.Alias, value, (alias) => _characterDto.Alias = alias, out IReadOnlyCollection<ValidationResult> errors);

                _errors.AddRange(errors);
                OnPropertyChanged(nameof(Errors));
                OnPropertyChanged(nameof(HasErrors));
            }
        }

        public string Occupation
        {
            get => _characterDto.Occupation;
            set => SetProperty(_characterDto.Occupation, value, (occupation) => _characterDto.Occupation = occupation);
        }

        public Universes Universe
        {
            get => _characterDto.Universe;
            set => SetProperty(_characterDto.Universe, value, (universe) => _characterDto.Universe = universe);
        }
        public string ProfileImage
        {
            get => _characterDto.ProfileImage;
            set => SetProperty(_characterDto.ProfileImage, value, (profileImage) => _characterDto.ProfileImage = profileImage);
        }

        public string Description
        {
            get => _characterDto.Description;
            set => SetProperty(_characterDto.Description, value, (description) => _characterDto.Description = description);
        }

        public List<SuperPowerDto> Powers
        {
            get => _characterDto.Powers;
            set => SetProperty(_characterDto.Powers, value, (powers) => _characterDto.Powers = powers);
        }
    }
}
