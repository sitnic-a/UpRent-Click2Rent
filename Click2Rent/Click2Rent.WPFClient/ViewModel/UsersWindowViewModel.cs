using Click2Rent.Database.Services;
using Click2Rent.Domain;
using Click2Rent.WPFClient.Views;
using System.Collections.ObjectModel;
using VModels = Click2Rent.WPFClient.Models;

#pragma warning disable CS8618 

namespace Click2Rent.WPFClient.ViewModel
{
    public class UsersWindowViewModel
    {
        private readonly IBaseService<User> _userService;
        private readonly IBaseService<UserRole> _userRoleService;
        private VModels.User LoggedUser = new VModels.User("Admin", 1);

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
        public UsersWindowViewModel SelectedUser { get; set; }

        public RelayCommand AddUserCommand => new RelayCommand(_execute => AddUser());
        public RelayCommand DeleteUserCommand => new RelayCommand(_execute => DeleteUser(), _canExecute => SelectedUser != null);



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
            AddUserWindow userPage = new AddUserWindow(_userService,_userRoleService);
            userPage.ShowDialog();
        }

        public void DeleteUser()
        {
            return;
        }
    }
}
