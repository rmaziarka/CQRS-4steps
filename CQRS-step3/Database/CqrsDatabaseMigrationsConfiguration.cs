using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace CQRS_step3.Database
{
    public class CqrsDatabaseMigrationsConfiguration : DbMigrationsConfiguration<CqrsDatabase>
    {
        public CqrsDatabaseMigrationsConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = "Database";
            MigrationsNamespace = "CQRS_step3.Database";
        }
    }
}