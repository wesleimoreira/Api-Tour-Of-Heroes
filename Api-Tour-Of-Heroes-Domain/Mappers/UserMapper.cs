using Microsoft.EntityFrameworkCore;
using Api_Tour_Of_Heroes_Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api_Tour_Of_Heroes_Domain.Mappers
{
    public class UserMapper : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsUnicode().ValueGeneratedOnAdd();
            builder.Property(x => x.Role).HasColumnType("VARCHAR(20)").IsRequired();
            builder.Property(x => x.Password).HasColumnType("VARCHAR(10)").IsRequired();
            builder.Property(x => x.UserName).HasColumnType("VARCHAR(200)").IsRequired();
        }
    }
}
