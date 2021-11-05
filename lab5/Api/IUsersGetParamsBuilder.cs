using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public interface IUsersGetParamsBuilder
    {
        public void SetStatus();
        public void SetPhoto();
        public void SetLastSeen();
        public UsersGetParams GetProduct();
    }
}
