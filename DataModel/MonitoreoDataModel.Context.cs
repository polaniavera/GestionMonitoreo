﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MonitoreoDBEntities : DbContext
    {
        public MonitoreoDBEntities() : base("name=MonitoreoDBEntities")
        {
            base.Configuration.LazyLoadingEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Documento> Documento { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Registro> Registro { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
