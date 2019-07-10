using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Model;

namespace Business.IBusiness
{
    public interface IClientBusiness
    {
        ClientModel GetById (int id);

        List<ClientModel> GetAll ();

        ClientModel AddOrUpdate (ClientModel dto);
    }
}
