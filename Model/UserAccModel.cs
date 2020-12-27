// 2020-12-27, Bruce

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComFram
{
    public class UserAccModel : IModel
    {
        public int ID { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public void CopyFrom(UserAccModel model)
        {
            ID = model.ID;
            UserCode = model.UserCode;
            UserName = model.UserName;
            Password = model.Password;

            CreatedDate = model.CreatedDate;
            LastModifiedDate = model.LastModifiedDate;
        }

    }

}
