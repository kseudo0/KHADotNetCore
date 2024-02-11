using KHADotNetCore.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace KHADotNetCore.ConsoleApp.EFCoreExamples
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = "DESKTOP-V1H7OM6",
                InitialCatalog = "TestDb",
                UserID = "sa",
                Password = "KaungKaung",
                TrustServerCertificate = true
            };
            optionsBuilder.UseSqlServer(sqlConnectionStringBuilder.ConnectionString);
        }

        public DbSet<BlogModel> Blogs { get; set; }
    }
}