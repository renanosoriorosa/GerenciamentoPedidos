using GP.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace GP.Data.Context
{
    public class GPContext : DbContext
    {
        public GPContext(DbContextOptions<GPContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seta por default o tamanho maximo de um campo string 
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(200)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GPContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Produto> Produto { get; set; }
        public DbSet<Estoque> Estoque { get; set; }
        public DbSet<Recebimento> Recebimento { get; set; }
    }
}
