using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.IBusiness;
using DataModel;
using Data.Access;
using Business.Model;

namespace Business
{
    public class ClientBusiness:IClientBusiness
    {
        private IMapper _mapper;
        private ClientAgent _clientAgent;
        public ClientBusiness (IMapper mapper)
        {
            _mapper = mapper;
            _clientAgent = new ClientAgent();
        }

        public ClientModel GetById (int id)
        {
            var client = _clientAgent.GetById(id);
            var clientDto = _mapper.Map<ClientModel>(client);
            return clientDto;
        }

        public List<ClientModel> GetAll ()
        {
            var client = _clientAgent.GetAll();
            var clients = _mapper.Map<List<ClientModel>>(client);
            return clients;
        }

        public ClientModel AddOrUpdate (ClientModel dto)
        {
            try
            {
                var entity = _mapper.Map<Client>(dto);
                var client = _clientAgent.AddOrUpdate(entity);
                var clientDto = _mapper.Map<ClientModel>(client);
                return clientDto;
            }
            catch(Exception ex)
            {

            }
            return null;
        }
    }
}
