using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public class DB : DbContext
    {

        private static DB instance;
        public static DB Instance { get { return instance ??= new DB(); } }

        public DB()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
            List<Student> a = new List<Student> { new Student { FIO = "Dustin Spence", Address = "756-5839 Neque Rd.", Birthday = "(2025,07,10", IsBoy = false }, new Student { FIO = "Joan Travis", Address = "491-5632 Magna. Rd.", Birthday = "2024,12,10", IsBoy = true }, new Student { FIO = "Dustin Alexander", Address = "278-7536 Ac, St.", Birthday = "2024,01,07", IsBoy = true }, new Student { FIO = "Quon Contreras", Address = "P.O. Box 744, 5164 Adipiscing Road", Birthday = "2025,08,15", IsBoy = true }, new Student { FIO = "Arsenio Ingram", Address = "P.O. Box 306, 1527 Magna Avenue", Birthday = "2025, 09, 16", IsBoy = false } };
            Students.AddRange(a);
            var fist = Students.ToList();
            Users.Add(new User() { Id = 1, Login = "123", Password = "123" });
        }
    
        public DbSet<Student> Students { get; set; } 
        public DbSet<Group> Groups { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("test");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
