using Click2Rent.Database;
using Click2Rent.Database.Services;
using Click2Rent.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    
    public static void Main(String[] args)
    {
        IServiceProvider _serviceProvider = CreateServiceProvider();
        var _context = _serviceProvider.GetRequiredService<Click2RentContext>();

        IBaseService<User> _userService = new BaseService<User>(_context);

        var list = _userService.GetAll();
        Console.WriteLine(":::BEFORE ADDING::");
        foreach (var item in list)
        {
            Console.WriteLine($"Item Id {item.Id} // Username {item.Username} // Created at {item.CreatedDate}");
        }

        _userService.Add(new User("Admir",1));
        _userService.Add(new User("Dijana", 1));
        _userService.Add(new User("Goku", 1));

        Console.WriteLine("\n:::AFTER ADDING::");
        list = _userService.GetAll();

        foreach (var item in list)
        {
            Console.WriteLine($"Item Id {item.Id} // Username {item.Username} // Created at {item.CreatedDate}");
        }

        var removed = _userService.Delete(2);

        Console.WriteLine("\n:::AFTER DELETING::");
        list = _userService.GetAll();

        foreach (var item in list)
        {
            Console.WriteLine($"Item Id {item.Id} // Username {item.Username} // Created at {item.CreatedDate}");
        }

        var updated = _userService.Update(3, new User("Sabrina The Witch", 1));
        Console.WriteLine("\n:::AFTER UPDATING::");

        list = _userService.GetAll();

        foreach (var item in list)
        {
            Console.WriteLine($"Item Id {item.Id} // Username {item.Username} // Created at {item.CreatedDate}");
        }

         IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            //Registering DB
            services.AddDbContext<Click2RentContext>(options =>
            {
                options.UseSqlServer("Server=.;Database=Click2RentDB;Trusted_Connection=True;TrustServerCertificate=True;");
            });

            return services.BuildServiceProvider();
        }
    }
}

