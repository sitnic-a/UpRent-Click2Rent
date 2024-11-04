using Click2Rent.Database.Services;
using Click2Rent.Domain;
using Click2Rent.WPFClient.Views;
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

        private List<UserRole> _dbUserRoles { get; set; } = new List<UserRole>();

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

        public AddUserWindowViewModel(VModels.User selectedUser, IBaseService<UserRole> userRoleService)
        {
            Username = selectedUser.Username;
            TempUsername = Username;
            _userRoleService = userRoleService;
            _dbUserRoles = _userRoleService.GetAll()
                .Select(ur => new UserRole
                {
                    UserId = ur.Id,
                    RoleId = ur.RoleId
                }).ToList();

            Roles = _dbUserRoles
                .Where(u => u.UserId == selectedUser.Id)
                .Select(r => r.RoleId).ToList();

            foreach (var item in Roles)
            {
                if (item == 1)
                    AdminRoleId = true;
                if (item == 2)
                    UserRoleId = true;
                if (item == 3)
                    IzvjestajiRoleId = true;
            }   
        }
        public AddUserWindowViewModel(VModels.User loggedUser, IBaseService<User> userService, IBaseService<UserRole> userRoleService)
        {
            LoggedUser = loggedUser;
            _userService = userService;
            _userRoleService = userRoleService;
            TempUserRoleId = UserRoleId;
            TempAdminRoleId = AdminRoleId;
            TempIzvjestajiRoleId = IzvjestajiRoleId;
            Roles = GetSelectedRoles();
        }

        public List<int> GetSelectedRoles()
        {
            if (UserRoleId == true)
                Roles.Add(2);
            if (AdminRoleId == true)
                Roles.Add(1);
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
            //Roles = GetSelectedRoles();
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
                MessageBox.Show("Nije moguće nastaviti jer podaci nisu validni. Username i role moraju biti unešeni", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var requestUser = new User(Username, LoggedUser.CreatedByUserId);
            var newUserRecord = _userService.Add(requestUser);

            if (newUserRecord == null || !Roles.Any())
            {
                MessageBox.Show("Nije moguće nastaviti!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            foreach (var role in Roles)
            {
                var newUserRoleRecord = new UserRole(newUserRecord.Id, role, LoggedUser.CreatedByUserId);
                _userRoleService.Add(newUserRoleRecord);
            }
            MessageBox.Show("Uspješno ste dodali korisnika! Sada ćete biti preusmjereni na početak aplikacije!", "Informacija", MessageBoxButton.OK, MessageBoxImage.Information);
            App.Current.Windows[1].Close();
            UsersWindow window = new UsersWindow();
            window.DataContext = new UsersWindowViewModel(_userService, _userRoleService);
            App.Current.Windows[0].Close();
            window.Show();
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
