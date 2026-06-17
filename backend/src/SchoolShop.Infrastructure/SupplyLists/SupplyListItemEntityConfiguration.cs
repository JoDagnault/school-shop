using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SchoolShop.Infrastructure.SupplyLists;

public sealed class SupplyListItemEntityConfiguration : IEntityTypeConfiguration<SupplyListItemEntity>
{
    public void Configure(EntityTypeBuilder<SupplyListItemEntity> builder)
    {
        builder.HasKey(item => item.Id);

        builder.Property(item => item.SupplyListId)
            .IsRequired();

        builder.Property(item => item.Name)
            .IsRequired();

        builder.Property(item => item.Quantity)
            .IsRequired();
    }
}
