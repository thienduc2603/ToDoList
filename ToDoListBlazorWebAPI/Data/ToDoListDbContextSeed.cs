using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using ToDoListBlazorWebAPI.Entities;
using ToDoListBlazorWebAPI.Enums;
using Task = System.Threading.Tasks.Task;

namespace ToDoListBlazorWebAPI.Data
{
    public class ToDoListDbContextSeed
    {
        private readonly IPasswordHasher<User> passwordHasher = new PasswordHasher<User>(); 

        public async Task SeedAsync(ToDoListDbContext context, ILogger<ToDoListDbContextSeed> logger)
        {
            if (!context.Users.Any())
            {
                var user = new User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Duc",
                    LastName = "Le",
                    Email = "admin@gmail.com",
                    PhoneNumber = "0768898662",
                    UserName = "admin",
                };
                user.PasswordHash = passwordHasher.HashPassword(user, "Admin@123");
                context.Users.Add(user);
            }

            if (!context.Tasks.Any())
            {
                context.Tasks.Add(new Entities.Task()
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Same tasks 1",
                    CreatedDate = DateTime.Now,
                    Priority = Priority.High,
                    Status = Status.Open
                });
            }

            await context.SaveChangesAsync();
        }
    }
}
