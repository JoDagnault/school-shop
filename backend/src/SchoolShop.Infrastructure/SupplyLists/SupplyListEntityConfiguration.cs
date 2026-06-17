using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SchoolShop.Infrastructure.SupplyLists;

public sealed class SupplyListEntityConfiguration : IEntityTypeConfiguration<SupplyListEntity>
{
    public void Configure(EntityTypeBuilder<SupplyListEntity> builder)
    {
        builder.HasKey(supplyList => supplyList.Id);

        builder.Property(supplyList => supplyList.SchoolName)
            .IsRequired();

        builder.Property(supplyList => supplyList.Grade)
            .IsRequired();

        builder.Property(supplyList => supplyList.AcademicYearStart)
            .IsRequired();

        builder.HasIndex(supplyList => new
        {
            supplyList.SchoolName,
            supplyList.Grade,
            supplyList.AcademicYearStart
        })
            .IsUnique();

        builder.HasMany(supplyList => supplyList.Items)
            .WithOne()
            .HasForeignKey(item => item.SupplyListId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
