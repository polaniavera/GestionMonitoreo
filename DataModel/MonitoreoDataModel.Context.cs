﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class MonitoreoDbEntities : DbContext
    {
        public MonitoreoDbEntities()
            : base("name=MonitoreoDbEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Documento> Documento { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Registro> Registro { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Estaciones> Estaciones { get; set; }
        public DbSet<Grupo> Grupo { get; set; }
        public DbSet<Conductor> Conductor { get; set; }
    
        public virtual ObjectResult<getMaximaLectura_Result> getMaximaLectura(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("idUsuario", idUsuario) :
                new ObjectParameter("idUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getMaximaLectura_Result>("getMaximaLectura", idUsuarioParameter);
        }
    }
}
