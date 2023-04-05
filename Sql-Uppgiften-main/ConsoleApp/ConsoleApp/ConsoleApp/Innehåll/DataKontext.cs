using ConsoleApp.Moduler.Enheter;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Innehåll;

internal class DataKontext : DbContext
{
    public DataKontext()
    {
    }

    public DataKontext(DbContextOptions<DataKontext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\erjon\OneDrive\Skrivbord\ConsoleApp\ConsoleApp\ConsoleApp\Innehåll\local-sql-db.mdf;Integrated Security=True;Connect Timeout=30");
    }

    public DbSet<StatusEntity> Statuses { get; set; }
    public DbSet<AnvändareEntity> Users { get; set; }
    public DbSet<ÄrendeEntity> Cases { get; set; }
    public DbSet<KommentarEntity> Kommentarer { get; set; }

}
