using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using StoreFront.Models;

namespace StoreFront.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    partial class StoreFrontDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("StoreFront.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("Price");

                    b.HasKey("Id");

                    b.ToTable("products");
                });

            modelBuilder.Entity("StoreFront.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ProductId");

                    b.Property<int>("Rating");

                    b.Property<string>("Text");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("reviews");
                });
        }
    }
}
