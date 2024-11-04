using Click2Rent.Database.Services;
using Click2Rent.Domain;
using Click2Rent.WPFClient.ViewModel;
using System.Windows;
using VModels = Click2Rent.WPFClient.Models;

namespace Click2Rent.WPFClient.Views
{
    public partial class AddUserWindow : Window
    {
        public VModels.User LoggedUser { get; set; } = new VModels.User("Admin", 1);

        private readonly IBaseService<User> _userService;
        private readonly IBaseService<UserRole> _userRoleService;

        public AddUserWindow(IBaseService<User> userService, IBaseService<UserRole> userRoleService)
        {
            InitializeComponent();
            _userService = userService;
            _userRoleService = userRoleService;
            DataContext = new AddUserWindowViewModel(LoggedUser, _userService,_userRoleService);
        }
    }
}
