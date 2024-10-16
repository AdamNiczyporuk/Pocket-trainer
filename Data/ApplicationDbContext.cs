using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KCK_Project__Console_Pocket_trainer_.Models;
using System.Reflection.Emit;

namespace KCK_Project__Console_Pocket_trainer_.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TrainingPlan> TreningPlans { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseToTrainingPlan> ExercisesToTrainingPlans { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<ExerciseDone> ExercisesDone { get; set; }
        public DbSet<Diet> Diets { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TP_DB;Trusted_Connection=True;");
        }
    }
}
