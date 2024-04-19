using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Labb2_Linq.Models;

    public class Labb2Context : DbContext
    {
        public Labb2Context (DbContextOptions<Labb2Context> options)
            : base(options)
        {
        }

        public DbSet<Labb2_Linq.Models.Course> Course { get; set; } = default!;

public DbSet<Labb2_Linq.Models.Klass> Klass { get; set; } = default!;

public DbSet<Labb2_Linq.Models.Student> Student { get; set; } = default!;

public DbSet<Labb2_Linq.Models.Teacher> Teacher { get; set; } = default!;
    }
