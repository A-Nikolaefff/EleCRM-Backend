using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations;

public class RequestConfiguration : IEntityTypeConfiguration<Request>
{
    public void Configure(EntityTypeBuilder<Request> builder)
    {
        builder.ToTable("request");
        builder.Property(r => r.Id).HasColumnName("id");
        builder.Property(r => r.Number).HasColumnName("number");
        builder.Property(r => r.ReceiptDate).HasColumnName("receipt_date");
        builder.Property(r => r.Note).HasColumnName("note");

        builder.HasKey(a => a.Id);
    }
}