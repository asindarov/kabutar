using Kabutar.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kabutar.Server.Infrastructure.DbContextConfigurations;

public class TopicConfiguration : IEntityTypeConfiguration<Topic>
{
    public void Configure(EntityTypeBuilder<Topic> builder)
    {
        builder.ToTable("topics");

        builder.HasOne(t => t.Server)
            .WithMany(s => s.Topics)
            .HasForeignKey(t => t.ServerId)
            .IsRequired();
    }
}
