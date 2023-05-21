using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SM.People.Core.Domain.Entities;

namespace SM.People.Infrastructure.Mappings
{
    public class SupplierMapping : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Supplier");

            builder.Property(c => c.CorporateName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.FantasyName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.NRLE)
                .HasMaxLength(20);

            builder.Property(c => c.StateRegistration)
                .HasMaxLength(100);

            builder.Property(c => c.CellPhone)
                .HasMaxLength(20);

            builder.OwnsOne(s => s.Email, em =>
            {
                em.Property(c => c.EmailAddress)
                .HasColumnName("Email");
            });

            builder.OwnsOne(c => c.Address, cm =>
            {
                cm.Property(c => c.PublicPlace)
                .HasColumnName("PublicPlace")
                .HasMaxLength(100);

                cm.Property(c => c.District)
                .HasColumnName("District")
                .HasMaxLength(60);

                cm.Property(c => c.City)
                .HasColumnName("City")
                .HasMaxLength(60);

                cm.Property(c => c.ZipCode)
                .HasColumnName("ZipCode")
                .HasMaxLength(13);

                cm.Property(c => c.State)
                .HasColumnName("State")
                .HasMaxLength(4);
            });
        }
    }
}
