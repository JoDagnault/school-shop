using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SchoolShop.Infrastructure;

#nullable disable

namespace SchoolShop.Infrastructure.Migrations;

[DbContext(typeof(SchoolShopDbContext))]
[Migration("20260619153022_InitialCreate")]
partial class InitialCreate
{
    /// <inheritdoc />
    protected override void BuildTargetModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder
            .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
            .HasAnnotation("ProductVersion", "10.0.9")
            .HasAnnotation("Relational:MaxIdentifierLength", 63);

        modelBuilder.Entity("SchoolShop.Infrastructure.SupplyLists.SupplyListEntity", builder =>
        {
            builder.Property<Guid>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("uuid")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);

            builder.Property<uint>("AcademicYearStart")
                .HasColumnType("bigint")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);

            builder.Property<string>("Grade")
                .IsRequired()
                .HasColumnType("text")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);

            builder.Property<string>("SchoolName")
                .IsRequired()
                .HasColumnType("text")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);

            builder.HasKey("Id");

            builder.HasIndex("SchoolName", "Grade", "AcademicYearStart")
                .IsUnique();

            builder.ToTable("SupplyLists");
        });

        modelBuilder.Entity("SchoolShop.Infrastructure.SupplyLists.SupplyListItemEntity", builder =>
        {
            builder.Property<Guid>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("uuid")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);

            builder.Property<string>("Name")
                .IsRequired()
                .HasColumnType("text")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);

            builder.Property<uint>("Quantity")
                .HasColumnType("bigint")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);

            builder.Property<Guid>("SupplyListId")
                .HasColumnType("uuid")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);

            builder.HasKey("Id");

            builder.HasIndex("SupplyListId");

            builder.ToTable("SupplyListItemEntity");
        });

        modelBuilder.Entity("SchoolShop.Infrastructure.SupplyLists.SupplyListItemEntity", builder =>
        {
            builder.HasOne("SchoolShop.Infrastructure.SupplyLists.SupplyListEntity", null)
                .WithMany("Items")
                .HasForeignKey("SupplyListId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        });
#pragma warning restore 612, 618
    }
}
