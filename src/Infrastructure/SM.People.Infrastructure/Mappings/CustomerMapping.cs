using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SM.People.Core.Domain.Entities;

namespace SM.People.Infrastructure.Mappings
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");

            builder.Property(c => c.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.LastName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.CellPhone)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(c => c.Birthday)
                .IsRequired();

            builder.OwnsOne(s => s.Email, em =>
            {
                em.Property(c => c.EmailAddress)
                .HasColumnName("Email")
                .HasMaxLength(100);
            });

            builder.OwnsOne(c => c.Address, cm =>
            {
                cm.Property(c => c.PublicPlace)
                .HasColumnName("PublicPlace")
                .HasMaxLength(100)
                .IsRequired();

                cm.Property(c => c.District)
                .HasColumnName("District")
                .HasMaxLength(60)
                .IsRequired();

                cm.Property(c => c.City)
                .HasColumnName("City")
                .HasMaxLength(60)
                .IsRequired();

                cm.Property(c => c.ZipCode)
                .HasColumnName("ZipCode")
                .HasMaxLength(13)
                .IsRequired();

                cm.Property(c => c.State)
                .HasColumnName("State")
                .HasMaxLength(2)
                .IsRequired();
            });
        }
    }
}
