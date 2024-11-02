using Click2Rent.Database;
using Click2Rent.Database.Services;
using Click2Rent.Domain;
using System.Collections.Generic;

public class Program
{
    public static void Main(String[] args)
    {
        IBaseService<User> _userService = new BaseService<User>(new Click2RentDbFactory());
        var list = _userService.GetAll().Where(e => e.IsDeleted == true || e.IsDeleted == false).ToList();
        Console.WriteLine(":::BEFORE ADDING::");
        foreach (var item in list)
        {
            Console.WriteLine($"Item Id {item.Id} // Username {item.Username} // Created at {item.CreatedDate}");
        }

        _userService.Add(new User("Admir"));
        _userService.Add(new User("Dijana"));

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

        var updated = _userService.Update(3, new User("Sabrina The Witch"));
        Console.WriteLine("\n:::AFTER UPDATING::");

        list = _userService.GetAll();

        foreach (var item in list)
        {
            Console.WriteLine($"Item Id {item.Id} // Username {item.Username} // Created at {item.CreatedDate}");
        }
    }
}

