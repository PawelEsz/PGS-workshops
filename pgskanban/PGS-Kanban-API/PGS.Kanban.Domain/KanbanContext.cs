using Microsoft.EntityFrameworkCore;
using PGS.Kanban.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PGS.Kanban.Domain
{
    public class KanbanContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PgsKanban;Trusted_Connection=True;");
        }

        //virtual stostuje sie do mockowania
        public DbSet<Board> Boards { get; set; }

        public DbSet<List> Lists { get; set; }
    }

}
