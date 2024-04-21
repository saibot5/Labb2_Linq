using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Labb2_Linq.Models;

public class Labb2Context : DbContext
{
    public Labb2Context(DbContextOptions<Labb2Context> options)
        : base(options)
    {
    }

    public DbSet<Labb2_Linq.Models.Course> Course { get; set; } = default!;

    public DbSet<Labb2_Linq.Models.Klass> Klass { get; set; } = default!;

    public DbSet<Labb2_Linq.Models.Student> Student { get; set; } = default!;

    public DbSet<Labb2_Linq.Models.Teacher> Teacher { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var CourseKlass = modelBuilder.Entity("CourseKlass");
        var CourseTeacher = modelBuilder.Entity("CourseTeacher");

        //Seed klasser
        modelBuilder.Entity<Klass>().HasData(
            new Klass { KlassId = 1, Name = "A1" },
            new Klass { KlassId = 2, Name = "A2" },
            new Klass { KlassId = 3, Name = "B1" },
            new Klass { KlassId = 4, Name = "B2" }
            );

        //seed Courses
        modelBuilder.Entity<Course>().HasData(
            new Course { CourseId = 1, Name = "Programmering 1" },
            new Course { CourseId = 2, Name = "Programmering 2" },
            new Course { CourseId = 3, Name = "Svenska" },
            new Course { CourseId = 4, Name = "Engelska" }
            );

        //Seed Relation 
        CourseKlass.HasData(
            new { ClassesKlassId = 1, CoursesCourseId = 1 },
            new { ClassesKlassId = 1, CoursesCourseId = 4 },
            new { ClassesKlassId = 2, CoursesCourseId = 2 },
            new { ClassesKlassId = 3, CoursesCourseId = 3 },
            new { ClassesKlassId = 3, CoursesCourseId = 2 },
            new { ClassesKlassId = 4, CoursesCourseId = 1 },
            new { ClassesKlassId = 4, CoursesCourseId = 4 }
            );

        //Seed Teachers
        modelBuilder.Entity<Teacher>().HasData(
            new Teacher { TeacherId = 1, FirstName = "Reidar", LastName = "Nilsen" },
            new Teacher { TeacherId = 2, FirstName = "Tobias", LastName = "Landén" },
            new Teacher { TeacherId = 3, FirstName = "Adam", LastName = "Adamsson" },
            new Teacher { TeacherId = 4, FirstName = "Bertil", LastName = "Bok" }
            );
        //Seed Relation
        CourseTeacher.HasData(
            new { CoursesCourseId = 1, TeachersTeacherId = 1 },
            new { CoursesCourseId = 2, TeachersTeacherId = 2 },
            new { CoursesCourseId = 3, TeachersTeacherId = 3 },
            new { CoursesCourseId = 4, TeachersTeacherId = 4 }
            );

        //Seed Students
        modelBuilder.Entity<Student>().HasData(
            new Student { StudentId = 1, FirstName = "Anders", LastName = "And", KlassId = 1 },
            new Student { StudentId = 2, FirstName = "Bosse", LastName = "Basker", KlassId = 2 },
            new Student { StudentId = 3, FirstName = "Bengt", LastName = "Basker", KlassId = 4 },
            new Student { StudentId = 4, FirstName = "Daniel", LastName = "Danielsson", KlassId = 3 }

            );




    }


}
