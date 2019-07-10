using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using DataModel;

namespace Data.Access
{
    public class ClientAgent
    {
        public Client GetById (int id)
        {
            using(var context = new TestEntities())
            {
                var client = context.Clients.Include(p => p.Person).FirstOrDefault(p => p.Id == id);
                return client;
            }
        }

        public List<Client> GetAll ()
        {
            using(var context = new TestEntities())
            {
                var clients = context.Clients.ToList();
                return clients;
            }
        }

        public Client AddOrUpdate (Client client)
        {
            using(var context = new TestEntities())
            {
                context.Clients.AddOrUpdate(client);
                int count = context.SaveChanges();
                return client;
            }
        }
    }
}
