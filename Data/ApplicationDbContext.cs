using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SzParag.Models;

namespace SzParag.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SzParag.Models.Unit> Unit { get; set; }
        public DbSet<SzParag.Models.Producer> Producer { get; set; }
        public DbSet<SzParag.Models.Category1> Category1 { get; set; }
        public DbSet<SzParag.Models.Category2> Category2 { get; set; }
        public DbSet<SzParag.Models.Category3> Category3 { get; set; }
        public DbSet<SzParag.Models.Product> Product { get; set; }
    }
}
