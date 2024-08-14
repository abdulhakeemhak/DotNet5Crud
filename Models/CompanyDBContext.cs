using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using static DotNet5Crud.Models.UserModel;

#nullable disable

namespace DotNet5Crud.Models
{
    public partial class CompanyDBContext : DbContext
    {
        public CompanyDBContext(DbContextOptions<CompanyDBContext> options)
            : base(options)
        {
        }
        //public DbSet<LoginViewModel> LoginViews { get; set; }
        public  DbSet<UserModel> Users { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        //public virtual DbSet<Religion> Religions { get; set; }
        public DbSet<Religion> Religions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
