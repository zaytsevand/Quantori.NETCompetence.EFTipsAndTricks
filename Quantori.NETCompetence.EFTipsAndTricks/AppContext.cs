using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using Quantori.NETCompetence.EFTipsAndTricks.Models;

namespace Quantori.NETCompetence.EFTipsAndTricks
{
    public class AppContext: DbContext
    {
        public virtual DbSet<User> Users { get; set; } = null!;

        public AppContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var converter = new ValueConverter<DynamicData, string>(
                model => JsonConvert.SerializeObject(model),
                json => JsonConvert.DeserializeObject<DynamicData>(json)!);

            modelBuilder.Entity<User>()
                .Property(u => u.AddressData)
                .HasConversion(converter!);
        }
    }
}
