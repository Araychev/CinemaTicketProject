﻿using CinemaTicket.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicket.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
    }
}