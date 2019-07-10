using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Validators;

namespace Business.Model
{
    public class PersonModel :DataErrorInfoBase
    {
        public int Id { get; set; }

        private string _name;

        [Required,MinLength(4)]
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                SetValue("Name");
            }
        }

        private string _phone;
        [Required, Phone]
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                SetValue("Phone");
            }
        }

        private string _email;
        [Required, EmailAddress]
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                SetValue("Email");
            }
        }

        public virtual ICollection<ClientModel> Clients { get; set; }
    }
}
