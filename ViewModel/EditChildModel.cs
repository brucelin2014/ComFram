using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComFram
{
    public class EditChildModel : Screen, IEditChildModel
    {
        public void Close()
        {
            TryClose();
        }
    }
}
