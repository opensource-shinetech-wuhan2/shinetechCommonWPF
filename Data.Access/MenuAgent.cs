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
    public class MenuAgent
    {
        public async Task<List<Menu>> GetAll ()
        {
            using(var context = new TestEntities())
            {
                var menu = await context.Menus.OrderBy(x=>x.type).ToListAsync();
                return menu;
            }
        }

        public async Task<Menu> AddOrUpdate (Menu menu)
        {
            using(var context = new TestEntities())
            {
                context.Menus.AddOrUpdate(menu);
                int count = await context.SaveChangesAsync();
                return menu;
            }
        }

        public async Task<bool> Delete (int id)
        {
            using(var context = new TestEntities())
            {
                var item = context.Menus.FirstOrDefault(x => x.id == id);
                if(item != null)
                {
                    context.Menus.Remove(item);
                    var count = await context.SaveChangesAsync();
                    return count == 1;
                }
                return false;
            }
        }
    }
}
