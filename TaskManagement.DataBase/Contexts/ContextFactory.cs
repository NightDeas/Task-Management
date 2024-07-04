using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.DataBase.Contexts
{
    public class ContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<Context>();
            //options.UseSqlServer("Data Source=DESKTOP-3VRB7GU;Inkitial Catalog=TaskManagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            //options.UseSqlServer("Data Source=DESKTOP-NM4JG25\\TEST;Initial Catalog=TaskManagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            options.UseSqlServer("Data Source=169.254.131.3;Initial Catalog=Burnasov_TaskManagement;User ID=stud;Password=Qwerty123456$;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            return new Context(options.Options);
        }
    }
}
