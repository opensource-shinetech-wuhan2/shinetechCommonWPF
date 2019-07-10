using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using Business.Model;
using Business.IBusiness;
using DataModel;
using Data.Access;

namespace Business
{
    public class PeopleBusiness :IPeopleBusiness
    {
        private IMapper _mapper;
        private PeopleAgent _peopleAgent;
        private ClientAgent _clientAgent;
        public PeopleBusiness (IMapper mapper)
        {
            _mapper = mapper;
            _peopleAgent = new PeopleAgent();
            _clientAgent = new ClientAgent();
        }

        public PersonModel GetById (int id)
        {
            var person = _peopleAgent.GetById(id);
            var personDto = _mapper.Map<PersonModel>(person);
            return personDto;
        }

        public List<PersonModel> GetAll ()
        {
            var people = _peopleAgent.GetAll();
            var persons = _mapper.Map<List<PersonModel>>(people);
            return persons;
        }

        public PersonModel Add (PersonModel dto)
        {
            try
            {
                var entity = _mapper.Map<Person>(dto);
                var person = _peopleAgent.AddOrUpdate(entity);
                var personDto = _mapper.Map<PersonModel>(person);
                return personDto;
            }
            catch(Exception ex)
            {

            }
            return null;
        }

        public PersonModel Update (PersonModel dto)
        {
            try
            {
                using(var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var entity = _mapper.Map<Person>(dto);
                    var person = _peopleAgent.AddOrUpdate(entity);

                    foreach(var client in dto.Clients)
                    {
                        var clientEntity = _mapper.Map<Client>(client);
                        if(clientEntity.PersonId == person.Id) continue;

                        clientEntity.Id = 0;
                        clientEntity.PersonId = person.Id;
                        _clientAgent.AddOrUpdate(clientEntity);
                    }

                    var personDto = _mapper.Map<PersonModel>(person);

                    scope.Complete();
                    return personDto;
                }
            }
            catch(Exception ex)
            {

            }
            return null;
        }

        public void AddClient (int id,ClientModel clientDto)
        {
            try
            {
                var client = _mapper.Map<Client>(clientDto);
                _peopleAgent.Update(id,client);
            }
            catch(Exception ex)
            {

            }
        }
    }

   
}
