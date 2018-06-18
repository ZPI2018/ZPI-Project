﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using ServerAspNetCore.Domain.DAL;

namespace ServerAspNetCore.Migrations
{
    [DbContext(typeof(ZpiDbContext))]
    [Migration("20180516134607_IntialMigration")]
    partial class IntialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ZPIFrontEnd.Domain.Entities.Access", b =>
                {
                    b.Property<int>("IdUser");

                    b.Property<int>("IdCourse");

                    b.Property<bool>("IsOwner");

                    b.HasKey("IdUser", "IdCourse");

                    b.HasIndex("IdCourse");

                    b.ToTable("Accesses");
                });

            modelBuilder.Entity("ZPIFrontEnd.Domain.Entities.AccessCode", b =>
                {
                    b.Property<int>("IdCode")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdCourse");

                    b.Property<int>("Key");

                    b.HasKey("IdCode");

                    b.HasIndex("IdCourse");

                    b.ToTable("AccessCodes");
                });

            modelBuilder.Entity("ZPIFrontEnd.Domain.Entities.Category", b =>
                {
                    b.Property<int>("IdCategory")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("IdCategory");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ZPIFrontEnd.Domain.Entities.Course", b =>
                {
                    b.Property<int>("IdCourse")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<int>("IdCategory");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("IdCourse");

                    b.HasIndex("IdCategory");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("ZPIFrontEnd.Domain.Entities.CourseTag", b =>
                {
                    b.Property<int>("IdCourse");

                    b.Property<int>("IdTag");

                    b.HasKey("IdCourse", "IdTag");

                    b.HasIndex("IdTag");

                    b.ToTable("CourseTags");
                });

            modelBuilder.Entity("ZPIFrontEnd.Domain.Entities.Raiting", b =>
                {
                    b.Property<int>("IdUser");

                    b.Property<int>("IdCourse");

                    b.Property<string>("Comment")
                        .HasMaxLength(200);

                    b.Property<int>("Value");

                    b.HasKey("IdUser", "IdCourse");

                    b.HasIndex("IdCourse");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("ZPIFrontEnd.Domain.Entities.Tag", b =>
                {
                    b.Property<int>("IdTag")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("IdTag");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("ZPIFrontEnd.Domain.Entities.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("IdUser");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ZPIFrontEnd.Domain.Entities.Video", b =>
                {
                    b.Property<int>("IdVideo")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Directory")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("IdCourse");

                    b.Property<int?>("Order");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("IdVideo");

                    b.HasIndex("IdCourse");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("ZPIFrontEnd.Domain.Entities.Access", b =>
                {
                    b.HasOne("ZPIFrontEnd.Domain.Entities.Course", "Course")
                        .WithMany()
                        .HasForeignKey("IdCourse")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ZPIFrontEnd.Domain.Entities.User", "User")
                        .WithMany("Accesses")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ZPIFrontEnd.Domain.Entities.AccessCode", b =>
                {
                    b.HasOne("ZPIFrontEnd.Domain.Entities.Course", "Course")
                        .WithMany()
                        .HasForeignKey("IdCourse")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ZPIFrontEnd.Domain.Entities.Course", b =>
                {
                    b.HasOne("ZPIFrontEnd.Domain.Entities.Category", "Category")
                        .WithMany("Courses")
                        .HasForeignKey("IdCategory")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ZPIFrontEnd.Domain.Entities.CourseTag", b =>
                {
                    b.HasOne("ZPIFrontEnd.Domain.Entities.Course", "Course")
                        .WithMany()
                        .HasForeignKey("IdCourse")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ZPIFrontEnd.Domain.Entities.Tag", "Tag")
                        .WithMany("CoursesTag")
                        .HasForeignKey("IdTag")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ZPIFrontEnd.Domain.Entities.Raiting", b =>
                {
                    b.HasOne("ZPIFrontEnd.Domain.Entities.Course", "Course")
                        .WithMany()
                        .HasForeignKey("IdCourse")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ZPIFrontEnd.Domain.Entities.User", "User")
                        .WithMany("Raitings")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ZPIFrontEnd.Domain.Entities.Video", b =>
                {
                    b.HasOne("ZPIFrontEnd.Domain.Entities.Course", "Course")
                        .WithMany()
                        .HasForeignKey("IdCourse")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
