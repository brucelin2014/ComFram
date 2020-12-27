// 2020-12-24, Bruce

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComFram
{
    public class PersonModel : IModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }

        public string IpAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public void CopyFrom(PersonModel model)
        {
            ID = model.ID;
            FirstName = model.FirstName;
            LastName = model.LastName;
            Email = model.Email;
            Gender = model.Gender;

            IpAddress = model.IpAddress;
            CreatedDate = model.CreatedDate;
            LastModifiedDate = model.LastModifiedDate;
        }

    }

}
