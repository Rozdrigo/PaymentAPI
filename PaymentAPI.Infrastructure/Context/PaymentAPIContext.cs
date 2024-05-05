using Microsoft.EntityFrameworkCore;
using PaymentAPI.Domain.Models;

namespace PaymentAPI.Infrastructure.Context
{
    public class PaymentAPIContext : DbContext
    {
        public PaymentAPIContext(DbContextOptions<PaymentAPIContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
            builder.Entity<User>()
                .HasIndex(u => u.CPF)
                .IsUnique();
            builder.Entity<Account>()
                .HasIndex(a => a.Owner)
                .IsUnique();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Payment> Payments { get; set; }

    }
}
