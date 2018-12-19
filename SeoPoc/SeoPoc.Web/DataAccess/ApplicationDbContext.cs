using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

using Microsoft.AspNet.Identity.EntityFramework;

using SeoPoc.Web.DataAccess.Entities;
using SeoPoc.Web.Migrations;
using SeoPoc.Web.Models;

namespace SeoPoc.Web.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer<ApplicationDbContext>(new NullDatabaseInitializer<ApplicationDbContext>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<DbCity>();
            modelBuilder.Entity<DbDistrict>();

            modelBuilder.Entity<DbCitySeoParameter>();
            modelBuilder.Entity<DbDistrictSeoParameter>();
            modelBuilder.Entity<DbArticleGroupSeoParameter>();
            modelBuilder.Entity<DbAliasSeoParameter>();
            modelBuilder.Entity<DbPhraseSeoParameter>();
        }
    }
}