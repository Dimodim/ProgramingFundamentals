﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TeisterMask.Models;

namespace TeisterMask.Data
{
    public class TeisterMaksDbContext:DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        private const string ConnectionString = @"Server=.\SQLEXPRESS;Database=TeisterMaskDbContext;Integrated Security=True;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
