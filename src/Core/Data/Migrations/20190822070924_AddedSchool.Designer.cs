﻿// <auto-generated />
using System;
using Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190822070924_AddedSchool")]
    partial class AddedSchool
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Entities.BestFriend", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("LastUpdated")
                        .IsConcurrencyToken();

                    b.Property<Guid>("StudentId");

                    b.Property<Guid>("SurveyRecordId");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("SurveyRecordId");

                    b.ToTable("BestFriends");
                });

            modelBuilder.Entity("Core.Entities.School", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Domain");

                    b.Property<string>("Email");

                    b.Property<byte[]>("Image");

                    b.Property<DateTime>("LastUpdated")
                        .IsConcurrencyToken();

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("SchoolAdmins");
                });

            modelBuilder.Entity("Core.Entities.SchoolClass", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("LastUpdated")
                        .IsConcurrencyToken();

                    b.Property<string>("Name");

                    b.Property<Guid>("SchoolAdminId");

                    b.Property<Guid>("TecherId");

                    b.HasKey("Id");

                    b.HasIndex("SchoolAdminId");

                    b.HasIndex("TecherId")
                        .IsUnique();

                    b.ToTable("SchoolClasses");
                });

            modelBuilder.Entity("Core.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Email");

                    b.Property<string>("FullName");

                    b.Property<int>("Gender");

                    b.Property<DateTime>("LastUpdated")
                        .IsConcurrencyToken();

                    b.Property<Guid>("SchoolClassId");

                    b.HasKey("Id");

                    b.HasIndex("SchoolClassId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Core.Entities.Survey", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("LastUpdated")
                        .IsConcurrencyToken();

                    b.Property<string>("Name");

                    b.Property<Guid>("SchoolAdminId");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("SchoolAdminId");

                    b.ToTable("Surveys");
                });

            modelBuilder.Entity("Core.Entities.SurveyClass", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("LastUpdated")
                        .IsConcurrencyToken();

                    b.Property<Guid>("SchoolClassId");

                    b.Property<Guid>("SurveryId");

                    b.Property<Guid?>("SurveyId");

                    b.HasKey("Id");

                    b.HasIndex("SchoolClassId");

                    b.HasIndex("SurveyId");

                    b.ToTable("SurveyClasses");
                });

            modelBuilder.Entity("Core.Entities.SurveyRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("LastUpdated")
                        .IsConcurrencyToken();

                    b.Property<Guid>("StudentId");

                    b.Property<Guid>("SurveyClassId");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("SurveyClassId");

                    b.ToTable("SurveyRecords");
                });

            modelBuilder.Entity("Core.Entities.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Email");

                    b.Property<string>("FullName");

                    b.Property<Guid>("IdentityGuid");

                    b.Property<DateTime>("LastUpdated")
                        .IsConcurrencyToken();

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Core.Entities.BestFriend", b =>
                {
                    b.HasOne("Core.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Core.Entities.SurveyRecord", "SurveyRecord")
                        .WithMany("BestFriends")
                        .HasForeignKey("SurveyRecordId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Core.Entities.SchoolClass", b =>
                {
                    b.HasOne("Core.Entities.School", "SchoolAdmin")
                        .WithMany("SchoolClasses")
                        .HasForeignKey("SchoolAdminId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Core.Entities.Teacher", "Teacher")
                        .WithOne("SchoolClass")
                        .HasForeignKey("Core.Entities.SchoolClass", "TecherId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Core.Entities.Student", b =>
                {
                    b.HasOne("Core.Entities.SchoolClass", "SchoolClass")
                        .WithMany()
                        .HasForeignKey("SchoolClassId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Core.Entities.Survey", b =>
                {
                    b.HasOne("Core.Entities.School", "SchoolAdmin")
                        .WithMany("Surveys")
                        .HasForeignKey("SchoolAdminId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Core.Entities.SurveyClass", b =>
                {
                    b.HasOne("Core.Entities.SchoolClass", "SchoolClass")
                        .WithMany()
                        .HasForeignKey("SchoolClassId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Core.Entities.Survey", "Survey")
                        .WithMany("SurveyClasses")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Core.Entities.SurveyRecord", b =>
                {
                    b.HasOne("Core.Entities.Student", "Student")
                        .WithMany("SurveyRecords")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Core.Entities.SurveyClass", "SurveyClass")
                        .WithMany("SurveyRecords")
                        .HasForeignKey("SurveyClassId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
