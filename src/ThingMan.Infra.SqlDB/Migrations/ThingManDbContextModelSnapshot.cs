﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThingMan.Infra.SqlDB;

#nullable disable

namespace ThingMan.Infra.SqlDB.Migrations
{
    [DbContext(typeof(ThingManDbContext))]
    partial class ThingManDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("ThingMan.Domain.NotificationDef", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ThingDefId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ThingDefId");

                    b.ToTable("NotificationDef");
                });

            modelBuilder.Entity("ThingMan.Domain.PropertyDef", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("PropertyDef");
                });

            modelBuilder.Entity("ThingMan.Domain.StatusDef", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ThingDefId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ThingDefId");

                    b.ToTable("StatusDef");
                });

            modelBuilder.Entity("ThingMan.Domain.ThingDef", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PropertyDef1Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("PropertyDef2Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("PropertyDef3Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PropertyDef1Id");

                    b.HasIndex("PropertyDef2Id");

                    b.HasIndex("PropertyDef3Id");

                    b.ToTable("ThingDefs");
                });

            modelBuilder.Entity("ThingMan.Domain.NotificationDef", b =>
                {
                    b.HasOne("ThingMan.Domain.ThingDef", null)
                        .WithMany("NotificationDefs")
                        .HasForeignKey("ThingDefId");
                });

            modelBuilder.Entity("ThingMan.Domain.StatusDef", b =>
                {
                    b.HasOne("ThingMan.Domain.ThingDef", null)
                        .WithMany("StatusDefs")
                        .HasForeignKey("ThingDefId");
                });

            modelBuilder.Entity("ThingMan.Domain.ThingDef", b =>
                {
                    b.HasOne("ThingMan.Domain.PropertyDef", "PropertyDef1")
                        .WithMany()
                        .HasForeignKey("PropertyDef1Id");

                    b.HasOne("ThingMan.Domain.PropertyDef", "PropertyDef2")
                        .WithMany()
                        .HasForeignKey("PropertyDef2Id");

                    b.HasOne("ThingMan.Domain.PropertyDef", "PropertyDef3")
                        .WithMany()
                        .HasForeignKey("PropertyDef3Id");

                    b.Navigation("PropertyDef1");

                    b.Navigation("PropertyDef2");

                    b.Navigation("PropertyDef3");
                });

            modelBuilder.Entity("ThingMan.Domain.ThingDef", b =>
                {
                    b.Navigation("NotificationDefs");

                    b.Navigation("StatusDefs");
                });
#pragma warning restore 612, 618
        }
    }
}
