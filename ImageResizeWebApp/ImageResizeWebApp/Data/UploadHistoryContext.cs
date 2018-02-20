using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ImageResizeWebApp.Models;

namespace ImageResizeWebApp.Data
{
        public class UploadHistoryContext : DbContext
        {
            public UploadHistoryContext(DbContextOptions<UploadHistoryContext> options) : base(options)
            {
            }

            public DbSet<UploadHistory> UploadHistory { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UploadHistory>().ToTable("UploadHistory");
        }

    }
}

