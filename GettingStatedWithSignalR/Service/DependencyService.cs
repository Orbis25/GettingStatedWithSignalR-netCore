using GettingStatedWithSignalR.Hubs;
using GettingStatedWithSignalR.Models;
using GettingStatedWithSignalR.Models.context;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GettingStatedWithSignalR.Service
{
    public interface IDependencyService
    {
        void Config();
        bool AddPerson(Person model);
        IEnumerable<Person> GetAll(); 
    }

    public class DependencyService : IDependencyService
    {
        private readonly IConfiguration _configuration;
        private readonly IHubContext<NotificationHub> _hub;
        private readonly AppDb _context;

        public DependencyService(IConfiguration configuration, IHubContext<NotificationHub> hub , AppDb context)
        {
            _configuration = configuration;
            _hub = hub;
            _context = context;
        }

        public bool AddPerson(Person model)
        {
            _context.Add(model);
            return _context.SaveChanges() > 0;
        }

        public void Config()
        {
            Subscribe();
        }

        public IEnumerable<Person> GetAll() => _context.Persons.ToList();
        private void Subscribe()
        {
            string conn = _configuration.GetConnectionString("DefaultConnection");
            using(var com = new SqlConnection(conn))
            {
                com.Open();

                using (var cmd = new SqlCommand(@"SELECT Id,Name FROM [dbo].Persons", com))
                {
                    cmd.Notification = null;
                    SqlDependency dependency = new SqlDependency(cmd);
                    dependency.OnChange += (sender , e) => {
                        Task.Run(async () => await _hub.Clients.All.SendAsync("Notify"));
                        Console.WriteLine("se disparo " + e.Type);
                        Subscribe();
                    };
                    SqlDependency.Start(conn);
                    cmd.ExecuteReader();
                }


            }
        }
    }
}
