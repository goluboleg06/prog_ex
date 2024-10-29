using Microsoft.EntityFrameworkCore;

public class CurrencyContext : DbContext
{
    public DbSet<CurrencyRate> CurrencyRates { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("name=Data Source=ACER\\SQLEXPRESS;Initial Catalog=CurrencyDB;Integrated Security=True;Trust Server Certificate=True");
    }
}
