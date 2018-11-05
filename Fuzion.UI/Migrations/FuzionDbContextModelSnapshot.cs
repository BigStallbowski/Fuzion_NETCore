﻿// <auto-generated />
using System;
using Fuzion.UI.Core.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fuzion.UI.Migrations
{
    [DbContext(typeof(FuzionDbContext))]
    partial class FuzionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Fuzion.UI.Core.Models.AssignmentHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Body")
                        .HasMaxLength(1055);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<int?>("HardwareId");

                    b.Property<string>("LastModifiedBy");

                    b.Property<DateTime?>("LastModifiedOn");

                    b.HasKey("Id");

                    b.HasIndex("HardwareId");

                    b.ToTable("AssignmentHistory");
                });

            modelBuilder.Entity("Fuzion.UI.Core.Models.Hardware", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AssetNumber")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.Property<string>("AssignedTo")
                        .HasMaxLength(55);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<int?>("HardwareTypeId")
                        .IsRequired();

                    b.Property<byte>("IsAssigned")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue((byte)0);

                    b.Property<byte>("IsRetired")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue((byte)0);

                    b.Property<string>("LastModifiedBy");

                    b.Property<DateTime?>("LastModifiedOn");

                    b.Property<int?>("ManufacturerId")
                        .IsRequired();

                    b.Property<int?>("ModelId")
                        .IsRequired();

                    b.Property<int?>("OSId");

                    b.Property<int?>("PurposeId");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.HasIndex("AssetNumber")
                        .IsUnique();

                    b.HasIndex("HardwareTypeId");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("ModelId");

                    b.HasIndex("OSId");

                    b.HasIndex("PurposeId");

                    b.ToTable("Hardware");
                });

            modelBuilder.Entity("Fuzion.UI.Core.Models.HardwareType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<string>("LastModifiedBy");

                    b.Property<DateTime?>("LastModifiedOn");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("HardwareTypes");
                });

            modelBuilder.Entity("Fuzion.UI.Core.Models.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<string>("LastModifiedBy");

                    b.Property<DateTime?>("LastModifiedOn");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(55);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("Fuzion.UI.Core.Models.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<string>("LastModifiedBy");

                    b.Property<DateTime?>("LastModifiedOn");

                    b.Property<int?>("ManufacturerId")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(55);

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Models");
                });

            modelBuilder.Entity("Fuzion.UI.Core.Models.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasMaxLength(1055);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<int?>("HardwareId");

                    b.Property<string>("LastModifiedBy");

                    b.Property<DateTime?>("LastModifiedOn");

                    b.HasKey("Id");

                    b.HasIndex("HardwareId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("Fuzion.UI.Core.Models.OS", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<string>("LastModifiedBy");

                    b.Property<DateTime?>("LastModifiedOn");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(55);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("OS");
                });

            modelBuilder.Entity("Fuzion.UI.Core.Models.Purpose", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<string>("LastModifiedBy");

                    b.Property<DateTime?>("LastModifiedOn");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(55);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Purposes");
                });

            modelBuilder.Entity("Fuzion.UI.Core.Models.AssignmentHistory", b =>
                {
                    b.HasOne("Fuzion.UI.Core.Models.Hardware", "Hardware")
                        .WithMany("AssignmentHistory")
                        .HasForeignKey("HardwareId");
                });

            modelBuilder.Entity("Fuzion.UI.Core.Models.Hardware", b =>
                {
                    b.HasOne("Fuzion.UI.Core.Models.HardwareType", "HardwareType")
                        .WithMany("Hardware")
                        .HasForeignKey("HardwareTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fuzion.UI.Core.Models.Manufacturer", "Manufacturer")
                        .WithMany("Hardware")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fuzion.UI.Core.Models.Model", "Model")
                        .WithMany("Hardware")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fuzion.UI.Core.Models.OS", "OS")
                        .WithMany("Hardware")
                        .HasForeignKey("OSId");

                    b.HasOne("Fuzion.UI.Core.Models.Purpose", "Purpose")
                        .WithMany("Hardware")
                        .HasForeignKey("PurposeId");
                });

            modelBuilder.Entity("Fuzion.UI.Core.Models.Model", b =>
                {
                    b.HasOne("Fuzion.UI.Core.Models.Manufacturer", "Manufacturer")
                        .WithMany("Models")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fuzion.UI.Core.Models.Note", b =>
                {
                    b.HasOne("Fuzion.UI.Core.Models.Hardware", "Hardware")
                        .WithMany("Notes")
                        .HasForeignKey("HardwareId");
                });
#pragma warning restore 612, 618
        }
    }
}
