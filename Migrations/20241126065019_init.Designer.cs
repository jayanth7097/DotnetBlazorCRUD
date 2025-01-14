﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using dummy.Data;

#nullable disable

namespace dummy.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241126065019_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("dummy.Models.Students", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StudentId"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Specialty")
                        .HasColumnType("text");

                    b.HasKey("StudentId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            Name = "Dr. Smith",
                            Specialty = "Cardiology"
                        },
                        new
                        {
                            StudentId = 2,
                            Name = "Dr. Johnson",
                            Specialty = "Neurology"
                        });
                });

            modelBuilder.Entity("dummy.Models.Subjects", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SubjectId"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("Grade")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("StudentId")
                        .HasColumnType("integer");

                    b.HasKey("SubjectId");

                    b.HasIndex("StudentId");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            SubjectId = 1,
                            Age = 30,
                            Grade = "Flu",
                            Name = "John Doe",
                            StudentId = 1
                        },
                        new
                        {
                            SubjectId = 2,
                            Age = 25,
                            Grade = "Fracture",
                            Name = "Jane Roe",
                            StudentId = 2
                        });
                });

            modelBuilder.Entity("dummy.Models.Subjects", b =>
                {
                    b.HasOne("dummy.Models.Students", "Student")
                        .WithMany("Patients")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("dummy.Models.Students", b =>
                {
                    b.Navigation("Patients");
                });
#pragma warning restore 612, 618
        }
    }
}
