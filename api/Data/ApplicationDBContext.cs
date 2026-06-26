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

        public DbSet<Board> Boards {get; set; }
        public DbSet<BoardColumn> BoardColumns { get; set; } = null!;
        public DbSet<TaskItem> TaskItems { get; set; } = null!;

    }
}