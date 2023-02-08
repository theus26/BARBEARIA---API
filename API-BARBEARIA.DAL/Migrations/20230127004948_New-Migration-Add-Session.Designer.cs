﻿// <auto-generated />
using System;
using API_BARBEARIA.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_BARBEARIA.DAL.Migrations
{
    [DbContext(typeof(BarbeariaContext))]
    [Migration("20230127004948_New-Migration-Add-Session")]
    partial class NewMigrationAddSession
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("API_BARBEARIA.DAL.Entities.Barber", b =>
                {
                    b.Property<long>("IdBarber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("IdSchedulling")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdBarber");

                    b.HasIndex("IdSchedulling");

                    b.ToTable("barber");
                });

            modelBuilder.Entity("API_BARBEARIA.DAL.Entities.Scheduling", b =>
                {
                    b.Property<long>("IdSchedulling")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Barber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DesiredService")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("HairCurtDate")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("IdUser")
                        .HasColumnType("bigint");

                    b.Property<bool>("SchedulingCompleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdSchedulling");

                    b.HasIndex("IdUser");

                    b.ToTable("scheduling");
                });

            modelBuilder.Entity("API_BARBEARIA.DAL.Entities.Sessions", b =>
                {
                    b.Property<long>("IdSession")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("IdUser")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("LoginDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("LogoutDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("SessionFinalized")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdSession");

                    b.HasIndex("IdUser");

                    b.ToTable("Session");
                });

            modelBuilder.Entity("API_BARBEARIA.DAL.Entities.User", b =>
                {
                    b.Property<long>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<bool>("BarberAdmin")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdUser");

                    b.HasIndex("CPF")
                        .IsUnique();

                    b.ToTable("user");
                });

            modelBuilder.Entity("API_BARBEARIA.DAL.Entities.Barber", b =>
                {
                    b.HasOne("API_BARBEARIA.DAL.Entities.Scheduling", "scheduling")
                        .WithMany()
                        .HasForeignKey("IdSchedulling")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("scheduling");
                });

            modelBuilder.Entity("API_BARBEARIA.DAL.Entities.Scheduling", b =>
                {
                    b.HasOne("API_BARBEARIA.DAL.Entities.User", "user")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("API_BARBEARIA.DAL.Entities.Sessions", b =>
                {
                    b.HasOne("API_BARBEARIA.DAL.Entities.User", "user")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });
#pragma warning restore 612, 618
        }
    }
}