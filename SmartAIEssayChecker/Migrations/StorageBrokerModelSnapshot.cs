﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartAIEssayChecker.Brokers.Storages;

#nullable disable

namespace SmartAIEssayChecker.Migrations
{
    [DbContext(typeof(StorageBroker))]
    partial class StorageBrokerModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("SmartAIEssayChecker.Models.Essays.Essay", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Essays");
                });

            modelBuilder.Entity("SmartAIEssayChecker.Models.Feedbacks.Feedback", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("EssayId")
                        .HasColumnType("TEXT");

                    b.Property<float>("Mark")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("EssayId")
                        .IsUnique();

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("SmartAIEssayChecker.Models.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SmartAIEssayChecker.Models.Essays.Essay", b =>
                {
                    b.HasOne("SmartAIEssayChecker.Models.Users.User", "User")
                        .WithMany("Essays")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmartAIEssayChecker.Models.Feedbacks.Feedback", b =>
                {
                    b.HasOne("SmartAIEssayChecker.Models.Essays.Essay", "Essay")
                        .WithOne("Feedback")
                        .HasForeignKey("SmartAIEssayChecker.Models.Feedbacks.Feedback", "EssayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Essay");
                });

            modelBuilder.Entity("SmartAIEssayChecker.Models.Essays.Essay", b =>
                {
                    b.Navigation("Feedback")
                        .IsRequired();
                });

            modelBuilder.Entity("SmartAIEssayChecker.Models.Users.User", b =>
                {
                    b.Navigation("Essays");
                });
#pragma warning restore 612, 618
        }
    }
}
