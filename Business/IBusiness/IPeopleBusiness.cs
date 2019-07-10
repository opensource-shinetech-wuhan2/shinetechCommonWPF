using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Model;

namespace Business.IBusiness
{
    public interface IPeopleBusiness
    {
        PersonModel GetById (int id);
        List<PersonModel> GetAll ();
        PersonModel Add (PersonModel dto);
        PersonModel Update (PersonModel dto);

        void AddClient (int id,ClientModel clientDto);
    }
}
