using Click2Rent.Database.Services;
using Click2Rent.Domain;
using System.Collections.ObjectModel;
using VModels = Click2Rent.WPFClient.Models;

#pragma warning disable CS8618 

namespace Click2Rent.WPFClient.ViewModel
{
    public class UsersWindowViewModel
    {
        private readonly IBaseService<User> _userService;

        public UsersWindowViewModel(IBaseService<User> userService)
        {
            _userService = userService;
            FillObservableCollection();
        }

        public ObservableCollection<VModels.User> Users { get; set; }

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
    }
}
