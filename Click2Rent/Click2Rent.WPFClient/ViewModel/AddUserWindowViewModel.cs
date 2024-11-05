using Click2Rent.Database.Services;
using Click2Rent.Domain;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using VModels = Click2Rent.WPFClient.Models;

namespace Click2Rent.WPFClient.ViewModel
{
    public class AddUserWindowViewModel : INotifyPropertyChanged
    {
        private readonly IBaseService<User> _userService;
        private readonly IBaseService<UserRole> _userRoleService;

        public event PropertyChangedEventHandler? PropertyChanged;

        public RelayCommand CloseCommand => new RelayCommand(_execute => CloseWindow());
        public RelayCommand SaveUserCommand => new RelayCommand(_execute => SaveUser());

        public string Username { get; set; } = "Unesite korisničko ime";
        public string TempUsername { get; set; } = "Unesite korisničko ime";
        public List<int> Roles { get; set; } = new List<int>();
        public bool UserRoleId { get; set; }
        public bool AdminRoleId { get; set; }
        public bool IzvjestajiRoleId { get; set; }

        public bool TempUserRoleId { get; set; }
        public bool TempAdminRoleId { get; set; }
        public bool TempIzvjestajiRoleId { get; set; }

        public VModels.User LoggedUser { get; set; }
        public AddUserWindowViewModel() { }
        public AddUserWindowViewModel(VModels.User loggedUser, IBaseService<User> userService, IBaseService<UserRole> userRoleService)
        {
            LoggedUser = loggedUser;
            _userService = userService;
            _userRoleService = userRoleService;
            TempUserRoleId = UserRoleId;
            TempAdminRoleId = AdminRoleId;
            TempIzvjestajiRoleId = IzvjestajiRoleId;
        }

        public List<int> GetSelectedRoles()
        {
            if (UserRoleId == true)
                Roles.Add(1);
            if (AdminRoleId == true)
                Roles.Add(2);
            if (IzvjestajiRoleId == true)
                Roles.Add(3);

            return Roles;
        }
        public bool IsUpdated()
        {
            if (Username != TempUsername || UserRoleId)
                return true;

            return false;
        }
        public void CloseWindow()
        {
            Roles = GetSelectedRoles();
            if (Username != TempUsername ||
                UserRoleId != TempUserRoleId ||
                AdminRoleId != TempAdminRoleId ||
                IzvjestajiRoleId != TempIzvjestajiRoleId)
            {
                MessageBox.Show($"NIJE ISTI! IMA {Roles.Count} ROLA");
            }
            App.Current.Windows[1].Close();
        }

        public void SaveUser()
        {
            if (!IsValid())
            {
                MessageBox.Show("Ne more dalje!");
                return;
            }
            var requestUser = new User(Username,LoggedUser.CreatedByUserId);
            var newUserRecord = _userService.Add(requestUser);
            var selectedRoles = GetSelectedRoles();

            if (newUserRecord == null || !selectedRoles.Any())
            {
                MessageBox.Show("Ne more dalje!");
                return;
            }

            foreach (var role in selectedRoles)
            {
                var newUserRoleRecord = new UserRole(newUserRecord.Id, role);
                _userRoleService.Add(newUserRoleRecord);
                MessageBox.Show("USPJESNO KREIRANO SVE!");
                App.Current.Windows[1].Close();
            }
            MessageBox.Show("Hvala, rokaj!");
            return;
        }
        public bool IsValid()
        {
            Roles = GetSelectedRoles();

            if (Username.IsNullOrEmpty() || Roles.Count <= 0)
                return false;

            return true;
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
