using Click2Rent.Database.Services;
using Click2Rent.Domain;
using VModels = Click2Rent.WPFClient.Models;

namespace Click2Rent.WPFClient.ViewModel
{
    public class AddUserWindowViewModel
    {
        private readonly IBaseService<User> _userService;
        private readonly IBaseService<UserRole> _userRoleService;

        public string Username { get; set; } = string.Empty;
        public List<int> Roles { get; set; }

        public bool UserRoleId { get; set; }
        public bool AdminRoleId { get; set; }
        public bool IzvjestajiRoleId { get; set; }

        public VModels.User LoggedUser { get; set; }
        public AddUserWindowViewModel() { }
        public AddUserWindowViewModel(VModels.User loggedUser, IBaseService<User> userService, IBaseService<UserRole> userRoleService)
        {
            LoggedUser = loggedUser;
            _userService = userService;
            _userRoleService = userRoleService;
        }
    }
}
