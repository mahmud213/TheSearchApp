// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheSearchApp.DataManager.Concreate;

namespace TheSearchApp.DataManager.Migrations
{
    [DbContext(typeof(SearchAppDBContext))]
    partial class SearchAppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TheSearchApp.DataManager.Models.SearchHistory", b =>
                {
                    b.Property<long>("SearchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SearchId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("APIRequest")
                        .HasColumnName("APIRequest");

                    b.Property<string>("APIResponse")
                        .HasColumnName("APIResponse");

                    b.Property<DateTime?>("RequestDate")
                        .HasColumnName("RequestDate");

                    b.Property<string>("SearchCategory")
                        .HasColumnName("SearchCategory")
                        .HasMaxLength(50);

                    b.Property<string>("SearchCriteria")
                        .HasColumnName("SearchCriteria")
                        .HasMaxLength(500);

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnName("UserId")
                        .HasMaxLength(50);

                    b.HasKey("SearchId");

                    b.ToTable("SearchHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
