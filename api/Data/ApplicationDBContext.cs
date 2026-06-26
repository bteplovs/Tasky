using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {}
        
        public DbSet<TaskList> TaskLists { get; set; } = null!;
        public DbSet<UserTask> UserTasks { get; set; } = null!;

    }
}