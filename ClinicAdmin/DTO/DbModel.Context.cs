﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClinicAdmin.DTO
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ClinicAdminEntities : DbContext
    {
        public ClinicAdminEntities()
            : base("name=ClinicAdminEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Prescription> Prescriptions { get; set; }
        public virtual DbSet<Prescription_Medicine> Prescription_Medicine { get; set; }
        public virtual DbSet<Regulation> Regulations { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UnitMedicine> UnitMedicines { get; set; }
        public virtual DbSet<UsageMedicine> UsageMedicines { get; set; }
        public virtual DbSet<User> Users { get; set; }
    
        public virtual ObjectResult<usp_GetUser_Result> usp_GetUser(string uname)
        {
            var unameParameter = uname != null ?
                new ObjectParameter("uname", uname) :
                new ObjectParameter("uname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_GetUser_Result>("usp_GetUser", unameParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> usp_Login(string uname, string pass)
        {
            var unameParameter = uname != null ?
                new ObjectParameter("uname", uname) :
                new ObjectParameter("uname", typeof(string));
    
            var passParameter = pass != null ?
                new ObjectParameter("pass", pass) :
                new ObjectParameter("pass", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("usp_Login", unameParameter, passParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> usp_PatientInDay(Nullable<System.DateTime> day)
        {
            var dayParameter = day.HasValue ?
                new ObjectParameter("day", day) :
                new ObjectParameter("day", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("usp_PatientInDay", dayParameter);
        }
    
        public virtual ObjectResult<Nullable<double>> usp_ProfitInDay(Nullable<System.DateTime> day)
        {
            var dayParameter = day.HasValue ?
                new ObjectParameter("day", day) :
                new ObjectParameter("day", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<double>>("usp_ProfitInDay", dayParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> usp_SumPatient()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("usp_SumPatient");
        }
    
        public virtual ObjectResult<Nullable<double>> usp_SumProfit()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<double>>("usp_SumProfit");
        }
    }
}
