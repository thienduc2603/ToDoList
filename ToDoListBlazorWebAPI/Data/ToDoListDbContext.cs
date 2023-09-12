using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using ToDoListBlazorWebAPI.Entities;

namespace ToDoListBlazorWebAPI.Data
{
    public class ToDoListDbContext : IdentityDbContext<User, Role, Guid>
    {
        public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options) : base(options)
        {
        }

        public DbSet<Task> Tasks { set; get; }
    }
}
