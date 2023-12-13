using Kabutar.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kabutar.Server.Infrastructure.DbContextConfigurations;

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.ToTable("messages");

        builder.HasKey(m => m.OffSet);

        builder.Property(m => m.OffSet)
            .UseSerialColumn();

        builder.HasOne(m => m.Topic)
            .WithMany(t => t.Messages)
            .HasForeignKey(m => m.TopicId)
            .IsRequired();
    }
}