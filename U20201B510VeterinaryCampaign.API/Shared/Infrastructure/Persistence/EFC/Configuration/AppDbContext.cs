using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using U20201B510VeterinaryCampaign.API.CRM.Domain.Model.Aggregate;
using U20201B510VeterinaryCampaign.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace U20201B510VeterinaryCampaign.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
   protected override void OnConfiguring(DbContextOptionsBuilder builder)
   {
      //Para campos de auditor (CreatedDate, UpdatedDate)
      builder.AddCreatedUpdatedInterceptor();
      base.OnConfiguring(builder);
   }
   
   protected override void OnModelCreating(ModelBuilder builder)
   {
      base.OnModelCreating(builder);
      
      //=================================================================================================
      //||                                    CONFIGURATION OF THE TABLES                              ||                              
      //=================================================================================================
      
      //=================================================================================================
      //===================================== 1. GONZALO BOUNDED CONTEXT ================================
      //---------------- CONFIGURATION BY SOLUTION ----------------
      //id (int, 
      //   obligatorio, autogenerado, llave primaria), VeterinaryCampaignManagerId(string, obligatorio, 
      //   autogenerado, Guid único), firstName (string, obligatorio, entre 4 y 40 caracteres), lastName 
      //   (string, obligatorio, entre 4 y 40 caracteres), status (int, obligatorio, restringido por 
      //EManagerStatus), assignedSalesAgentId (int, no obligatorio), contactedAt (Date, no 
      //obligatorio), approvedAt (Date, no obligatorio), reportedAt (Date, no obligatorio) . 
      
      builder.Entity<Manager>().HasKey(a => a.Id);
      builder.Entity<Manager>().Property(a => a.Id).ValueGeneratedOnAdd();
      
      builder.Entity<Manager>().Property(a => a.VeterinaryCampaignManagerId).IsRequired().HasMaxLength(120);
      builder.Entity<Manager>().Property(a => a.FirstName).IsRequired().HasMaxLength(40);
      builder.Entity<Manager>().Property(a => a.LastName).IsRequired().HasMaxLength(40);
      builder.Entity<Manager>().Property(a => a.Status).IsRequired();
      builder.Entity<Manager>().Property(a => a.AssignedSalesAgentId);
      builder.Entity<Manager>().Property(a => a.ContactedAt);
      builder.Entity<Manager>().Property(a => a.ApprovedAt);
      builder.Entity<Manager>().Property(a => a.ReportedAt);
      
      //Regals de mapped object relational (ORM)
      builder.UseSnakeCaseNamingConvention();
   }
}