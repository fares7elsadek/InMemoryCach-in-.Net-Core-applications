using InMemoryCach.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InMemoryCach.Data.Config;

public class DriverConfigurations : IEntityTypeConfiguration<Driver>
{
    public void Configure(EntityTypeBuilder<Driver> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).
            HasDefaultValueSql("newid()");
    }
}
