using Microsoft.EntityFrameworkCore;
using Api_Tour_Of_Heroes_Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api_Tour_Of_Heroes_Domain.Mappers
{
    public class HeroMapper : IEntityTypeConfiguration<Hero>
    {
        public void Configure(EntityTypeBuilder<Hero> builder)
        {
            builder.ToTable("Heroes");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsUnicode().ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasColumnType("VARCHAR(200)").IsRequired();
        }
    }
}
