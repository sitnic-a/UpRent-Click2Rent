using Click2Rent.Database.Services;
using Click2Rent.Domain;
using Click2Rent.WPFClient.Views;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
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
        public RelayCommand SaveAndExitCommand => new RelayCommand(_execute => SaveAndExit());

        public string Username { get; set; } = "Unesite korisničko ime";
        public string TempUsername { get; set; } = "Unesite korisničko ime";
        public List<int> Roles { get; set; } = new List<int>();
        public bool UserRoleId { get; set; }
        public bool AdminRoleId { get; set; }
        public bool IzvjestajiRoleId { get; set; }

        public bool TempUserRoleId { get; set; }
        public bool TempAdminRoleId { get; set; }
        public bool TempIzvjestajiRoleId { get; set; }

        public VModels.User LoggedUser { get; set; } = new VModels.User();
        public VModels.User SelectedUser { get; set; } = new VModels.User();
        public VModels.User UpdatedUser { get; set; } = new VModels.User();



        public AddUserWindowViewModel() { }

        public AddUserWindowViewModel(VModels.User selectedUser, VModels.User loggedUser,IBaseService<User> userService, IBaseService<UserRole> userRoleService)
        {
            Username = selectedUser.Username;
            TempUsername = Username;
            _userService = userService;
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
                {
                    AdminRoleId = true;
                    TempAdminRoleId = AdminRoleId;
                }

                if (item == 2)
                {
                    UserRoleId = true;
                    TempUserRoleId = UserRoleId;
                }
                if (item == 3)
                {
                    IzvjestajiRoleId = true;
                    TempIzvjestajiRoleId = IzvjestajiRoleId;
                }
            }
            SelectedUser = selectedUser;
            LoggedUser = loggedUser;
        }
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
            if (SelectedUser.Username.IsNullOrEmpty() || SelectedUser.Id <= 0)
            {
                if (!UpdatedUser.Username.IsNullOrEmpty() || UpdatedUser.Id > 0)
                {
                    if (IsChanged())
                    {
                        var result = MessageBox.Show("Vaše promjene će biti izgubljene ukoliko nastavite. Da li želite da snimite promjene?", "Info", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {
                            SaveUser();
                            return;
                        }
                        else if (result == MessageBoxResult.No)
                        {
                            App.Current.Windows[1].Close();
                            return;
                        }
                    }
                    App.Current.Windows[1].Close();
                    return;
                }

                if (IsChanged())
                {
                    var result = MessageBox.Show("Vaše promjene će biti izgubljene ukoliko nastavite. Da li želite da snimite promjene?", "Info", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        SaveUser();
                        return;
                    }
                    else if(result == MessageBoxResult.No)
                    {
                        App.Current.Windows[1].Close();
                        return;
                    }
                }
            }

            if (IsChanged())
            {
                var result = MessageBox.Show("Vaše promjene će biti izgubljene ukoliko nastavite. Da li želite da snimite promjene?", "Info", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    if (SelectedUser != null)
                    {

                        UpdateUser(SelectedUser);
                        return;     
                    }
                    SaveUser();
                    return;
                }
                App.Current.Windows[0].Close();
                return;
            }
            App.Current.Windows[1].Close();
            return;
        }

        public bool IsChanged()
        {
            return Username != TempUsername ||
                UserRoleId != TempUserRoleId ||
                AdminRoleId != TempAdminRoleId ||
                IzvjestajiRoleId != TempIzvjestajiRoleId;
        }

        public void SaveUser()
        {
            UsersWindow window;
            if (!IsValid())
            {
                MessageBox.Show("Nije moguće nastaviti jer podaci nisu validni. Username i role moraju biti unešeni", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!SelectedUser.Username.IsNullOrEmpty() || SelectedUser.Id > 0)
            {
                UpdateUser(SelectedUser);
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
            window = new UsersWindow();
            window.DataContext = new UsersWindowViewModel(_userService, _userRoleService);
            App.Current.Windows[1].Topmost = true;
            window.Show();
            window.Topmost = false;
            App.Current.Windows[0].Close();
            return;
        }

        public void UpdateUser(VModels.User selectedUser)
        {
            Window window;
            var dbUser = _userService.GetById(selectedUser.Id);
            if (dbUser != null)
            {

                dbUser.Username = Username;
                dbUser.ModifiedDate = DateTime.Now;
                dbUser.ModifiedByUserId = LoggedUser.Id;

                _userService.Update(dbUser.Id, dbUser);
                UpdatedUser.Username = dbUser.Username;
                Roles.Clear();
                Roles = GetSelectedRoles();
                foreach (var role in Roles)
                {
                    var newUserRoleRecord = new UserRole(dbUser.Id, role, LoggedUser.CreatedByUserId);
                    _userRoleService.Add(newUserRoleRecord);
                }
                MessageBox.Show("Uspješno ste uredili podatke! Sad ćete biti preusmjereni na početak", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                window = new UsersWindow();
                window.DataContext = new UsersWindowViewModel(_userService, _userRoleService);
                App.Current.Windows[1].Topmost = true;
                window.Show();
                window.Topmost = false;
                App.Current.Windows[0].Close();
                return;
            }
        }

        public void SaveAndExit()
        {
            SaveUser();
            App.Current.Windows[0].Close();
            UsersWindow window = new UsersWindow();
            window.DataContext = new UsersWindowViewModel(_userService, _userRoleService);
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
