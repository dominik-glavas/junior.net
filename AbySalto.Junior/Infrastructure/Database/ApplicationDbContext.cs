using AbySalto.Junior.Models.Articles;
using AbySalto.Junior.Models.Currencies;
using AbySalto.Junior.Models.OrderArticles;
using AbySalto.Junior.Models.Orders;
using Microsoft.EntityFrameworkCore;

namespace AbySalto.Junior.Infrastructure.Database
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            //Order

            modelBuilder.Entity<Order>()
                .HasKey(o => o.OrderId)
            ;

            modelBuilder.Entity<Order>()
                .Property(o => o.CustomerName)
                .HasMaxLength(50)
            ;

            modelBuilder.Entity<Order>()
                .Property(o => o.Address)
                .HasMaxLength(150)
            ;

            modelBuilder.Entity<Order>()
                .Property(o => o.PhoneNumber)
                .HasMaxLength(20)
            ;

            modelBuilder.Entity<Order>()
                .Property(o => o.Remark)
                .HasMaxLength(255)
            ;

            //Currency

            modelBuilder.Entity<Currency>()
                .HasKey(c => c.CurrencyId)
            ;

            modelBuilder.Entity<Currency>().HasData(
                new Currency { CurrencyId = 1, Code = "USD", Name = "US Dollar" },
                new Currency { CurrencyId = 2, Code = "EUR", Name = "Euro" },
                new Currency { CurrencyId = 3, Code = "JPY", Name = "Japanese Yen" }
            );

            //ExchangeRate

            modelBuilder.Entity<ExchangeRate>()
                .HasKey(er => er.ExchangeRateId)
            ;

            modelBuilder.Entity<ExchangeRate>()
                .HasOne(er => er.FromCurrency)
                .WithMany()
                .HasForeignKey(er => er.FromCurrencyId)
                .OnDelete(DeleteBehavior.Restrict)
            ;

            modelBuilder.Entity<ExchangeRate>()
                .HasOne(er => er.ToCurrency)
                .WithMany()
                .HasForeignKey(er => er.ToCurrencyId)
                .OnDelete(DeleteBehavior.Restrict)
            ;

            modelBuilder.Entity<ExchangeRate>().HasData(
                new ExchangeRate { ExchangeRateId = 1, FromCurrencyId = 1, ToCurrencyId = 2, Rate = 0.95m },
                new ExchangeRate { ExchangeRateId = 2, FromCurrencyId = 1, ToCurrencyId = 3, Rate = 110m },
                new ExchangeRate { ExchangeRateId = 3, FromCurrencyId = 2, ToCurrencyId = 1, Rate = 1.05m }
            );

            //Article

            modelBuilder.Entity<Article>()
                .HasKey(a => a.ArticleId)
                
            ;

            modelBuilder.Entity<Article>()
                .Property(a => a.Name)
                .HasMaxLength(50)
            ;

            modelBuilder.Entity<Article>().HasData(
                new Article { ArticleId = 1, Name = "Lasagna", Price = 10.99m, CurrencyId = 2 },
                new Article { ArticleId = 2, Name = "Beefsteak", Price = 35.19m, CurrencyId = 1 },
                new Article { ArticleId = 3, Name = "Pizza Margherita", Price = 1743m, CurrencyId = 3 },
                new Article { ArticleId = 4, Name = "Spaghetti Carbonara", Price = 2090m, CurrencyId = 3 },
                new Article { ArticleId = 5, Name = "Rumpsteak", Price = 35m, CurrencyId = 2 },
                new Article { ArticleId = 6, Name = "Goulash", Price = 10.55m, CurrencyId = 1 },
                new Article { ArticleId = 7, Name = "Meatballs", Price = 15.24m, CurrencyId = 1 }
            );

            //OrderArticle

            modelBuilder.Entity<OrderArticle>()
                .HasKey(oa => new { oa.OrderId, oa.ArticleId });

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderArticles)
                .WithOne(oa => oa.Order)
                .HasForeignKey(oa => oa.OrderId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Article>()
                .HasMany(a => a.OrderArticles)
                .WithOne(oa => oa.Article)
                .HasForeignKey(oa => oa.ArticleId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
