using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TheSearchApp.DataManager.Models;

namespace TheSearchApp.DataManager.Concreate
{
    public class SearchAppDBContext : DbContext
    {
        public SearchAppDBContext(DbContextOptions<SearchAppDBContext> options) : base(options)
        {

        }
        public DbSet<SearchHistory> SearchHistory { get; set; }
    }
}
