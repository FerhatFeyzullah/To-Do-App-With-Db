﻿using Microsoft.EntityFrameworkCore;
using ToDoAppWithDb.Models;

namespace ToDoAppWithDb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
    }
}
