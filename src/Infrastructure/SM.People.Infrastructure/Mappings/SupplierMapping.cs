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
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(c => c.StateRegistration)
                .HasMaxLength(100);

            builder.Property(c => c.CellPhone)
                .HasMaxLength(20)
                .IsRequired();

            builder.OwnsOne(s => s.Email, em =>
            {
                em.Property(c => c.EmailAddress)
                .HasMaxLength(100);
            });

            builder.OwnsOne(c => c.Address, cm =>
            {
                cm.Property(c => c.PublicPlace)
                .HasMaxLength(100)
                .IsRequired();

                cm.Property(c => c.District)
                .HasMaxLength(60)
                .IsRequired();

                cm.Property(c => c.City)
                .HasMaxLength(60)
                .IsRequired();

                cm.Property(c => c.ZipCode)
                .HasMaxLength(13) //66.820-000
                .IsRequired();

                cm.Property(c => c.State)
                .HasMaxLength(2)
                .IsRequired();
            });
        }
    }
}
