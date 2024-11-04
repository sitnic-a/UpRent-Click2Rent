using Click2Rent.Database.Services;
using Click2Rent.Domain;
using Click2Rent.WPFClient.ViewModel;
using System.Windows;
using System.Windows.Forms;
using VModels = Click2Rent.WPFClient.Models;

namespace Click2Rent.WPFClient.Views
{
    public partial class AddUserWindow : Window
    {
        private readonly IBaseService<User> _userService;
        private readonly IBaseService<UserRole> _userRoleService;

        public VModels.User LoggedUser { get; set; } = new VModels.User("Admin", 1);

        public AddUserWindow(IBaseService<User> userService, IBaseService<UserRole> userRoleService)
        {
            InitializeComponent();
            _userService = userService;
            _userRoleService = userRoleService;
            DataContext = new AddUserWindowViewModel(LoggedUser, _userService,_userRoleService);
        }

        public AddUserWindow(VModels.User selectedUser, IBaseService<UserRole> userRoleService)
        {
            InitializeComponent();
            _userRoleService = userRoleService;
            DataContext = new AddUserWindowViewModel(selectedUser, _userRoleService);
        }

        //Ne radi ni ovaj pristup za konstantnu provjeru Validnosti podataka i mogucnost disable dugmeta
        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindowViewModel vm = new AddUserWindowViewModel();
            vm.IsValid();
        }
    }
}
