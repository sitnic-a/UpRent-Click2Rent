using Click2Rent.Database.Services;
using Click2Rent.Domain;
using Click2Rent.WPFClient.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using VModels = Click2Rent.WPFClient.Models;

#pragma warning disable CS8618 

namespace Click2Rent.WPFClient.ViewModel
{
    public class UsersWindowViewModel : INotifyPropertyChanged
    {
        private readonly IBaseService<User> _userService;
        private readonly IBaseService<UserRole> _userRoleService;
        private VModels.User LoggedUser = new VModels.User("Admin", 1);

        public event PropertyChangedEventHandler? PropertyChanged;

        public UsersWindowViewModel(IBaseService<User> userService)
        {
            _userService = userService;
            FillObservableCollection();
        }

        public UsersWindowViewModel(IBaseService<User> userService, IBaseService<UserRole> userRoleService)
        {
            _userService = userService;
            _userRoleService = userRoleService;
            FillObservableCollection();
        }

        public ObservableCollection<VModels.User> Users { get; set; }
        private VModels.User selectedUser;

        public VModels.User SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand AddUserCommand => new RelayCommand(_execute => AddUser());
        public RelayCommand EditUserCommand => new RelayCommand(_execute => UpdateUser());
        public RelayCommand DeleteUserCommand => new RelayCommand(_execute => DeleteUser());



        private List<User> GetUsers()
        {
            var list = _userService.GetAll();
            return list == null ? new List<User>() : list;
        }

        private List<VModels.User> Convert(List<User> users)
        {
            users = GetUsers();
            if (!users.Any()) return new List<VModels.User>();

            //Initialize Mapper/Dapper for cleaner code structure
            var VMUsers = users.Select(u => new VModels.User
            {
                Id = u.Id,
                Username = u.Username,
                CreatedDate = u.CreatedDate,
                CreatedDateString = u.CreatedDate.ToString("dd/MM/yyyy hh:mm"),
                CreatedByUserId = u.CreatedByUserId,
                CreatedByUser = _userService.GetById(u.CreatedByUserId).Username,
                ModifiedDate = u.ModifiedDate,
                ModifiedDateString = u.ModifiedDate.ToString("dd/MM/yyyy hh:mm"),
                ModifiedByUserId = u.ModifiedByUserId,
                ModifiedByUser = ""
            }).ToList();

            return VMUsers;
        }

        private void FillObservableCollection()
        {
            var dbUsers = GetUsers();
            var convertedUsers = Convert(dbUsers);
            Users = new ObservableCollection<VModels.User>(convertedUsers);
        }

        public void AddUser()
        {
            AddUserWindow addUpdateUserWindow = new AddUserWindow(_userService, _userRoleService);
            addUpdateUserWindow.ShowDialog();
        }

        public void UpdateUser()
        {
            if (SelectedUser != null)
            {
                AddUserWindow addUpdateUserWindow = new AddUserWindow(SelectedUser, _userRoleService);
                addUpdateUserWindow.ShowDialog();
                return;
            }
            MessageBox.Show("Niste označili nijednog korisnika", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        public void DeleteUser()
        {
            if (SelectedUser != null)
            {
                var result = MessageBox.Show("Da li ste sigurni da želite obrisati ovoga korisnika?", "Information", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    var dbUser = _userService.GetById(SelectedUser.Id);
                    var succesfullyDeleted = _userService.Delete(dbUser.Id);
                    if (succesfullyDeleted)
                    {
                        MessageBox.Show("Uspješno ste obrisali korisnika", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                        UsersWindow window = new UsersWindow();
                        window.DataContext = new UsersWindowViewModel(_userService, _userRoleService);
                        App.Current.Windows[0].Close();
                        window.Show();

                        return;
                    }
                    MessageBox.Show("Operacija neuspješna.Brisanje nije uspjelo", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

            }
            MessageBox.Show("Aplikacija nije u mogućnosti da izvrši zahtjev za brisanje!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
