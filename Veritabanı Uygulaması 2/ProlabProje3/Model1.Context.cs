﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProlabProje3
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class KocaeliUniversitesiDBEntities : DbContext
    {
        public KocaeliUniversitesiDBEntities()
            : base("name=KocaeliUniversitesiDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<AcedemicMember> AcedemicMembers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<StudentLesson> StudentLessons { get; set; }
    
        public virtual ObjectResult<AlinanDersler_Result> AlinanDersler(string number)
        {
            var numberParameter = number != null ?
                new ObjectParameter("Number", number) :
                new ObjectParameter("Number", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AlinanDersler_Result>("AlinanDersler", numberParameter);
        }
    
        public virtual ObjectResult<AlinanDersleriGetir_Result> AlinanDersleriGetir(string number)
        {
            var numberParameter = number != null ?
                new ObjectParameter("Number", number) :
                new ObjectParameter("Number", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AlinanDersleriGetir_Result>("AlinanDersleriGetir", numberParameter);
        }
    
        public virtual ObjectResult<VizeFinal_Result> VizeFinal(string number, string lessonname)
        {
            var numberParameter = number != null ?
                new ObjectParameter("Number", number) :
                new ObjectParameter("Number", typeof(string));
    
            var lessonnameParameter = lessonname != null ?
                new ObjectParameter("lessonname", lessonname) :
                new ObjectParameter("lessonname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<VizeFinal_Result>("VizeFinal", numberParameter, lessonnameParameter);
        }
    
        public virtual ObjectResult<VizeFinalGetir_Result> VizeFinalGetir(string number, string lessonname)
        {
            var numberParameter = number != null ?
                new ObjectParameter("Number", number) :
                new ObjectParameter("Number", typeof(string));
    
            var lessonnameParameter = lessonname != null ?
                new ObjectParameter("lessonname", lessonname) :
                new ObjectParameter("lessonname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<VizeFinalGetir_Result>("VizeFinalGetir", numberParameter, lessonnameParameter);
        }
    }
}
