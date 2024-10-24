using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stroia_Alexia_Lab2.Models;

namespace Stroia_Alexia_Lab2.Data
{
    public class Stroia_Alexia_Lab2Context : DbContext
    {
        public Stroia_Alexia_Lab2Context (DbContextOptions<Stroia_Alexia_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Stroia_Alexia_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Stroia_Alexia_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Stroia_Alexia_Lab2.Models.Author> Author { get; set; } = default!;
        public DbSet<Stroia_Alexia_Lab2.Models.Category> Category { get; set; } = default!;
        public DbSet<Stroia_Alexia_Lab2.Models.BookCategory> BookCategory { get; set; } = default!;
    }
}
