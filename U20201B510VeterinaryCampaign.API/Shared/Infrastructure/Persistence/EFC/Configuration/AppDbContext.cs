using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
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
      
      builder.Entity<Appointment>().HasKey(a => a.Id);
      builder.Entity<Appointment>().Property(a => a.Id).ValueGeneratedOnAdd();
      
      builder.Entity<Appointment>().Property(a => a.DoctorName).IsRequired().HasMaxLength(120);
      builder.Entity<Appointment>().Property(a => a.Email).IsRequired().HasMaxLength(120);
      builder.Entity<Appointment>().Property(a => a.PatientName).IsRequired().HasMaxLength(120);
      builder.Entity<Appointment>().Property(a => a.appointmentTime).IsRequired();
      builder.Entity<Appointment>().Property(a => a.appointmentDate).IsRequired();
      builder.Entity<Appointment>().Property(a => a.Specialty).IsRequired();
      
      
      //Regals de mapped object relational (ORM)
      builder.UseSnakeCaseNamingConvention();
   }
}