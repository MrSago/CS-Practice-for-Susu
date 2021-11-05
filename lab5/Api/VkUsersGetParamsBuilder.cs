using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public class VkUsersGetParamsBuilder : IUsersGetParamsBuilder
    {
        private UsersGetParams _product;

        public VkUsersGetParamsBuilder()
        {
            Reset();
        }

        public void SetStatus()
        {
            _product.Status = "status";
        }

        public void SetPhoto()
        {
            _product.Photo = "photo_200";
        }

        public void SetLastSeen()
        {
            _product.LastSeen = "last_seen";
        }
        public UsersGetParams GetProduct()
        {
            UsersGetParams userInfo = _product;
            Reset();
            return userInfo;
        }

        private void Reset()
        {
            _product = new();
        }
    }
}

