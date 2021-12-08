using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace lab6.Models
{
    public class FootballClubDBContext : DbContext
    {
        public FootballClubDBContext(DbContextOptions<FootballClubDBContext> options): base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Footballer> Footballers { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
    }
}
