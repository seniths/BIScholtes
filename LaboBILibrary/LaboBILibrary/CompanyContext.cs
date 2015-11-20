using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboBILibrary
{
    public class CompanyContext : DbContext
    {
        //IG3B2 pwUserdb60

        public DbSet<Customer> Customers { get; set; }

        public CompanyContext():base(@"Data Source=vm-sql.iesn.be\stu3ig;Persist Security Info=True;User ID=IG3B2;Password=pwUserdb60;Initial Catalog=DBIG3B2")
        {

        }
    }
}
