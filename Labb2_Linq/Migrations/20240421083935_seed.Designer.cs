﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Labb2_Linq.Migrations
{
    [DbContext(typeof(Labb2Context))]
    [Migration("20240421083935_seed")]
    partial class seed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CourseKlass", b =>
                {
                    b.Property<int>("ClassesKlassId")
                        .HasColumnType("int");

                    b.Property<int>("CoursesCourseId")
                        .HasColumnType("int");

                    b.HasKey("ClassesKlassId", "CoursesCourseId");

                    b.HasIndex("CoursesCourseId");

                    b.ToTable("CourseKlass");

                    b.HasData(
                        new
                        {
                            ClassesKlassId = 1,
                            CoursesCourseId = 1
                        },
                        new
                        {
                            ClassesKlassId = 1,
                            CoursesCourseId = 4
                        },
                        new
                        {
                            ClassesKlassId = 2,
                            CoursesCourseId = 2
                        },
                        new
                        {
                            ClassesKlassId = 3,
                            CoursesCourseId = 3
                        },
                        new
                        {
                            ClassesKlassId = 3,
                            CoursesCourseId = 2
                        },
                        new
                        {
                            ClassesKlassId = 4,
                            CoursesCourseId = 1
                        },
                        new
                        {
                            ClassesKlassId = 4,
                            CoursesCourseId = 4
                        });
                });

            modelBuilder.Entity("CourseTeacher", b =>
                {
                    b.Property<int>("CoursesCourseId")
                        .HasColumnType("int");

                    b.Property<int>("TeachersTeacherId")
                        .HasColumnType("int");

                    b.HasKey("CoursesCourseId", "TeachersTeacherId");

                    b.HasIndex("TeachersTeacherId");

                    b.ToTable("CourseTeacher");

                    b.HasData(
                        new
                        {
                            CoursesCourseId = 1,
                            TeachersTeacherId = 1
                        },
                        new
                        {
                            CoursesCourseId = 2,
                            TeachersTeacherId = 2
                        },
                        new
                        {
                            CoursesCourseId = 3,
                            TeachersTeacherId = 3
                        },
                        new
                        {
                            CoursesCourseId = 4,
                            TeachersTeacherId = 4
                        });
                });

            modelBuilder.Entity("Labb2_Linq.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseId");

                    b.ToTable("Course");

                    b.HasData(
                        new
                        {
                            CourseId = 1,
                            Name = "Programmering 1"
                        },
                        new
                        {
                            CourseId = 2,
                            Name = "Programmering 2"
                        },
                        new
                        {
                            CourseId = 3,
                            Name = "Svenska"
                        },
                        new
                        {
                            CourseId = 4,
                            Name = "Engelska"
                        });
                });

            modelBuilder.Entity("Labb2_Linq.Models.Klass", b =>
                {
                    b.Property<int>("KlassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KlassId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KlassId");

                    b.ToTable("Klass");

                    b.HasData(
                        new
                        {
                            KlassId = 1,
                            Name = "A1"
                        },
                        new
                        {
                            KlassId = 2,
                            Name = "A2"
                        },
                        new
                        {
                            KlassId = 3,
                            Name = "B1"
                        },
                        new
                        {
                            KlassId = 4,
                            Name = "B2"
                        });
                });

            modelBuilder.Entity("Labb2_Linq.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KlassId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.HasIndex("KlassId");

                    b.ToTable("Student");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            FirstName = "Anders",
                            KlassId = 1,
                            LastName = "And"
                        },
                        new
                        {
                            StudentId = 2,
                            FirstName = "Bosse",
                            KlassId = 2,
                            LastName = "Basker"
                        },
                        new
                        {
                            StudentId = 3,
                            FirstName = "Bengt",
                            KlassId = 4,
                            LastName = "Basker"
                        },
                        new
                        {
                            StudentId = 4,
                            FirstName = "Daniel",
                            KlassId = 3,
                            LastName = "Danielsson"
                        });
                });

            modelBuilder.Entity("Labb2_Linq.Models.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeacherId");

                    b.ToTable("Teacher");

                    b.HasData(
                        new
                        {
                            TeacherId = 1,
                            FirstName = "Reidar",
                            LastName = "Nilsen"
                        },
                        new
                        {
                            TeacherId = 2,
                            FirstName = "Tobias",
                            LastName = "Landén"
                        },
                        new
                        {
                            TeacherId = 3,
                            FirstName = "Adam",
                            LastName = "Adamsson"
                        },
                        new
                        {
                            TeacherId = 4,
                            FirstName = "Bertil",
                            LastName = "Bok"
                        });
                });

            modelBuilder.Entity("CourseKlass", b =>
                {
                    b.HasOne("Labb2_Linq.Models.Klass", null)
                        .WithMany()
                        .HasForeignKey("ClassesKlassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labb2_Linq.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CourseTeacher", b =>
                {
                    b.HasOne("Labb2_Linq.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labb2_Linq.Models.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeachersTeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Labb2_Linq.Models.Student", b =>
                {
                    b.HasOne("Labb2_Linq.Models.Klass", "Klass")
                        .WithMany("Students")
                        .HasForeignKey("KlassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Klass");
                });

            modelBuilder.Entity("Labb2_Linq.Models.Klass", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
