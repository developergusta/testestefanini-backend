

using Microsoft.EntityFrameworkCore;


namespace Stefanini_API.Repository
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false);
            IConfiguration configuration = builder.Build();
            string connString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cidade>().ToTable("Cidade");
            modelBuilder.Entity<Pessoa>().ToTable("Pessoa");


            modelBuilder.Entity<Pessoa>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Pessoa>()
                .HasOne(p => p.Cidade)
                .WithMany(p => p.Pessoas)
                .HasForeignKey("IdCidade");
            modelBuilder.Entity<Pessoa>()
                .Property(p => p.Nome)
                .HasColumnType("varchar(300)");
            modelBuilder.Entity<Pessoa>()
                .Property(p => p.Cpf)
                .HasColumnType("varchar(11)");

        }
    }
}
