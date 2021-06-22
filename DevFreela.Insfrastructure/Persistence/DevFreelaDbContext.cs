using DevFreela.Core.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Insfrastructure.Persistence
{
    public class DevFreelaDbContext : DbContext
    {
        public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options) : base(options)
        {

        }

        public DbSet<Project> Projects { get; private set; }
        public DbSet<User> Users { get; private set; }
        public DbSet<Skill> Skills { get; private set; }
        public DbSet<ProjectComment> ProjectComment { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasKey(p => p.Id);


            modelBuilder.Entity<Project>()
                .HasOne(p => p.Freelancer)
                .WithMany(f => f.FreelanceProjects)
                .HasForeignKey(p => p.IdFreelancer)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Project>()
              .HasOne(p => p.Client)
              .WithMany(c => c.OwnerProjects)
              .HasForeignKey(p => p.IdClient)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjectComment>()
                .HasKey(p => p.Id);



            modelBuilder.Entity<ProjectComment>()
                .HasOne(c => c.Project)
                .WithMany(p => p.ProjectComments)
                .HasForeignKey(c => c.IdProject);

            modelBuilder.Entity<ProjectComment>()
               .HasOne(c => c.User)
               .WithMany(u => u.ProjectComments)
               .HasForeignKey(c => c.IdUser);

            modelBuilder.Entity<Skill>()
               .HasKey(p => p.Id);

            modelBuilder.Entity<User>()
               .HasKey(p => p.Id);


            modelBuilder.Entity<User>()
                .HasMany(u => u.UserSkills)
                .WithOne()
                .HasForeignKey(u => u.IdSkill)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserSkill>()
               .HasKey(p => p.Id);
        }
    }
}
