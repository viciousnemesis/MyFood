﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyFood.Models;

namespace MyFood.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyFood.Models.Food", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(36)")
                        .HasMaxLength(36);

                    b.Property<decimal>("Carb")
                        .HasColumnType("decimal(18,6)");

                    b.Property<decimal>("Fat")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<decimal>("Protein")
                        .HasColumnType("decimal(18,6)");

                    b.Property<decimal>("ServingSize")
                        .HasColumnType("decimal(18,6)");

                    b.HasKey("Id");

                    b.ToTable("Foods");
                });
#pragma warning restore 612, 618
        }
    }
}
