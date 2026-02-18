using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Metaldle.Infrastructure.Metalbands;
using System.Linq;
//rules for data entities when convertion class to tables
namespace Metaldle.Infrastructure.Metalbands.Configurations;

public class MetalbandConfiguration : IEntityTypeConfiguration<Metalband>
{
    public void Configure(EntityTypeBuilder<Metalband> builder)
    {
        builder.HasKey(b => b.Id);
        builder.HasIndex(b => b.Name).IsUnique();
        builder.Property(b => b.Name).IsRequired().HasMaxLength(100);
        builder.Property(b => b.ListAttribute1)
            .HasConversion(
                v => string.Join(",", v),
                v => v.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList()
            );
        builder.Property(b => b.ListAttribute2)
            .HasConversion(
                v => string.Join(",", v),
                v => v.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList()
            );
        builder.Property(b => b.ListAttribute3)
            .HasConversion(
                v => string.Join(",", v),
                v => v.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList()
            );
        
    }
}