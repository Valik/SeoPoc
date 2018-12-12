using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.AspNet.Identity.EntityFramework;

using SeoPoc.Web.Models;

namespace SeoPoc.Web.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}