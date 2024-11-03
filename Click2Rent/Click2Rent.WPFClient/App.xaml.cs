using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using Click2Rent.Database.Services;
using Click2Rent.Domain;
using Click2Rent.WPFClient.Views;
using Click2Rent.WPFClient.ViewModel;
using Click2Rent.Database;
using Microsoft.EntityFrameworkCore;

namespace Click2Rent.WPFClient
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider _serviceProvider = CreateServiceProvider();

            Window window = new UsersWindow();
            IBaseService<User> _userService = _serviceProvider.GetRequiredService<IBaseService<User>>();
            window.DataContext = new UsersWindowViewModel(_userService);
            window.Show();

            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            //Registering DB
            services.AddDbContext<Click2RentContext>(options =>
            {
                options.UseSqlServer("Server=.;Database=Click2RentDB;Trusted_Connection=True;TrustServerCertificate=True;");
            });

            //Registering services
            services.AddTransient<IBaseService<User>, BaseService<User>>();

            services.AddScoped<UsersWindowViewModel>();

            return services.BuildServiceProvider();
        }
    }


}
