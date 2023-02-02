using BackendData.DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BackendData.DataAccess.Config
{
    public class AddressConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(p => p.Street)
                 .IsRequired()
				 .HasMaxLength(ConfigConstants.DEFAULT_LENGTH);
            builder.Property(p => p.City)
                .IsRequired()
                .HasMaxLength(ConfigConstants.DEFAULT_LENGTH);
            builder.Property(p => p.Country)
                .IsRequired()
                .HasMaxLength(ConfigConstants.DEFAULT_LENGTH);
            builder.Property(p => p.HouseNumber)
                .IsRequired()
                .HasMaxLength(ConfigConstants.DEFAULT_LENGTH);
            builder.Property(p => p.ZipCode)
                .IsRequired()
                .HasMaxLength(ConfigConstants.DEFAULT_LENGTH);

            builder.HasData(SeedData.Addresses());

        }
    }
}
