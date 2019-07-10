using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Data.Entity;
using DataModel;

namespace Data.Access
{
    public class PeopleAgent
    {
        public Person GetById (int id)
        {
            using(var context = new TestEntities())
            {
                var people = context.People.Include(p=>p.Clients).FirstOrDefault(p=>p.Id == id);
                return people;
            }            
        }

        public List<Person> GetAll ()
        {
            using(var context = new TestEntities())
            {
                var people = context.People.ToList();
                return people;
            }
        }

        public Person AddOrUpdate (Person person)
        {
            using(var context = new TestEntities())
            {
                context.People.AddOrUpdate(person);
                int count = context.SaveChanges();
                return person;
            }
        }

        public void Update (int id,Client client)
        {
            using(var context = new TestEntities())
            {
                var person = context.People.Include(p=>p.Clients).FirstOrDefault(p => p.Id == id);
                if(person != null)
                {
                    person.Clients.Add(client);
                }
                int count = context.SaveChanges();
            }
        }
    }
}
