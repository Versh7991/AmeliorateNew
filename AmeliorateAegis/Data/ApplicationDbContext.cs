using AmeliorateAegis.Areas.Teacher.Data;
using AmeliorateAegis.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmeliorateAegis.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<LessonPlan> LessonPlans { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Pupil> Pupils { get; set; }
        public DbSet<Centre> Centres { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<Programme> Programmes { get; set; }
        public DbSet<ProgrammeCentre> ProgramCentre { get; set; }
        public DbSet<ProgrammeEnrollment> ProgramEnrollments { get; set; }
        public DbSet<ProgressReport> ProgressReports { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Regional> Regionals { get; set; }
        public DbSet<Financial> Financials { get; set; }
        public DbSet<Profile> Profiles { get; set; }

        public DbSet<Meeting> Meetings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
            modelBuilder.Seed();
        }
    }
}
