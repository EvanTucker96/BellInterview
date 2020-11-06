using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BellInterviewClient;

namespace BellInterviewServer.SQLServer.Context
{
    public class ServerAPIContext : DbContext
    {
        public ServerAPIContext(DbContextOptions<ServerAPIContext> options) : base(options)
        {

        }

        public DbSet<Client> Clients {get; set;}
    }
}
