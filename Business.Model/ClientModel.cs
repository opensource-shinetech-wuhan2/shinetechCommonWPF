using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Model
{
    public class ClientModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> PersonId { get; set; }
        public virtual ICollection<PersonModel> People { get; set; }
    }
}
