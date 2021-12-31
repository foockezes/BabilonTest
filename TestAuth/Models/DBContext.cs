﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestAuth.Models;

namespace TestAuth.Models
{
    public class DBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userRoleName = "user";

            string adminEmail = "admin";
            string adminPassword = "admin";
            // добавляем роли
            Role adminRole = new() { Id = 1, Name = adminRoleName };
            Role userRole = new() { Id = 2, Name = userRoleName };
            User adminUser = new() { Id = Guid.NewGuid(), Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id};

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<TestAuth.Models.Client> Client { get; set; }
    }
}
