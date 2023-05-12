﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThingMan.Domain.SqlDB;

#nullable disable

namespace ThingMan.Domain.SqlDB.Migrations
{
    [DbContext(typeof(ThingManDbContext))]
    [Migration("20230111015718_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("ThingMan.Domain.Aggregates.ThingDefs.PropDef", b =>
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

                    b.ToTable("PropDef");
                });

            modelBuilder.Entity("ThingMan.Domain.Aggregates.ThingDefs.ThingDef", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PropDef1Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("PropDef2Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("PropDef3Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PropDef1Id");

                    b.HasIndex("PropDef2Id");

                    b.HasIndex("PropDef3Id");

                    b.ToTable("ThingDefs");
                });

            modelBuilder.Entity("ThingMan.Domain.Aggregates.ThingDefs.ThingDef", b =>
                {
                    b.HasOne("ThingMan.Domain.Aggregates.ThingDefs.PropDef", "PropDef1")
                        .WithMany()
                        .HasForeignKey("PropDef1Id");

                    b.HasOne("ThingMan.Domain.Aggregates.ThingDefs.PropDef", "PropDef2")
                        .WithMany()
                        .HasForeignKey("PropDef2Id");

                    b.HasOne("ThingMan.Domain.Aggregates.ThingDefs.PropDef", "PropDef3")
                        .WithMany()
                        .HasForeignKey("PropDef3Id");

                    b.Navigation("PropDef1");

                    b.Navigation("PropDef2");

                    b.Navigation("PropDef3");
                });
#pragma warning restore 612, 618
        }
    }
}
